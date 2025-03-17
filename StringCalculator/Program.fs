open System

let Add input =
    match input with
    | "" -> 0
    | _ -> 
        let delimiter, numbers =
            if input.StartsWith("//") then
                let line = input.IndexOf("\\n")
                let delimiter = input.Substring(2, line - 2)
                let numbers = input.Substring(line + 2)
                delimiter, numbers
            else
                ",", input  

        let numbersPart = numbers.Split([| ","; "\\n"; delimiter |], StringSplitOptions.None)
        let intNumbers = numbersPart |> Array.map int
        let negativeNums = intNumbers |> Array.filter (fun n -> n < 0)
        
        if (negativeNums.Length > 0) then
            failwith("Negative numbers not valid")
        let numbersAllowed = intNumbers |> Array.filter(fun n -> n < 1000)
        numbersAllowed |> Array.sum


printfn "Enter your string input"

let input = Console.ReadLine()
 
try
    let sum = Add input
    printfn $"The sum = {sum}"
with
    exp -> printfn $"Error: {exp.Message}" 