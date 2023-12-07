let makeModules (file: string) : int list =
    System.IO.File.ReadLines(file) |> Seq.map int |> Seq.toList

let gas (aModule: int) : int = aModule / 3 - 2

let answerPartA (file: string) : int =
    makeModules file |> List.map gas |> List.sum

printfn " Part A: %i" (answerPartA "/home/eric/fsharp-projects/Day01/Day01/day01.txt")

// answerPartA("day01/day01.txt");;
// val it: int = 3337766

[<TailCall>]
let gasPlus (outerModule: int) : int =
    let rec loop (innerModule: int) (acc: int) : int =
        let newGas = gas innerModule

        match newGas with
        | newGas when newGas <= 0 -> acc
        | _ -> loop newGas (acc + newGas)

    loop outerModule 0

let answerPartB (file: string) : int =
    makeModules file |> List.map gasPlus |> List.sum



printfn " Part B: %i" (answerPartB "/home/eric/fsharp-projects/Day01/Day01/day01.txt")

// answerPartB("day01/day01.txt");;
// val it: int = 5003788
