//Problem #4
//Lada Gagina
//(c)2013

let mutable max = 0
for i in 900..999 do
    for j in 900..999 do
        let n = i * j
        if n / 100000 = n % 10 then
            if n / 10000 % 10 = n / 10 % 10 then
                if n / 1000 % 10 = n / 100 % 10 then max <- n
printfn "%A" max