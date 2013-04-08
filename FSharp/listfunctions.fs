//functions for lists
//Lada Gagina
//(c)2013
let rec add_to_end list a =
    match list with
    | [] -> [a]
    | hd :: tl -> hd :: add_to_end tl a
	
let list = [1;3;5]
printfn "%A" <| add_to_end list 7

let rec append list1 list2 =
    match list2 with
    | [] -> list1
    | hd :: tl -> append (add_to_end list1 hd) tl 

let list1 = [1;2;3;4]
let list2 = [5;6;7;8]
printfn "%A" <| append list1 list2 

let rec reverse list =
    match list with
    | [] -> []
    | hd :: tl -> add_to_end (reverse tl) hd

let list = [1;2;3;4;5]
printfn "%A" <| reverse list