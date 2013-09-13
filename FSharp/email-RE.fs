open System.Text.RegularExpressions

let iscorrect address = 
    let login = "^\w[a-zA-Z0-9!#$%&'*+-/=?^_`{|}~\.]{0,62}[a-zA-Z0-9!#$%&'*+-/=?^_`{|}~]+" // '.' may be in the middle, but may not be the first or the last symbol of the name
    let domains = "[a-zA-Z\.]{2,184}"
    let tld = "(name|info|yandex|domain|museum|[a-zA-Z]{2,3})$"
    let RegExpr = new Regex(login + "@" + domains + tld)
    
    RegExpr.IsMatch (address)

let correcttests = ["a.a%@mail.ru"
                    "ladagagina@math.spbu.ru"
                    "info@about.museum"
                    "1234567890abc@gmail.com"
                    "victorp@math.spbu.ru"]
let incorrecttests = ["a.a%@@mail.ru"
                      "lada@gagina@math.spbu.ru"
                      "info.@about.museum"
                      "1234567890abc@example.example"
                      ".victorp@math.spbu.ru"]

let test1 = List.fold (fun acc x -> acc && x) true (correcttests |> List.map (fun x -> iscorrect x))
let test2 = List.fold (fun acc x -> acc && x) true (incorrecttests |> List.map (fun x -> iscorrect x))
printfn "Test1 (should be true): %A" test1
printfn "Test2 (should be false): %A" test2