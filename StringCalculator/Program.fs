open System

printfn "Enter your string input"

let input = Console.ReadLine()

let Add input =
    match input with
    | "" -> 0
    | _ -> match input.Split(',') with
            | [|num|] -> int num
            | [|num1; num2|] -> int num1 + int num2
            | _ -> failwith "Invalid Input"
 
try
    let sum = Add input
    printfn $"The sum = {sum}"
with
    exp -> printfn $"Error: {exp.Message}" 