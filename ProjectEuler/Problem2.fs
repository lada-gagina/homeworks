//problem #2
//Lada Gagina
//(c)2013

let mutable sum = 0
let mutable i = 1
let mutable j = 2
while j <= 4000000 do
     if j % 2 = 0 then sum <- sum + j
     j <- i + j
     i <- j - i
printfn "%A" sum
