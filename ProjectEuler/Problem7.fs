//The 10 001st prime number
//Lada Gagina
//(c)2013

let isprime x = 
    let mutable i = 2
    while x % i <> 0 do
        i <- i + 1
        if (float i > sqrt (float x)) then i <- x
    i = x

let mutable num = 1
let mutable maxprime = 2
while (num < 10001) do 
    maxprime <- maxprime + 1
    if (isprime maxprime) then num <- num + 1

printf "%A" maxprime