//The largest palindrome made from the product of two 3-digit numbers
//Lada Gagina
//(c)2013

let ispalindrome (n: int) =
    let s = System.Convert.ToString n
    let mutable ret = true
    for i = 0 to s.Length / 2 do
        if s.[i] <> s.[s.Length - i - 1] then ret <- false 
    ret

let mutable max = 0
for i in 900..999 do
    for j in 900..999 do
        let n = i * j
        if (ispalindrome n) then max <- n
        
printfn "%A" max