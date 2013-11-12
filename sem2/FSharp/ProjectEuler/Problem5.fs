//The smallest positive number that is evenly divisible by all of the numbers from 1 to 20 
//Lada Gagina
//(c)2013

let rec gcd a b = 
    if b = 0L then a else gcd b (a % b)

let mutable lcm = 2520L
for i = 11 to 20 do
    lcm <- lcm * int64 i / gcd lcm (int64 i)

printfn "%A" lcm