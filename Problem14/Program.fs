module Program

[<EntryPoint>]
let main argv =
    let highestNumber = 1000000L
    
    let getLengthOfCollatzSequenceFor start =
        let mutable count = 1L
        let mutable current = start
        while current > 1L do
            current <- if current % 2L = 0L then current / 2L
                       else 3L * current + 1L
            count <- count + 1L
        count
    printf "%i" (seq { 1L..highestNumber } |> Seq.maxBy getLengthOfCollatzSequenceFor)
    0
