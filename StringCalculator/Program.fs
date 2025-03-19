open System

let Add input =
    match input with
    | "" -> 0
    | _ -> input.Split([|","; "\\n"|], StringSplitOptions.None) 
            |> Array.map int
            |> Array.sum
 
printfn "Enter your string input"

let input = Console.ReadLine()

try
    let sum = Add input
    printfn $"The sum = {sum}"
with
    exp -> printfn $"Error: {exp.Message}" 