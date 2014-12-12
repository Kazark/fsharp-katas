module FormatLines
open System

type SplitIndex = DoNotSplit | Index of int
let toSplitIndex i =
    match i with
    | 0 -> DoNotSplit
    | x -> Index x

let OneLine textwidth (textToFormat : string) =
    let rec readIndent (text : string) =
        match text.[0] with
        | ' ' -> " " + readIndent (text.[1..])
        | _ -> ""

    let indexForLineSplit (characters : string) =
        let rec endOfNextWord (characters : char list) index expectSpace =
            match expectSpace, characters with
            | _, [] -> index
            | false, ' ' :: _ -> index
            | true, ' ' :: textTail -> endOfNextWord textTail (index + 1) expectSpace
            | _, _ :: textTail -> endOfNextWord textTail (index + 1) false

        let rec endOfLine lastIndex (characters : string) =
            let index = endOfNextWord (List.ofSeq characters) lastIndex true
            if index > textwidth || index > textToFormat.Length
            then lastIndex
            else endOfLine index textToFormat.[index..]

        if characters.Length > textwidth
        then endOfLine 0 textToFormat |> toSplitIndex
        else DoNotSplit

    let splitLineAt (line : string) index =
        line.[..index].TrimEnd(), line.[index+1..].TrimStart()

    let headLineAndRest (textToFormat : string) =
        match indexForLineSplit textToFormat with
        | DoNotSplit -> textToFormat, ""
        | Index index ->
            let indent = readIndent textToFormat
            let line, rest = splitLineAt textToFormat index
            line, indent + rest

    let rec splitIntoLines (textToFormat : string) =
        match headLineAndRest textToFormat with
        | line, "" -> [line]
        | headLine, rest -> headLine :: splitIntoLines rest

    splitIntoLines textToFormat
    |> String.concat "\n"
