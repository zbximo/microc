// 测试正则表达式用

open System.Text.RegularExpressions

let (|Regex|_|) pattern input =
        let m = Regex.Match(input, pattern)
        if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
        else None


let phone = "(555) 555-5555"

match phone with
    | Regex @"\(([0-9]{3})\)[-. ]?([0-9]{3})[-. ]?([0-9]{4})" [ area; prefix; suffix ] ->
        printfn "Area: %s, Prefix: %s, Suffix: %s" area prefix suffix
    | _ -> printfn "Not a phone number"

let phone = "(555)"

match phone with
    | Regex @"\(([0-9]{3})\)" [ area ] ->
        printfn "Area: %s" area 
    | _ -> printfn "Not a phone number"

let phone = "__"

match phone with
    // | Regex @"(^[A-Z])" [ area ] ->
    //     printfn "Area: %s" area 
    | Regex @"([__])" [ area ] ->
        printfn "Area: %s" area    
    | _ -> printfn "Not a phone number"