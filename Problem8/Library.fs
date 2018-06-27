namespace Problem8

//Solution for Problem 8 on Project Euler
module Problem8 =
    open System
    
    //The product is found for numDigitsToMultiply adjacent digits
    let numDigitsToMultiply = 13
    //A string of the number with all the digits to find which 13 consecutive digits have the largest product
    let longNum =
        "73167176531330624919225119674426574742355349194934
                   96983520312774506326239578318016984801869478851843
                   85861560789112949495459501737958331952853208805511
                   12540698747158523863050715693290963295227443043557
                   66896648950445244523161731856403098711121722383113
                   62229893423380308135336276614282806444486645238749
                   30358907296290491560440772390713810515859307960866
                   70172427121883998797908792274921901699720888093776
                   65727333001053367881220235421809751254540594752243
                   52584907711670556013604839586446706324415722155397
                   53697817977846174064955149290862569321978468622482
                   83972241375657056057490261407972968652414535100474
                   82166370484403199890008895243450658541227588666881
                   16427171479924442928230863465674813919123162824586
                   17866458359124566529476545682848912883142607690042
                   24219022671055626321111109370544217506941658960408
                   07198403850962455444362981230987879927244284909188
                   84580156166097919133875499200524063689912560717606
                   05886116467109405077541002256983155200055935729725
                   71636269561882670428252483600823257530420752963450" 
        |> String.filter (fun letter -> letter |> Char.IsDigit)
    
    //A function that gets the largest multiple of numDigitsToMultiply adjacent digits
    let getLargestAdjacentMultiple() =
        //A recursive function that finds a multiple at an index: if it is larger than what has been found, it will go to the next index with the largest multiple
        let rec getMultipleAt (index : int, largestMultiple : int64) =
            if index + numDigitsToMultiply > longNum.Length then largestMultiple
            else 
                let digits = longNum.Substring(index, numDigitsToMultiply)
                
                let multiple =
                    digits
                    |> Seq.map (fun digit -> int64 digit - int64 '0')
                    |> Seq.fold (fun multiple digit -> multiple * digit) 1L
                getMultipleAt (index + 1, 
                               if multiple > largestMultiple then multiple
                               else largestMultiple)
        getMultipleAt (0, 0L)
    
    printf "%i" (getLargestAdjacentMultiple())
