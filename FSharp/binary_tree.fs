//binary tree
//Lada Gagina
//(c)2013

type binary_tree<'a> =
    | Null
    | Leaf of 'a
    | Node of (binary_tree<'a> * 'a * binary_tree<'a>)

let rec add_to_tree a tree = 
    match tree with
    | Null -> Node (Null, a, Null)
    | Leaf x -> if (a < x) then Node (Leaf a, x, Null) else Node (Null, x, Leaf a)
    | Node (left, x, right) -> if (a < x) then Node ((add_to_tree a left), x, right) else Node (left, x, (add_to_tree a right))

let rec exist tree a =
    match tree with
    | Null -> false
    | Leaf x -> a = x
    | Node (left, x, right) -> if (a = x) then true else (if (a < x) then exist left a else exist right a) 

let rec stick left right =
    match left with
    | Null -> right
    | Leaf x -> Node (Null, x, right)
    | Node (l, x, r) -> Node (l, x, (stick r right))
    
let rec delete tree a =
    match tree with 
    | Null -> Null
    | Leaf x -> if (a = x) then Null else Leaf x
    | Node (left, x, right) -> if (a < x) then Node (delete left a, x, right) 
                                          else if (a > x) then Node (left, x, delete right a) 
                                          else stick left right


let mutable far = 0
let rec print tree =
    
    let print_sticks n =
        for i in 1 .. n do
        printf "|    "

    match tree with
    | Null -> printfn "\b"
    | Leaf x -> printfn "%d" x
    | Node (left, x, right) -> printf "%d —— " x
                               far <- far + 1
                               print right
                               print_sticks far                               
                               printf "\n"
                               print_sticks (far - 1)
                               far <- 0
                               print left

//tests

let test_tree = Node (Node (Leaf 3, 5, Leaf 9), 1000, Node (Leaf 11, 13, Leaf 15))
print test_tree
let test_add_tree = Node (Node (Node (Null, 3, Leaf 4), 5, Leaf 9), 10, Node (Leaf 11, 13, Leaf 15))
let test_delete_tree = Node (Node (Null, 3, Leaf 9), 10, Node (Leaf 11, 13, Leaf 15))

let tree =
  Null
  |> add_to_tree 5
  |> add_to_tree 8
  |> add_to_tree 1

let add_to_tree_test =
    (add_to_tree 4 test_tree = test_add_tree)

let exist_test =
    (exist test_tree 4 = false)&&
    (exist test_tree 10 = true)

let delete_test =
    (delete test_tree 4 = test_tree)&&
    (delete test_tree 5 = test_delete_tree)

printfn "%A" (add_to_tree_test, exist_test, delete_test)    
    

(*let rec depth tree =
    let mutable acc = 0
    match tree with 
    | Null -> 0
    | Leaf _ -> acc + 1
    | Node (left, _, right) -> acc + 1 + max (depth left: int) (depth right: int) *)
