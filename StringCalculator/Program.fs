open System

let extractDelimiters (delimiter: string) =
    if delimiter.StartsWith("[") then
        delimiter.Substring(1, delimiter.Length - 2).Split("][") |> Array.toList
    else
        [delimiter]



let Add input =
    match input with
    | "" -> 0
    | _ -> 
        let delimiter, numbers =
            if input.StartsWith("//") then
                let line = input.IndexOf("\\n")
                let delimiter = input.Substring(2, line - 2)
                let delimiters = extractDelimiters delimiter      
                let numbers = input.Substring(line + 2)
                delimiters, numbers
            else
                [","], input  

        let numbersPart = numbers.Split(Array.ofList ("," :: "\\n" :: delimiter), StringSplitOptions.None)
        let intNumbers = numbersPart |> Array.map int
        let negativeNums = intNumbers |> Array.filter (fun n -> n < 0)
        
        if (negativeNums.Length > 0) then
            failwith("Negative numbers not valid")
        intNumbers |> Array.filter(fun n -> n < 1000)
        |> Array.sum


printfn "Enter your string input"

let input = Console.ReadLine()
 
try
    let sum = Add input
    printfn $"The sum = {sum}"
with
    exp -> printfn $"Error: {exp.Message}" 