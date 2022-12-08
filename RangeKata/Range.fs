module RangeClass

open System.Text.RegularExpressions
let rx = Regex(@"(\(|\[)\d+\,\d+(\)|\])", RegexOptions.Compiled)
exception Error of string

type RangeClass(range: string) =

    let mutable startPoint = Unchecked.defaultof<int>
    let mutable endPoint = Unchecked.defaultof<int>
    let mutable rangeList = Unchecked.defaultof<List<int>>
    do 
        try
            let matched = rx.IsMatch(range)
            if matched then 
                if endPoint < startPoint then raise(Error("Range is not valid."))

                let splitted = Seq.toList range

                let mutable rangeStr = range
                rangeStr <- rangeStr.Remove(0, 1)
                rangeStr <- rangeStr.Remove(((String.length rangeStr) - 1), 1)

                let rangesPoints = rangeStr.Split ','

                let startP = rangesPoints[0] |> string |> int
                let endP = rangesPoints[1] |> string |> int

                if splitted[0] = '[' then 
                    startPoint <- startP
                else startPoint <- startP+1 
                if splitted[(List.length splitted)-1] = ']' then 
                    endPoint <- endP
                else endPoint <- endP-1
            
                rangeList <- [startPoint..endPoint]
            else raise(Error("Range is not valid"))
        with
            | Error(str) -> printfn "%s" str

    member this.contains(numList: List<int>) : bool =
        let mutable result = true
        let sortedList = List.sort numList
        
        if sortedList[0] < rangeList[0] then result <- false
        if sortedList[(List.length sortedList)-1] > rangeList[(List.length rangeList)-1] then result <- false

        result

    member this.getAllPoints =
        rangeList

    member this.containsRange(range: RangeClass) = 
        this.contains(range.getAllPoints)

    member this.endPoints =
        [rangeList[0]; rangeList[(List.length rangeList)-1]]

    member this.overlapsRange(range: RangeClass) =
        let pRangeList = range.getAllPoints
        if(pRangeList[0] < rangeList[0] || pRangeList[(List.length pRangeList)-1] > rangeList[(List.length rangeList)-1]) 
        then false
        else true

    member this.equals(range: RangeClass) =
        if range.getAllPoints = rangeList then true
        else false