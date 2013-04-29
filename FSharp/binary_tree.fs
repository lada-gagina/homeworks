//binary tree
//Lada Gagina
//(c)2013

type binary_tree<'a> =
    | Null
    | Node of (binary_tree<'a> * 'a * binary_tree<'a>)

let tr = Node (Null, 5, Null)

let rec add_to_tree tree a = 
    match tree with
    | Null -> Node (Null, a, Null)
    | Node (left, x, right) -> if (a < x) then Node ((add_to_tree left a), x, right) else Node (left, x, (add_to_tree right a))

let tr1 = add_to_tree tr 4

let rec exist tree a =
    match tree with
    | Null -> false
    | Node (left, x, right) -> if (a = x) then true else (if (a < x) then exist left a else exist right a) 

let rec is_empty tree =
    match tree with
    | Null -> true
    | Node (_,_,_) -> false

let add_to_tree_test =
    (add_to_tree (Node (Null, 5, Node (Null, 10, Null))) 8 = Node (Null, 5, Node (Null, 8, Node (Null, 10, Null))))&&
    (add_to_tree Null 10 = Node (Null, 10, Null))

let exist_test =
    (exist (Node (Null, 5, Node (Null, 10, Null))) 8 = false)&&
    (exist Null 10 = false)&&
    (exist (Node (Null, 5, Node (Null, 10, Null))) 10 = true)

let is_empty_test =
    (is_empty Null = true)&&
    (is_empty (Node (Null, 4, Null)) = false)

printfn "%A" (add_to_tree_test, exist_test, is_empty_test)