// Learn more about F# at http://fsharp.org

open System
open RangeClass

[<EntryPoint>]
let main argv =

    //tests 
    
    //contains
    let mutable range = new RangeClass("[2,6)")
    if range.contains [2;4] then printfn "contains" else printfn "does not contain"
    if range.contains [-1; 1; 6; 10] then printfn "contains" else printfn "does not contain"

    //getAllPoints
    printfn "%A" range.getAllPoints

    //containsRange
    range <- new RangeClass("[2,5)")
    let mutable testRange = new RangeClass("[7,10)")
    if range.containsRange testRange then printfn "contains" else printfn "does not contain"

    testRange <- new RangeClass("[3,10)")
    if range.containsRange testRange then printfn "contains" else printfn "does not contain"

    range <- new RangeClass("[3,5)")
    testRange <- new RangeClass("[2,10)")
    if range.containsRange testRange then printfn "contains" else printfn "does not contain"

    range <- new RangeClass("[2,10)")
    testRange <- new RangeClass("[3,5]")
    if range.containsRange testRange then printfn "contains" else printfn "does not contain"

    range <- new RangeClass("[3,5]")
    testRange <- new RangeClass("[3,5]")
    if range.containsRange testRange then printfn "contains" else printfn "does not contain"

    //endPoints
    range <- new RangeClass("[2,6)")
    printfn "%A" range.endPoints

    range <- new RangeClass("[2,6]")
    printfn "%A" range.endPoints

    range <- new RangeClass("(2,6)")
    printfn "%A" range.endPoints

    range <- new RangeClass("(2,6]")
    printfn "%A" range.endPoints

    //overlapsRange
    range <- new RangeClass("[2,5)")
    testRange <- new RangeClass("[7,10)")
    if range.overlapsRange testRange then printfn "overlaps" else printfn "does not overlap"

    range <- new RangeClass("[2,10)")
    testRange <- new RangeClass("[3,5]")
    if range.overlapsRange testRange then printfn "overlaps" else printfn "does not overlap"

    range <- new RangeClass("[2,5)")
    testRange <- new RangeClass("[3,10)")
    if range.overlapsRange testRange then printfn "overlaps" else printfn "does not overlap"

    range <- new RangeClass("[3,5)")
    testRange <- new RangeClass("[2,10)")
    if range.overlapsRange testRange then printfn "overlaps" else printfn "does not overlap"

    //equals
    range <- new RangeClass("[3,5)")
    testRange <- new RangeClass("[3,5)")
    if range.equals testRange then printfn "equals" else printfn "not equal"

    range <- new RangeClass("[2,10)")
    testRange <- new RangeClass("[3,5)")
    if range.equals testRange then printfn "equals" else printfn "not equal"

    range <- new RangeClass("[2,5)")
    testRange <- new RangeClass("[3,10)")
    if range.equals testRange then printfn "equals" else printfn "not equal"

    range <- new RangeClass("[3,5)")
    testRange <- new RangeClass("[2,10)")
    if range.equals testRange then printfn "equals" else printfn "not equal"

    0