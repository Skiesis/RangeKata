module RangeClass

open System.Text.RegularExpressions
exception Error of string
let rx = Regex(@"(\(|\[)\d+\,\d+(\)|\])", RegexOptions.Compiled)

type RangeClass(range: string) =
   
    let mutable rangeList = Unchecked.defaultof<List<int>>

    do
        try
            let matched = rx.IsMatch(range)
            if matched then 
                let mutable rangeString = range
                rangeString <- rangeString.Remove(0, 1)
                rangeString <- rangeString.Remove(((String.length rangeString)-1), 1)

                let rangePoints = rangeString.Split ','

                let mutable startP = rangePoints[0] |> string |> int
                let mutable endP = rangePoints[1] |> string |> int
           
                if range[0] = '(' then startP <- startP+1 
                if range[((String.length range)-1)] = ')' then endP <- endP-1 

                rangeList <- [startP..endP]
            else raise(Error("Range is not valid"))
        with
        | Error(str) -> printfn "%s" str


    member this.contains(numList: List<int>) : bool =
        let mutable result = true

        let sortedList = List.sort numList

        if sortedList[0] < rangeList[0] then result <- false
        if sortedList[(List.length sortedList)-1] > rangeList[(List.length rangeList)-1] then result <- false

        result

    member this.getAllPoints : List<int> = 
        rangeList

    member this.containsRange(range: RangeClass) : bool =
        this.contains(range.getAllPoints)

    member this.endPoints : List<int> =
        [rangeList[0]; rangeList[(List.length rangeList)-1]]

    member this.overlapsRange(range: RangeClass) : bool =        
        let pRangeList = range.getAllPoints
        let mutable result = true

        if pRangeList[(List.length pRangeList)-1] < rangeList[0] then result <- false
        if rangeList[(List.length rangeList)-1] < pRangeList[0] then result <- false

        result

    member this.equals(range: RangeClass) : bool =
        range.getAllPoints = rangeList