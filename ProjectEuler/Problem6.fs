//The difference between the sum of the squares of the first one hundred natural numbers and the square of the sum
//Lada Gagina
//(c)2013

let n = 100
let a = Seq.sum {1 .. n} * Seq.sum {1 .. n}
let b = Seq.sum (seq {for x in [1..n] -> x * x})
printfn "%A" (a - b)