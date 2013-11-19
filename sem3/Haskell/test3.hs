-- Волк, коза и капуста (все решения)
-- A, T, G, C ; A - T, G - C построить комплементарный список из букв (список) (ф-я, заменяющая A на T, G на C и наоборот)
-- (l1, l2, l3) -> Integer ; если не сопоставилось, сдвигаемся на один шаг, если остался хвост < 3 , выбрасываем f :: Char -> Char -> Char -> Integer?
-- По списку чисел - список букв (обратная к 3й)


-------------2---------------------------
p1 = ('A', 'T')
p2 = ('G', 'C')

data Pair = P (Char, Char) deriving Show
data Base = A | T | G | C deriving Show 


pairs = [P c | c <- zip ['A', 'G', 'T', 'C'] ['T', 'C', 'A', 'G']]


complement [] = []
complement (x : xs)
	| x == 'A' = 'T' : (complement xs)
	| x == 'T' = 'A' : (complement xs)
	| x == 'G' = 'C' : (complement xs)
	| x == 'C' = 'G' : (complement xs)
	| True = "" ++ (complement xs)


-------------3-------------------
f :: Char -> Char -> Char -> Integer
replacement f [] = []
replacement f (x1 : []) = []
replacement f (x1 : x2 : []) = []
replacement f (x1 : x2 : x3 : xs) = (f x1 x2 x3) : (replacement xs)
