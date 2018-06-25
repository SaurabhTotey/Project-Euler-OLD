namespace Problem2

//Solution for Problem 2 on Project Euler
module Problem2 =
    open Common
    
    NumberGenerator.fibonacciSequence.generateNumbersWhile 
        (fun (currentNumbers : ResizeArray<int>) -> currentNumbers.[currentNumbers.Count - 1] < 4000000)
    printf "%i" (NumberGenerator.fibonacciSequence.getGeneratedNumbers()
                 |> Array.filter (fun fibNum -> fibNum % 2 = 0 && fibNum < 4000000)
                 |> Array.sum)
