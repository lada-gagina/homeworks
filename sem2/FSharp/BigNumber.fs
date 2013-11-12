//BigNumber
//Lada Gagina
//(c)2013

type big_number =

    val private sign : bool
    val private number : int list

    static member private max = 10

    new (s: string) =
        
        let rec string_to_list list (s: string) =
            if ((s.[0] < '0') || (s.[0] > '9')) then failwith "\n\nInvalid characters in input data\n\n"
            let list1 = (int s.[0] - int '0') :: list 
            if (s.Length > 1) then string_to_list list1 s.[1..(s.Length - 1)] 
                              else list1         
        {
            sign = (s.[0] <> '-')
            number = string_to_list [] (if (s.[0] = '-') then s.[1..(s.Length - 1)] else s)
        }

    private new (sign: bool, list: int list) =
        {
            sign = sign
            number = list
        }

    static member private add (a: int list, b: int list) =
        let rec add' list1 list2 carry =
            match list1, list2 with
            | [], [] -> if (carry > 0) then [carry] else []
            | [], hd :: tl -> if (hd + carry >= big_number.max) then (hd + carry - big_number.max) :: add' [] tl carry else (hd + carry) :: tl
            | list, [] -> add' [] list carry
            | hd1 :: tl1, hd2 :: tl2 -> 
                let sum = hd1 + hd2 + carry
                sum % big_number.max :: (add' tl1 tl2 (sum / big_number.max))
        add' a b 0                

    static member private sub (a: int list, b: int list) =
        let rec delete_zeros list =
            match list with
            | [] -> [0]
            | hd :: tl -> if (hd = 0) then delete_zeros tl else hd :: tl
        
        let rec sub' list1 list2 borrow =
            match list1, list2 with
            | [], [] -> []
            | hd :: tl, [] -> if (borrow = 0) then list1 else (sub' list1 [1] 0)
            | hd1 :: tl1, hd2 :: tl2 -> if (hd1 - hd2 - borrow < 0) then let next_borrow = 1
                                                                         hd1 - hd2 - borrow + big_number.max :: (sub' tl1 tl2 next_borrow)
                                                                    else hd1 - hd2 - borrow :: (sub' tl1 tl2 0)
            | _ -> failwith "\n\nIncorrect arguments in subtraction\n\n"
        List.rev (delete_zeros (List.rev (sub' a b 0))) 

    static member private cmp (a: int list, b: int list) =
        if (List.length a > List.length b) then 1 
        else if (List.length a < List.length b) then -1
        else let rec cmp' a b =
                match a, b with
                | [], [] -> 0
                | hd1 :: tl1, hd2 :: tl2 -> if (hd1 = hd2) then cmp' tl1 tl2 
                                            else if (hd1 < hd2) then -1 
                                            else 1
                | _ -> failwith "\n\nImpossible error\n\n"
             
             cmp' (List.rev a) (List.rev b)

    static member private mul (a: int list, b: int) =
        if (b = 0) then [0] else
                
            let rec mul' list num carry =
                match list with
                | [] -> if (carry > 0) then [carry] else []
                | hd :: tl -> ((hd * num + carry) % big_number.max) :: mul' tl num ((hd * num + carry) / big_number.max)
            mul' a b 0 
        
    static member private multimul (a: int list, b: int list) =
        if (a = [0] || b = [0]) then [0] else

            let rec mul' b acc n =
                match b with
                | [] -> acc
                | hd :: tl -> mul' tl (big_number.add(acc, ((List.replicate n 0) @ (big_number.mul(a, hd))))) (n + 1)
            
            mul' b [] 0
     

    static member (+) (a: big_number, b: big_number) =
        if (a.sign = b.sign) then new big_number(a.sign, big_number.add (a.number, b.number))
        else if (big_number.cmp (a.number, b.number) = 0) then new big_number(true, [0])
        else if (big_number.cmp (a.number, b.number) = 1) then new big_number(a.sign, big_number.sub (a.number, b.number))
        else new big_number(b.sign, big_number.sub (b.number, a.number))
    
    static member (-) (a: big_number, b: big_number) =
        if (a.sign <> b.sign) then new big_number(a.sign, big_number.add (a.number, b.number))
        else if (big_number.cmp (a.number, b.number) = 0) then new big_number(true, [0])
        else if (big_number.cmp (a.number, b.number) = 1) then new big_number((if (a.sign) then big_number.cmp(a.number, b.number) = 1 else big_number.cmp(a.number, b.number) = -1), big_number.sub (a.number, b.number))
        else new big_number((if (a.sign) then big_number.cmp(a.number, b.number) = 1 else big_number.cmp(a.number, b.number) = -1), big_number.sub (b.number, a.number)) 
       
    static member (*) (a: big_number, b: big_number) =
        new big_number((a.sign = b.sign), big_number.multimul(a.number, b.number))
    
    member this.print =
        if not(this.sign) then printf "-"
        let list = List.rev this.number
        for i in 0..(List.length list - 1) do
            printf "%d" list.[i]            
        printfn ""                                  

    static member compare (a: big_number, b: big_number) =
        if (a.sign = b.sign) && (big_number.cmp(a.number, b.number) = 0) then 0
        else if (a.sign) && (b.sign) then big_number.cmp(a.number, b.number)
        else if not(a.sign) && not(b.sign) && (big_number.cmp(a.number, b.number) = 1) then -1
        else if not(a.sign) && not(b.sign) && (big_number.cmp(a.number, b.number) = -1) then 1
        else if (a.sign) && not(b.sign) then 1 else -1

    static member private compare_to_obj(a : big_number, b : obj) = 
        match b with
        | :? big_number as b -> big_number.compare(a, b)
        | _ -> big_number.compare_to_obj(a, new big_number(string b))

    interface System.IComparable with
        member this.CompareTo(x) =
            match x with
            | :? big_number as x -> big_number.compare(this, x)
            | _ -> big_number.compare(this, new big_number(string x))

    override this.GetHashCode() = this.ToString().GetHashCode()
    override this.Equals(x) = big_number.compare_to_obj(this, x) = 0
        
        
let test_add = (new big_number("458913") + new big_number("-258") = new big_number("458655"))
let test_sub = (new big_number("458913") - new big_number("-258") = new big_number("459171"))
let test_mul = (new big_number("458913") * new big_number("-258") = new big_number("-118399554"))
printfn "%A %A %A" test_add test_sub test_mul

(*let a = new big_number("-9998")
let b = new big_number("-9997")
let c = a + b
c.print*)