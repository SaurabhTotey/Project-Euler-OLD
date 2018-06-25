namespace Common

//A collection of what a number generator is as well as useful number generators
module NumberGenerator =
    (*
     * A utility type that generates and stores a sequence of numbers
     *)
    type NumberGenerator(initialNumbers : ResizeArray<int>, generateNumber : ResizeArray<int> -> int) =
        //The currently generated numbers
        member private this.numbers = initialNumbers
        //A method that will generate a new number given the current set of numbers
        member this.generateNumber() = this.numbers.Add(generateNumber this.numbers)
        
        //A convenience method that will continually generate numbers until the condition given has been met
        member this.generateNumbersWhile (predicate : ResizeArray<int> -> bool) =
            while predicate (this.numbers) do
                this.generateNumber() |> ignore
        
        //A getter for all the currently generated numbers
        member this.getGeneratedNumbers() = this.numbers.ToArray()
        //A convenience method that will get the number at the given index
        member this.getNumberAt (index : int) = this.numbers.[index]
    
    let fibonacciSequence =
        new NumberGenerator(ResizeArray [ 1; 2 ], 
                            fun (currentSeq : ResizeArray<int>) -> 
                                currentSeq.[currentSeq.Count - 1] + currentSeq.[currentSeq.Count - 2])
