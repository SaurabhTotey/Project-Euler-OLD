namespace Problem3

//Solution for Problem 3 on Project Euler
module Problem3 =
    open Common
    open System
    
    //The large number that will have its largest factor determined
    let numberToFactor = 600851475143L
    
    //Generates the sequence of prime numbers to have all of the prime factors of the constant large number
    NumberGenerator.primeSequence.generateNumbersWhile 
        (fun (currentPrimes : ResizeArray<int>) -> 
        currentPrimes.[currentPrimes.Count - 1] 
        <= int (System.Math.Round(Math.Sqrt(numberToFactor |> Convert.ToDouble))))
    printf "%i" 
        (NumberGenerator.primeSequence.getGeneratedNumbers() 
         |> Array.findBack (fun (elem : int) -> numberToFactor % (elem |> Convert.ToInt64) = 0L))
