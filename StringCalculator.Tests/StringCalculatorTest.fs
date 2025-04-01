module StringCalculatorTest

open System
open Calculator
open ExceptionCustom
open Xunit

[<Theory>]
[<InlineData("", 0)>]
[<InlineData("2", 2)>]
[<InlineData("3,4", 7)>]
[<InlineData("5,7\n3", 15)>]
[<InlineData("//;\n2", 2)>]
[<InlineData("//[;]\n2,3\n4;5", 14)>]
[<InlineData("//[;*&]\n2,3\n4;*&5 ", 14)>]
[<InlineData("//[;*&][(((]\n2,3\n4;*&5(((6", 20)>]
[<InlineData("//[;*&][(((]\n2,3\n4;*&5(((6000", 14)>]

let ``Add Numbers Should Return Expected Sum`` (input, expected) =
   
    // Act
    let result = add input
    // Assert
    Assert.Equal(result, expected)

[<Theory>]
[<InlineData("//[;*&][(((]\n2,3\n4;*&5(((-6 ")>]

let ``Add With Negative Numbers Should Throws InvalidNegativeNumbers Exception`` input =
    // Act && Assert
    Assert.Throws<InvalidNegativeNumbersException>(fun() -> add input |> ignore)

[<Theory>]
[<InlineData("//[;*&][(((]\n2,3\n4;*&5((6000")>]
[<InlineData("1,\n")>]

let ``Add With Wrong Format Should Throws Wrong Format Exception`` input =
    // Act && Assert
    Assert.Throws<FormatException>(fun() -> add input |> ignore)
