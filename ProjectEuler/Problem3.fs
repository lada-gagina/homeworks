//Problem #3
//Lada Gagina
//(c)2013

let isprime x = 
    let mutable i = 2UL
    while x % i <> 0UL do
        i <- i + 1UL
    i = x

let x = 600851475143UL
let mutable i = 2UL
let mutable divx = x

while (divx <> 1UL) do 
    if (divx % i = 0UL) then divx <- divx / i
                                       else i <- i + 1UL


printf "%A" i

    


(*for i in 2UL..x / 2UL do
    if (isprime i = i) && (x % i = 0UL) then max <- i

printf "%A" max*)
