module FormatLines
open System

let rec readIndent (text : string) =
    match text.[0] with
    | ' ' -> " " + readIndent (text.[1..])
    | _ -> ""

let OneLine textwidth (textToFormat : string) =
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
        endOfLine 0 textToFormat

    let headLineAndRest (textToFormat : string) =
        let indent = readIndent textToFormat
        let index = indexForLineSplit textToFormat
        textToFormat.[..index].TrimEnd(), (indent + textToFormat.[index+1..].TrimStart())

    let rec oneLineAsLines (textToFormat : string) =
        if textToFormat.Length > textwidth
        then
            let headLine, rest = headLineAndRest textToFormat
            headLine :: oneLineAsLines rest
        else [textToFormat]

    oneLineAsLines textToFormat
    |> String.concat "\n"
