//The sum of the even-valued Fibonacci terms whose values do not exceed 4 000 000
//Lada Gagina
//(c)2013

let nextfib prev1 prev2 =
    prev1 + prev2

let mutable tempsum = 0 
let mutable i = 0 
let mutable j = 1 
let max = 4000000

let sum =
    while (nextfib i j) <= max do
        let next = nextfib i j
        if next % 2 = 0 then tempsum <- tempsum + next
        i <- j
        j <- next
    tempsum

printfn "%A" sum