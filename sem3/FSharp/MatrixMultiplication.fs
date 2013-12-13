open System
open System.Diagnostics

let size = 1000
let rnd = new Random()
let m1 = Array2D.create size size (rnd.Next(0, 9))
let m2 = Array2D.create size size (rnd.Next(0, 9))

let mul (m1 : int[,]) (m2 : int[,]) numberOfStreams =
    if Array2D.length2 m1 <> Array2D.length1 m2 then failwith "error"
    let height = Array2D.length1 m1
    let width = Array2D.length2 m2   
    let res = Array2D.create height width 0
    let getElem i j = List.fold (fun acc k -> acc + m1.[i,k] * m2.[k,j]) 0 [0..Array2D.length2 m1 - 1]
    let calculeAsyncPart a b = async{List.iter (fun i -> List.iter (fun j -> res.[i,j] <- getElem i j) [0..width - 1]) [a..b]}
    
    let listAsyncParts = List.map (fun n -> calculeAsyncPart (n * height / numberOfStreams) ((n + 1) * height / numberOfStreams - 1)) [0..numberOfStreams - 1]
    listAsyncParts 
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore

    res

let streamList = [1;2;4;8]
let timer = new Stopwatch()

let printTime numberOfStreams = timer.Start()
                                let res = mul m1 m2 numberOfStreams
                                timer.Stop()
                                printfn "%d                             %A\n" numberOfStreams timer.Elapsed
                                timer.Reset()

printfn "Multiplication of two matrices %dx%d:\n" size size
printfn "Number of streams              Time\n"
List.map (fun n -> printTime n) streamList |> ignore