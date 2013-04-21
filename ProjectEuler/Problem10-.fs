//Problem #10
//Lada Gagina
//(c)2013

let isprime x = 
    let mutable i = 2UL
    while x % i <> 0UL do
        i <- i + 1UL
    if i = x then true else false

(*let mutable sum = 2
for i in [3..2..2000000] do
    if (isprime i) then sum <- sum + i

printfn "%A" sum*)

let x = [3UL..2UL..2000000UL]
let y = List.append [2UL] x
let z = List.filter (isprime) y
printfn "%A" (List.sum z)