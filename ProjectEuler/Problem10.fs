//The sum of all the primes below 2 000 000
//Lada Gagina
//(c)2013

let isprime x = 
    let mutable i = 2L
    while x % i <> 0L do
        i <- i + 1L
        if (i > int64 (sqrt (float x))) then i <- x
    i = x

let n = 2000000L
let Sieve_of_Eratosthenes =
    let sieve = [|for i in 0L .. n -> true|]
    sieve.[1] <- false
    for i in 2L .. int64 (sqrt (float n) + 1.0) do
        if (isprime i) then
            for j in i * i .. i .. n do
                sieve.[int j] <- false
    sieve

let mutable sum = 0L
for i in 1L .. n do
    if (Sieve_of_Eratosthenes.[int i]) then sum <- sum + i

printfn "%A" sum