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
        
        //A convenience method that will continually generate numbers while the condition given is being met
        member this.generateNumbersWhile (predicate : ResizeArray<int> -> bool) =
            while predicate (this.numbers) do
                this.generateNumber() |> ignore
        
        //A getter for all the currently generated numbers
        member this.getGeneratedNumbers() = this.numbers.ToArray()
        
        //A convenience method that will get the number at the given index
        member this.getNumberAt (index : int) =
            this.generateNumbersWhile (fun currentSeq -> currentSeq.Count - 1 < index)
            this.numbers.[index]
        
        //A convenience method that gets the most recently generated number
        member this.getCurrentNumber() = this.numbers.[this.numbers.Count - 1]
        //A convenience method that gets the amount of generated numbers
        member this.getAmountOfNumbers() = this.numbers.Count
    
    //Number Generator for the Fibonacci Sequence
    let fibonacciSequence =
        new NumberGenerator(ResizeArray [ 1; 2 ], 
                            fun (currentSeq : ResizeArray<int>) -> 
                                currentSeq.[currentSeq.Count - 1] + currentSeq.[currentSeq.Count - 2])
    
    //Number Generator for a sequence of prime numbers
    let primeSequence =
        new NumberGenerator(ResizeArray [ 2; 3 ], 
                            fun (currentSeq : ResizeArray<int>) -> 
                                (let mutable current = currentSeq.[currentSeq.Count - 1] + 2
                                 while currentSeq.Exists(fun elem -> current % elem = 0) do
                                     current <- current + 2
                                 current))
    
    //Number Generator for the sequence of triangle numbers
    let triangleSequence =
        new NumberGenerator(ResizeArray [ 1 ], 
                            fun (currentSeq : ResizeArray<int>) -> 
                                currentSeq.[currentSeq.Count - 1] + currentSeq.Count + 1)
    
    //Function that returns a Number Generator for a Collatz sequence for the given number
    let collatzSequenceFor (starting : int) =
        new NumberGenerator(ResizeArray [ starting ], 
                            fun (currentSeq : ResizeArray<int>) -> 
                                let currentNum = currentSeq.[currentSeq.Count - 1]
                                if currentNum % 2 = 0 then currentNum / 2
                                else currentNum * 3 + 1)
