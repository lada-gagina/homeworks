type Parser a = String -> [(a,String)] -- синоним

empty :: Parser a
empty = \s -> []

sym :: Char -> Parser Char
sym c (t:ts) |c == t = [(c, ts)]
sym _ _ = []

val :: a -> Parser a
val a str = [(a,str)]

infixl 2 |||
(|||) :: Parser a -> Parser a -> Parser a
(p1 ||| p2) s = p1 s ++ p2 s

infixl 3 ||>
(||>) :: Parser a -> (a -> Parser b) -> Parser b
p ||> q = \s -> concat [q a s | (a, s) <- p s] 

many :: Parser a -> Parser [a]
many par = par ||> (\a -> many par ||> val . (a:)) ||| val []

opt :: Parser a -> Parser (Maybe a)
opt a = a ||> val . Just ||| val Nothing

eof :: [(a, String)] -> [a]
eof = map fst . filter ((== []) . snd)
------------------------------------------------------------------------------------------
data E = X String 
       | N Integer 
	   | Mul E E 
	   | Div E E 
	   | Add E E
	   | Sub E E
	   | Gt  E E
	   | Ge  E E
	   | Lt  E E
	   | Le  E E
	   | Eq  E E
	   | NEq  E E
	   | Or  E E
	   | And E E
	   deriving Show

oneOf = foldr ((|||) . sym) empty

letter = oneOf $ '_':(['a'..'z'] ++ ['A'..'Z'])
digit = oneOf ['0'..'9']

literal = digit ||> (\a -> many digit ||> (\b -> val $ N $ read (a : b)))
ident = letter ||> (\a -> many (letter ||| digit) ||> (\b -> val $ X (a : b)))

primary = ident 
      ||| literal
	  ||| sym '(' ||> (\_ -> expr ||> (\a -> sym ')' ||> (\_ -> val a)))
	  
multi = common primary multi [("*", Mul),("/", Div)]	   
addi = common multi addi [("+", Add),("-", Sub)]
reli = common addi addi $ zip [">", ">=", "<", "<=", "==", "!="] [Gt, Ge, Lt, Le, Eq, NEq]
logi = common reli logi $ zip ["&&", "||"] [And, Or]
	  
common :: Parser E -> Parser E -> [(String, (E -> E -> E))] -> Parser E
common p1 p2 listOp = p1 ||> (\ a -> op ||> (\o -> p2 ||> (\b -> val $ a `o` b)))
			  ||| p1
			  where op = foldl (\acc (s, f) -> acc ||| prefix s ||> (\_ -> val f)) empty listOp
				prefix [x] = sym x
				prefix (x:xs) = sym x ||> (\_ -> prefix xs)

expr = logi