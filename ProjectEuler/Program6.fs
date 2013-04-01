//Problem #6
//Lada Gagina
//(c)2013

open System
let x = seq {for x in [1..100] -> x}
let y = seq {for x in [1..100] -> x * x}
let a = Seq.sum x * Seq.sum x
let b = Seq.sum y
printfn "%A" (a - b)