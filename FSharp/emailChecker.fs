open System
open NUnit.Framework
open FsUnit
open System.Text.RegularExpressions


let iscorrect address = 
    let login = "^[a-zA-Z_][a-zA-Z0-9_-]*(\.?[a-zA-Z_0-9]+)*" // '.' may be in the middle, but may not be the first or the last symbol of the name
    let domains = "([a-z]+\.)+"
    let tld = "(name|info|yandex|museum|[a-zA-Z]{2,3})$"
    let RegExpr = new Regex(login + "@" + domains + tld)
    
    RegExpr.IsMatch (address)

[<TestFixture>]
type ``Right`` ()=

    [<Test>] member x.
     ``#1`` ()=
            iscorrect "a@b.cc" |> should be True

    [<Test>] member x.
     ``#2`` ()=
            iscorrect "victor.polozov@mail.ru" |> should be True

    [<Test>] member x.
     ``#3`` ()=
            iscorrect "my@domain.info" |> should be True

    [<Test>] member x.
     ``#4`` ()=
            iscorrect "_.1@mail.com" |> should be True
  
    [<Test>] member x.
     ``#5`` ()=
            iscorrect "coins_department@hermitage.museum" |> should be True

[<TestFixture>] 
type ``Wrong`` ()=

    [<Test>] member x.
     ``too short domain`` ()=
            iscorrect "a@b.c" |> should be False

    [<Test>] member x.
     ``two dots in name`` ()=
            iscorrect "a..b@mail.ru" |> should be False

    [<Test>] member x.
     ``dot as the first symbol of the name`` ()=
            iscorrect ".a@mail.ru" |> should be False

    [<Test>] member x.
     ``incorrect domain`` ()=
            iscorrect "yo@domain.somedomain" |> should be False

    [<Test>] member x.
     ``invalid first symbol of the name`` ()=
            iscorrect "1@mail.ru" |> should be False