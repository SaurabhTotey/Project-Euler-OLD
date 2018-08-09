module Program

open Common

[<EntryPoint>]
let main argv =
    let primeIndex = 10001
    NumberGenerator.primeSequence.generateNumbersWhile (fun currentPrimes -> currentPrimes.Count < primeIndex)
    printf "%i" (NumberGenerator.primeSequence.getCurrentNumber())
    0
