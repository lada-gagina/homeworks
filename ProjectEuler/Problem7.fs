//Problem #7
//Lada Gagina
//(c)2013

let x = 10 in
    let isprime x = 
        let mutable i = 2
        while x % i <> 0 do
            i <- i + 1
        if i = x then x else 0

printfn "%A" isprime