module Program

[<EntryPoint>]
let main argv =
    let upperSumBound = 100
    printf "%i" 
        (2 
         * (seq { 1..(upperSumBound - 1) } 
            |> Seq.fold 
                   (fun sum i -> sum + (seq { i + 1..upperSumBound } |> Seq.fold (fun innerSum j -> innerSum + i * j) 0)) 
                   0))
    0
