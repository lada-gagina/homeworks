//Problem #7
//Lada Gagina
//(c)2013

let isprime x = 
    let mutable i = 2
    while x % i <> 0 do
        i <- i + 1
    if i = x then x else 0

let mutable number = 1
let mutable digit = 2
while (number < 10001) do 
    digit <- digit + 1
    if (isprime digit = digit) then number <- number + 1

printf "%A" digit