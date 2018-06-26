namespace Problem4

//Solution for Problem 4 on Project Euler
module Problem4 =
    open System
    
    //Returns whether the given number is a palindrome or not
    let isPalindrome (number : int) =
        let str =
            string (number)
            |> seq
            |> Seq.toList
        str = (str |> List.rev)
    
    //The current palindrome
    let mutable palindrome = 0
    
    //A custom exception to implement breaking in for loops
    exception BreakException
    
    //Iterates through all 3 digit numbers to see if they are a larger palindrome than what is currently stored
    for i in seq { 999..-1..1 } do
        try 
            for j in seq { 999..-1..1 } do
                let multiple = i * j
                if multiple < palindrome then raise BreakException
                if multiple
                   |> isPalindrome
                   && multiple > palindrome then palindrome <- multiple
        with BreakException -> ()
    printf "%i" palindrome
