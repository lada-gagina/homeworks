//functions for lists
//Lada Gagina
//(c)2013

let rec add_to_end list a =
    match list with
    | [] -> [a]
    | hd :: tl -> hd :: add_to_end tl a

let rec append list1 list2 =
    match list2 with
    | [] -> list1
    | hd :: tl -> append (add_to_end list1 hd) tl  

let rec reverse list =
    match list with
    | [] -> []
    | hd :: tl -> add_to_end (reverse tl) hd

type Option =
    | None
    | Some of int

let rec find predicate list =
    match list with
    | [] -> None
    | hd :: tl -> if (predicate hd) then Some hd else find predicate tl

let isDivisibleBy number elem = elem % number = 0
let result = find ((=) 5) [ 1 .. 100 ]
printfn "%A" result//functions for lists
//Lada Gagina
//(c)2013

let rec add_to_end list a =
    match list with
    | [] -> [a]
    | hd :: tl -> hd :: add_to_end tl a

let rec append list1 list2 =
    match list2 with
    | [] -> list1
    | hd :: tl -> append (add_to_end list1 hd) tl  

let rec reverse list =
    match list with
    | [] -> []
    | hd :: tl -> add_to_end (reverse tl) hd

type Option =
    | None
    | Some of int

let rec find predicate list =
    match list with
    | [] -> None
    | hd :: tl -> if (predicate hd) then Some hd else find predicate tl

let rec map op list =
    match list with
    | [] -> []
    | hd :: tl -> (List.fold op [] [hd]) :: (map op tl)

let list = [1;2;3;4]
printfn "%A" (map (fun x -> x + 1) list)