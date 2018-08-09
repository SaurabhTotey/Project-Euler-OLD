module Program

open Common

[<EntryPoint>]
let main argv =
    let upperBound = 4000000
    NumberGenerator.fibonacciSequence.generateNumbersWhile 
        (fun (currentNumbers : ResizeArray<int>) -> NumberGenerator.fibonacciSequence.getCurrentNumber() < upperBound)
    printf "%i" (NumberGenerator.fibonacciSequence.getGeneratedNumbers()
                 |> Array.filter (fun fibNum -> fibNum % 2 = 0 && fibNum < upperBound)
                 |> Array.sum)
    0
