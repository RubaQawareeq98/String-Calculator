open System

let Add input =
    match input with
    | "" -> 0
    | _ -> 
        let delimiter, numbers =
            if input.StartsWith("//") then
                let line = input.IndexOf("\\n")
                let delimiter = input.Substring(2,line - 2)
                let numbers = input.Substring(line + 2)
                delimiter, numbers
            else
                ",", input  

        numbers.Split([| ","; "\\n"; delimiter |], StringSplitOptions.None)
        |> Array.map int
        |> Array.sum


  


printfn "Enter your string input"

let input = Console.ReadLine()
 
try
    let sum = Add input
    printfn $"The sum = {sum}"
with
    exp -> printfn $"Error: {exp.Message}" 