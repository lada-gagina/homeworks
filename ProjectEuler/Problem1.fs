//The sum of all the multiples of 3 or 5 below 1000
//Lada Gagina
//(c)2013

let mutable tempsum = 0
let first = 3 
let last = 999
let sum =
    for i in first .. last do
        if i % 3 = 0 || i % 5 = 0 then tempsum <- tempsum + i

printfn "%A" tempsum
