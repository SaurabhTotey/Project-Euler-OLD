module Program

[<EntryPoint>]
let main argv =
    let gridSize = 20
    
    let getNumberOfPathsForGridOfSize gridSize =
        let rec innerGetNumberOfPaths xLoc yLoc count =
            if xLoc = gridSize && yLoc = gridSize then count + 1L
            else if xLoc = gridSize then innerGetNumberOfPaths xLoc (yLoc + 1) count
            else if yLoc = gridSize then innerGetNumberOfPaths (xLoc + 1) yLoc count
            else (innerGetNumberOfPaths (xLoc + 1) yLoc count) + (innerGetNumberOfPaths xLoc (yLoc + 1) count)
        innerGetNumberOfPaths 0 0 0L
    printf "%i" (getNumberOfPathsForGridOfSize gridSize)
    0
