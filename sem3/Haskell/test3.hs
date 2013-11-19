
-------------2---------------------------
--p1 = ('A', 'T')
--p2 = ('G', 'C')

--data Pair = P (Char, Char) deriving Show
data Base = A | T | G | C deriving (Show, Eq) 


--pairs = [P c | c <- zip ['A', 'G', 'T', 'C'] ['T', 'C', 'A', 'G']]


complement [] = []
complement (x : xs)
	| x == A = T : (complement xs)
	| x == T = A : (complement xs)
	| x == G = C : (complement xs)
	| x == C = G : (complement xs)


-------------3-------------------
--f :: Char -> Char -> Char -> Integer

f _ _ _ = Just 1

replacement f (x1 : t@(x2 : x3 : xs)) =
	case f x1 x2 x3 of 
		Just x -> x : (replacement f xs)
		_ -> replacement f t
replacement f _ = []

-------------4--------------------

