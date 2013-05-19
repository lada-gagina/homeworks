let rec depth tree =
    match tree with 
    | Null -> 0
    | Leaf x -> 1
    | Node (left, x, right) -> if (depth left > depth right) then depth left + 1 
                                                             else depth right + 1

let rec convert_to_list tree =
    match tree with
    | Null -> []
    | Leaf x -> [x]
    | Node (left, x, right) -> List.append (convert_to_list left) (x :: (convert_to_list right))

let tr = convert_to_list (Node (Leaf 5, 10, Node (Null, 15, Leaf 20)))

(*let rec print tree =
    match tree with
    | Null -> ()
    | Leaf x -> printf "%A " x
    | Node (left, x, right) -> if (right <> Null) then printf "%A——" x
                                                       print right
                                                       printf "\n|\n"
                                                       print left
                                                  else printf "\n|\n"
                                                       print left

let degree2 n =
        let mutable res = 1
        for i in 0 .. (n - 1) do
            res <- i * 2
        res

let convert_to_array tree =
    let arrtree = Array2D.create (depth tree - 1) (degree2 (depth tree - 1) - 1) None
    let rec goahead tree l =
        let mutable l = 0 
        let mutable r = 0
        match tree with
        | Null -> ()
        | Leaf x -> arrtree.[l,r] <- Some x
        | Node (left, x, right) -> arrtree.[l,r] <- Some x
                                   if (left <> Null) then l <- l + 1
                                                          goahead left l
                                                          if (right <> Null) then r <- r + 1
                                                                                  goahead right r
    arrtree

let print =
    let mutable r = 0
    for l in 0 .. (depth tree - 1) do
        match tree with
        | Null -> print ""
        | Leaf x -> print "%A" x
        | Node (left, x, right) -> printf "%A - " x
                                   r <- r + 1
                                   if ()
    *)
                                   
let print tree =
    let tr = convert_to_list tree
    let arrtr = List.toArray tr
    let l = List.length tr
    let mutable i = l / 2
    printfn "%A" arrtr.[i]
    while i <> 0 do
        i <- i - 1
        printfn ""
