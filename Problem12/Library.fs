namespace Problem12

//Solution for Problem 12 on Project Euler
module Problem12 =
    open Common
    
    //How many divisors the triangle number needs to have
    let minNumDivisors = 500
    
    //Generates triangle numbers until there is a triangle number with at least minNumDivisors divisors
    NumberGenerator.triangleSequence.generateNumbersWhile (fun currentSeq -> 
        let currentNum = currentSeq.[currentSeq.Count - 1]
        (seq { 1..(int (sqrt (float currentNum)) + 1) }
                 |> Seq.map (fun num -> if currentNum % num = 0 then (if currentNum / num = num then 1 else 2) else 0)
                 |> Seq.sum) < minNumDivisors)
    printf "%i" (NumberGenerator.triangleSequence.getCurrentNumber())
