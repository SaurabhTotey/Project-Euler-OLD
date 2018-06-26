namespace Problem5

//Solution for Problem 5 on Project Euler
module Problem5 =
    open Common
    open System.Collections.Generic
    
    //The upperbound of the number for which all natural numbers below this must divide the answer
    let upperBound = 20
    
    //Generates all the prime numbers that will appear in the numbers from 2 to upperBound
    NumberGenerator.primeSequence.generateNumbersWhile 
        (fun (currentPrimes : ResizeArray<int>) -> currentPrimes.[currentPrimes.Count - 1] < upperBound)
    
    //Counts all of the prime factors of each number and stores the highest count for each number
    let primeCounts = new Dictionary<int, int>()
    
    for prime in NumberGenerator.primeSequence.getGeneratedNumbers().[0..NumberGenerator.primeSequence.getGeneratedNumbers().Length - 2] do
        primeCounts.[prime] <- 1
    //Initializes primeCounts with all the prime numbers and the highest number of times they are all needed
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
    //Reduces primeCounts to a multiplication of all the primes up to the power of their count
    printf "%i" (primeCounts
                 |> Seq.map (fun (KeyValue(k, v)) -> k)
                 |> Seq.fold (fun total current -> total * pown current primeCounts.[current]) 1)
