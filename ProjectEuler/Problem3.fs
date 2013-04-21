//Problem #3
//Lada Gagina
//(c)2013

let isprime x = 
    let mutable i = 2UL
    while x % i <> 0UL do
        i <- i + 1UL
    if i = x then true else false

let x = 600851475143UL
let mutable i = 2UL
let mutable divx = x
let mutable max = 0UL

while (divx <> 1UL) do 
    if (isprime i = true) && (divx % i = 0UL) then divx <- divx / i
                                                   i <- 2UL
                                              else i <- i + 1UL
    if (i > max) then max <- i

printf "%A" max

    


(*for i in 2UL..x / 2UL do
    if (isprime i = i) && (x % i = 0UL) then max <- i

printf "%A" max*)
