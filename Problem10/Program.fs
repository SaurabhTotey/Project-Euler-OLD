module Program

open Common

[<EntryPoint>]
let main argv =
    let upperPrimeBound = 2000000
    NumberGenerator.primeSequence.generateNumbersWhile 
        (fun currentPrimes -> NumberGenerator.primeSequence.getCurrentNumber() < upperPrimeBound)
    printf "%i" (NumberGenerator.primeSequence.getGeneratedNumbers().[0..(NumberGenerator.primeSequence.getAmountOfNumbers() - 2)]
                 |> Array.map (fun p -> int64 p)
                 |> Array.sum)
    0
