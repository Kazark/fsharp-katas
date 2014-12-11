module FormatLines
open System

let rec readIndent (text : string) =
    match text.[0] with
    | ' ' -> " " + readIndent (text.[1..])
    | _ -> ""

let OneLine textwidth (textToFormat : string) =
    let rec indexForLineSplit (characters : char list) =
        let rec splitWordAt (characters : char list) index expectSpace =
            match expectSpace, characters with
            | _, [] -> index
            | false, ' ' :: _ -> index
            | true, ' ' :: textTail -> splitWordAt textTail (index + 1) expectSpace
            | _, _ :: textTail -> splitWordAt textTail (index + 1) false
        0 // TODO

    let headLineAndRest (textToFormat : string) =
        let indent = readIndent textToFormat
        textToFormat.[..textwidth-1].TrimEnd(), (indent + textToFormat.[textwidth..].TrimStart())

    let rec oneLineAsLines (textToFormat : string) =
        if textToFormat.Length > textwidth
        then
            let headLine, rest = headLineAndRest textToFormat
            headLine :: oneLineAsLines rest
        else [textToFormat]

    oneLineAsLines textToFormat
    |> String.concat "\n"
