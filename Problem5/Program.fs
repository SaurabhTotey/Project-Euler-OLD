module Program

open Common
open System.Collections.Generic

[<EntryPoint>]
let main argv =
    let upperBound = 20
    NumberGenerator.primeSequence.generateNumbersWhile 
        (fun (currentPrimes : ResizeArray<int>) -> NumberGenerator.primeSequence.getCurrentNumber() < upperBound)
    let primeCounts = new Dictionary<int, int>()
    for prime in NumberGenerator.primeSequence.getGeneratedNumbers().[0..NumberGenerator.primeSequence.getGeneratedNumbers().Length - 2] do
        primeCounts.[prime] <- 1
    seq { 1..upperBound }
    |> Seq.filter (fun number -> not (NumberGenerator.primeSequence.getGeneratedNumbers() |> Array.contains number))
    |> Seq.iter (fun number -> 
           for KeyValue(prime, count) in new Dictionary<int, int>(primeCounts) do
               let mutable localNumber = number
               let mutable localCount = 0
               while localNumber % prime = 0 do
                   localCount <- localCount + 1
                   localNumber <- localNumber / prime
               if localCount > count then primeCounts.[prime] <- localCount)
    printf "%i" (primeCounts
                 |> Seq.map (fun (KeyValue(k, v)) -> k)
                 |> Seq.fold (fun total current -> total * pown current primeCounts.[current]) 1)
    0
