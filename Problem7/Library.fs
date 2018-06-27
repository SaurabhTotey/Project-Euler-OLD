namespace Problem7

//Solution for Problem 7 on Project Euler
module Problem7 =
    open Common
    
    //The index of the prime number to find
    let primeIndex = 10001
    
    //Generates primes until primeIndex prime numbers have been generated
    NumberGenerator.primeSequence.generateNumbersWhile (fun currentPrimes -> currentPrimes.Count < primeIndex)
    //Prints the last generated prime number
    printf "%i" (NumberGenerator.primeSequence.getGeneratedNumbers().[primeIndex - 1])
