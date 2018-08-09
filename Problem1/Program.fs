module Program

[<EntryPoint>]
let main argv =
    let divisors = [| 3; 5 |]
    let max = 1000
    printf "%i" (seq { 1..max - 1 }
                 |> Seq.filter (fun i -> divisors |> Array.exists (fun divisor -> i % divisor = 0))
                 |> Seq.sum)
    0
