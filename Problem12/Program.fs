module Program

open Common

[<EntryPoint>]
let main argv =
    let minNumDivisors = 500
    NumberGenerator.triangleSequence.generateNumbersWhile (fun currentSeq -> 
        let currentNum = NumberGenerator.triangleSequence.getCurrentNumber()
        (seq { 1..(int (sqrt (float currentNum)) + 1) }
         |> Seq.map (fun num -> 
                if currentNum % num = 0 then 
                    (if currentNum / num = num then 1
                     else 2)
                else 0)
         |> Seq.sum)
        < minNumDivisors)
    printf "%i" (NumberGenerator.triangleSequence.getCurrentNumber())
    0
