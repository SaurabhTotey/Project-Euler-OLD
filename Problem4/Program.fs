module Program

open System

exception BreakException

[<EntryPoint>]
let main argv =
    let isPalindrome (number : int) =
        let str =
            string (number)
            |> seq
            |> Seq.toList
        str = (str |> List.rev)
    
    let mutable palindrome = 0
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
    0
