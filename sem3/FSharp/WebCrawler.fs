open System
open System.Collections.Concurrent
open System.Text.RegularExpressions
open System.Net

let attendedLinks = new ConcurrentDictionary<string,unit>()
let downloadedPictures = new ConcurrentDictionary<string,unit>()

let link = "(?:href|src)=\"((?:https?://)?[a-zA-Z0-9_./-]+)\""
let picEnd = "\.(?:jpeg|jpg|gif|png)$"
let host = "^https?://[a-zA-Z0-9_.-]+/"
let hostRegex = new Regex(host)
let linkRegex = new Regex(link)
let picEndRegex = new Regex(picEnd)

let getHtml s = 
    async {
        try let uri = new Uri(s)
            let webClient = new WebClient()
            let! html = webClient.AsyncDownloadString(uri)
            return html
        with _ -> return ""
    }

let getLinks html host =
    async {
        try let matches = linkRegex.Matches(html)
            let linkList = [for i in matches -> i.Groups.[1].Value]
            return List.map (fun (s : string) -> if (s.StartsWith("http")) then s 
                                                 elif (s.StartsWith("/")) then host + s.Remove(0, 1)
                                                 else host + s
                            ) linkList
        with _ -> return []
    }

let filterLinks link = List.filter (fun (s : string) -> s.StartsWith link && 
                                                        not (picEndRegex.IsMatch(s)) &&
                                                        not (attendedLinks.ContainsKey(s))
                                   )

let filterPicLinks = List.filter (fun (s : string) -> picEndRegex.IsMatch(s) && 
                                                      not (downloadedPictures.ContainsKey(s))
                                 )

let downloadPic link = 
    async {
        try downloadedPictures.GetOrAdd(link, ())
            let uri = new Uri(link)
            let webClient = new WebClient()
            let fileName = link.GetHashCode().ToString() + picEndRegex.Match(link).Value
            webClient.DownloadFile(uri, fileName)
        with _ -> ()
    }

let webCrawler link =
    let host = hostRegex.Match(link).Value
    let rec crawler link =
        async {
            try attendedLinks.GetOrAdd(link, ())
                let! html = getHtml link
                let! linksList = getLinks html host
                let validLinksList = filterLinks link linksList
                let validPicsList = filterPicLinks linksList
                
                validPicsList
                |> List.map downloadPic
                |> Async.Parallel
                |> Async.RunSynchronously
                |> ignore

                validLinksList
                |> List.map crawler
                |> Async.Parallel
                |> Async.RunSynchronously
                |> ignore

            with _ -> ()
        }    
    match host with
    | "" -> printfn "Incorrect link! The link should begin with \"http(s)://\"\n"
    | _  -> crawler link |> Async.RunSynchronously 
    
[<EntryPoint>]
let main argv =

    printfn "Enter an URL:\n"
    let link = Console.ReadLine()
    printfn "\nWait...\n"
    webCrawler link
    printfn "Done!\n"
    0 