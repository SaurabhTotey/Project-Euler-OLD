namespace Problem9

//Solution for Problem 9 on Project Euler
module Problem9 =
    //Defines a custom exception to break out of a loop
    exception BreakException
    //512 is the maximum possible sidelength if the perimeter is 1000 and the angles happened to be pi/4, pi/4, and pi/2
    try
        //Iterates until finds the answer: break exception is thrown once answer is found to stop unnecessary iterations
        //This solution with for loops is kinda disgusting and can definitely be reworked
        for a in 1 .. 512 do
            for b in a+1 .. 512 do
                let c = sqrt (float ((pown a 2) + (pown b 2)))
                if float(a) + float(b) + c = 1000.0 then
                    //Commented out below is the pretty printed answer
                    //printfn "%i * %i * %i = %i" a b (int c) (a * b * (int c))
                    printfn "%i" (a * b * (int c))
                    raise BreakException
    with BreakException -> ()