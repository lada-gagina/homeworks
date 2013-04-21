//Problem #9
//Lada Gagina
//(c)2013

for a in 1..300 do
    for b in (a + 1)..600 do
        let c = 1000 - a - b
        if (a*a + b*b = c*c) then printfn "%A" (a * b * c)