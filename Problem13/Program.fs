module Program

open System.IO

[<EntryPoint>]
let main argv =
    let numberOfNumbers = 100
    let digitsPerNumber = 50
    let outputSize = 10
    
    let arrayOfDigits =
        File.ReadAllLines("Numbers.txt")
        |> Seq.map (fun numberText -> numberText.ToCharArray() |> Array.map (fun digit -> int digit - int '0'))
        |> Seq.toArray
    
    let numbersSum =
        arrayOfDigits 
        |> Array.fold 
               (fun acumulatedSum currentNumber -> 
               acumulatedSum |> Array.mapi (fun index acumulation -> acumulation + currentNumber.[index])) 
               (Array.create digitsPerNumber 0)
    let digitsOfSum = ResizeArray(numbersSum |> Array.rev)
    let mutable index = 0
    while index < digitsOfSum.Count do
        let currentNum = digitsOfSum.[index]
        if currentNum > 10 then 
            if index + 1 >= digitsOfSum.Count then digitsOfSum.Add 0
            digitsOfSum.[index + 1] <- digitsOfSum.[index + 1] + currentNum / 10
            digitsOfSum.[index] <- currentNum % 10
        index <- index + 1
    printf "%s" ((digitsOfSum
                  |> Seq.toArray
                  |> Array.rev).[0..outputSize - 1]
                 |> Array.fold (fun output digit -> output + digit.ToString()) "")
    0
