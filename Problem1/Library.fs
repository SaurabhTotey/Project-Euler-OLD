namespace Problem1

//Solution for Problem 1 on Project Euler
module Problem1 =
    //The numbers that will divide whatever gets added to the sum
    let divisors = [| 3; 5 |]
    //The end point (exclusive)
    let max = 1000
    
    //Prints the result of the sum of filtering out each number between 1 and max such that they are divisible by the divisor
    printf "%i" (seq { 1..max - 1 }
                 |> Seq.filter (fun i -> divisors |> Array.exists (fun divisor -> i % divisor = 0))
                 |> Seq.sum)
