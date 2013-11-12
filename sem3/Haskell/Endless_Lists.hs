fib 0 = 0
fib 1 = 1
fib n = fib (n - 2) + fib (n - 1)
--List of Fibonacci numbers
fibList = [fib x | x <- [0..]]


isprime 1 = False
isprime n = foldl (&&) True list
	where list = map (0 /=) (map (mod n) [2..(n - 1)])
--List of primes	
primeList = [x | x <- [1..], isprime x]