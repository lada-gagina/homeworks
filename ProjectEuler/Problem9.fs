//The product of a Pythagorean triplet which sum is 1000
//Lada Gagina
//(c)2013

let sum = 1000

let mutable res = 0

let product =
    for a in 1..sum do
        for b in (a + 1)..sum do
            let c = sum - a - b
            if (a*a + b*b = c*c) then res <- a * b * c
    res

printfn "%A" product