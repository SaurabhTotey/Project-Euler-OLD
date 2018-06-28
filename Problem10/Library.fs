namespace Problem10

//Solution for Problem 10 on Project Euler
module Problem10 =
    open Common
    
    //The upper limit for a prime number to be included in the sum
    let upperPrimeBound = 2000000
    
    //Generates all the primes below the upperPrimeBound
    NumberGenerator.primeSequence.generateNumbersWhile 
        (fun currentPrimes -> currentPrimes.[currentPrimes.Count - 1] < upperPrimeBound)
    //Sums all of primes except for the prime above the upperPrimeBound; numbers get converted to int64 to prevent overflows
    printf "%i" (NumberGenerator.primeSequence.getGeneratedNumbers().[0..(NumberGenerator.primeSequence.getGeneratedNumbers().Length - 2)]
                 |> Array.map (fun p -> int64 p)
                 |> Array.sum)
