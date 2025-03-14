open System

printfn "Enter your string input"

let input = Console.ReadLine()

let Add input =
        match input with
        | "" -> 0
        | _ -> input.Split(',') 
                |> Array.map int
                |> Array.sum
 
try
    let sum = Add input
    printfn $"The sum = {sum}"
with
    exp -> printfn $"Error: {exp.Message}" 