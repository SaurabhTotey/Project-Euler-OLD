module Program

exception BreakException

[<EntryPoint>]
let main argv =
    try 
        for a in 1..512 do
            for b in a + 1..512 do
                let c = sqrt (float ((pown a 2) + (pown b 2)))
                if float (a) + float (b) + c = 1000.0 then 
                    printfn "%i" (a * b * (int c))
                    raise BreakException
    with BreakException -> ()
    0
