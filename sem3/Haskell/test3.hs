
-------------2-------------------

data Base = A | T | G | C deriving (Show, Eq) 


complement [] = []
complement (x : xs)
	| x == A = T : (complement xs)
	| x == T = A : (complement xs)
	| x == G = C : (complement xs)
	| x == C = G : (complement xs)


-------------3-------------------

replacement f (x1 : t@(x2 : x3 : xs)) =
	case f x1 x2 x3 of 
		Just x -> x : (replacement f xs)
		_ -> replacement f t
replacement f _ = []

-------------4--------------------

inverseReplacement f (x : xs) =
	case f x of 
		Just (x1, x2, x3) -> x1 : x2 : x3 : (inverseReplacement f xs)
		_ -> inverseReplacement f xs
inverseReplacement f _ = []
