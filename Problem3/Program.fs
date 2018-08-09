module Program

open Common
open System

[<EntryPoint>]
let main argv =
    let numberToFactor = 600851475143L
    NumberGenerator.primeSequence.generateNumbersWhile 
        (fun (currentPrimes : ResizeArray<int>) -> 
        NumberGenerator.primeSequence.getCurrentNumber() 
        <= int (System.Math.Round(Math.Sqrt(numberToFactor |> Convert.ToDouble))))
    printf "%i" 
        (NumberGenerator.primeSequence.getGeneratedNumbers() 
         |> Array.findBack (fun (elem : int) -> numberToFactor % (elem |> Convert.ToInt64) = 0L))
    0
