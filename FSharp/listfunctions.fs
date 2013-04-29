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

let rec find predicate list =
    match list with
    | [] -> None
    | hd :: tl -> if (predicate hd) then Some hd else find predicate tl

let rec map op list =
    match list with
    | [] -> []
    | hd :: tl -> ((List.fold (fun acc x -> op x) 0 [hd]) :: map op tl)

//tests

let add_to_end_test =
    (add_to_end [] 0 = [0])&&
    (add_to_end [1;3;5] 44 = [1;3;5;44])

let append_test =
    (append [] [] = [])&&
    (append [1;3;5] [] = [1;3;5])&&
    (append [44;22] [11;13;4] = [44;22;11;13;4])

let reverse_test =
    (reverse [] = [])&&
    (reverse [44] = [44])&&
    (reverse [9;8;7;6;5;4;3;2;1] = [1;2;3;4;5;6;7;8;9])

let find_test =
    (find ((>) 3) [1;2;3;4;5;6;7;8;9] = Some 1)&&
    (find ((=) 20) [] = None)

let map_test =
    (map (fun x -> x * x) [] = [])&&
    (map (fun x -> x + 4) [1;3;5] = [5;7;9])

printf "%A" (add_to_end_test, append_test, reverse_test, find_test, map_test)