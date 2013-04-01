//problem #5
//Lada Gagina
//(c)2013

let rec gcd a b = if b = 0 then a else gcd b (a % b)
let mutable lcm = 2520
for i = 11 to 20 do
    lcm <- lcm * i / gcd lcm i
printfn "%A" lcm