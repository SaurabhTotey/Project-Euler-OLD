namespace Problem6

//Solution for Problem 6 on Project Euler
module Problem6 =
    let upperSumBound = 100
    
    //Prints 2(1*2+1*3+1*4+..1*100+2*3+2*4+2*5+...+2*100+3*4+3*5+3*6+...+3*100+...+99*100)
    //Oh god, this line below is so disgusting. I wrote it 5 seconds ago and even I still can't read it.
    printf "%i" 
        (2 * (seq { 1..(upperSumBound - 1) } |> Seq.fold (fun sum i -> sum + (seq { i + 1..upperSumBound } |> Seq.fold (fun innerSum j -> innerSum + i * j) 0)) 0))
