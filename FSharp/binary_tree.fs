//binary tree
//Lada Gagina
//(c)2013

type binary_tree<'a> =
    | Null
    | Leaf of 'a
    | Node of (binary_tree<'a> * 'a * binary_tree<'a>)

let rec add_to_tree a tree =
    match tree with
    | Null -> Leaf a
    | Leaf x -> if (a < x) then Node (Leaf a, x, Null) else Node (Null, x, Leaf a)
    | Node (left, x, right) -> if (a < x) then Node ((add_to_tree a left), x, right) else Node (left, x, (add_to_tree a right))

let rec exist tree a =
    match tree with
    | Null -> false
    | Leaf x -> a = x
    | Node (left, x, right) -> if (a = x) then true else (if (a < x) then exist left a else exist right a)
    
let rec delete tree a =

    let correct tree =
        match tree with
        | Node (Null, x, Null) -> Leaf x
        | _ -> tree

    let rec stick left right =
        match left with
        | Null -> right
        | Leaf x -> Node (Null, x, right)
        | Node (l, x, r) -> Node (l, x, correct (stick r right))

    match tree with
    | Null -> Null
    | Leaf x -> if (a = x) then Null else Leaf x
    | Node (left, x, right) -> if (a < x) then correct (Node (delete left a, x, right))
                                          else if (a > x) then correct (Node (left, x, delete right a))
                                          else stick left (delete right a)

let print tree =

    let num_of_digits n =
        let mutable x = n
        let mutable i = 0
        while x <> 0 do
            i <- i + 1
            x <- x / 10 
        i

    let rec print' tree s =
        match tree with
        | Null -> printfn ""
        | Leaf x -> printfn "%A" x
        | Node (left, x, right) -> 
            printf "%A" x
            if (right <> Null) then printf " —— "
            print' right (s + (if (left <> Null) then "|" else " ") + (String.replicate ((num_of_digits x) + 3) " ")) // + " -- " - 1
            if (left <> Null) then 
                printf "%s|\n%s" s s
                print' left s

    print' tree ""

//tests 

let test_tree = Node (Node (Leaf 3, 5, Leaf 9), 10, Node (Leaf 11, 13, Leaf 15))

let test_add_tree = Node (Node (Node (Null, 3, Leaf 4), 5, Leaf 9), 10, Node (Leaf 11, 13, Leaf 15))
let test_delete_tree = Node (Node (Null, 3, Leaf 9), 10, Node (Leaf 11, 13, Leaf 15))

let tree = 
    Null
    |> add_to_tree 10
    |> add_to_tree 1
    |> add_to_tree 18
    |> add_to_tree 7
    |> add_to_tree 2
    |> add_to_tree 4
    |> add_to_tree 6
    |> add_to_tree 25
    |> add_to_tree 9
    |> add_to_tree 15
    |> add_to_tree 17
    |> add_to_tree 16
    |> add_to_tree 10
    |> add_to_tree 26
    |> add_to_tree 34
    |> add_to_tree 12
    |> add_to_tree 13
    |> add_to_tree 14
    |> add_to_tree 12
    |> add_to_tree 16
    |> add_to_tree 20

print tree

let add_to_tree_test =
    (add_to_tree 4 test_tree = test_add_tree)

let exist_test =
    (exist test_tree 4 = false)&&
    (exist test_tree 10 = true)

let delete_test =
    (delete test_tree 4 = test_tree)&&
    (delete test_tree 5 = test_delete_tree)

printfn "%A" (add_to_tree_test, exist_test, delete_test) 