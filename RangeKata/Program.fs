// Learn more about F# at http://fsharp.org

open System
open RangeClass

[<EntryPoint>]
let main argv =
    let range = new RangeClass "[2,5)"
    if range.contains [3; 4; 5] then printfn "Contains" else printfn "Does not contain"
    let rangeTest = new RangeClass "[2,4]"
    if range.overlapsRange rangeTest then printfn "overlaps" else printfn "does not overlap"
    if range.equals rangeTest then printfn "equals" else printfn "not equal"
    printfn "%A" range.getAllPoints 
    printfn "Hello World from F#!"
    0 // return an integer exit code
