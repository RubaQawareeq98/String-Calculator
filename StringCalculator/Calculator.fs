module Calculator

open System
open ExceptionCustom

let extractDelimiters (delimiter: string) =
    if delimiter.StartsWith("[") then
        delimiter.Substring(1, delimiter.Length - 2).Split("][") |> Array.toList
    else
        [delimiter]


let extractDelimitersAndNumbers (input: string) =
    if input.StartsWith("//") then
                let lineIndex = input.IndexOf("\n")
                let delimiterString = input.Substring(2, lineIndex - 2)
                let delimiters = extractDelimiters delimiterString      
                let numbers = input.Substring(lineIndex + 1)
                delimiters, numbers
            else
                [","], input
                
let checkForNegative (numbers: int array) =
    let negativeNums = numbers |> Array.filter (fun n -> n < 0)
        
    if negativeNums.Length > 0 then
        let numbersString = String.concat ", " (Array.map string negativeNums)
        raise (InvalidNegativeNumbersException $"Negative numbers not valid: {numbersString}")
    numbers

let add input =
    match input with
    | "" -> 0
    | _ -> 
        let delimiters, numbers = extractDelimitersAndNumbers input
            
        let numbersPart = numbers.Split(Array.ofList ("," :: "\n" :: delimiters), StringSplitOptions.None)
        
        numbersPart |> Array.map int    
        |> checkForNegative
        |> Array.filter(fun n -> n < 1000) 
        |> Array.sum


[<EntryPoint>]
let main _ =
    printfn "Enter your string input"

    let input = Console.ReadLine()
     
    try
        let sum = add input
        printfn $"The sum =  {sum}"
    with
        | InvalidNegativeNumbersException(msg) -> printfn $"%s{msg}"
        | exp -> printfn $"Error: {exp.Message}"
    0