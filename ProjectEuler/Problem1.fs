//problem #1
//Lada Gagina
//(c)2013

let mutable sum = 0
for i in 3..999 do
    if i % 3 = 0 || i % 5 = 0 then sum <- sum + i else sum <- sum + 0
printfn "%A" sum