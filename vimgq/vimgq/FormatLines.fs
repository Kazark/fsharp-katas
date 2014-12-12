module FormatLines
open System

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

        endOfLine 0 textToFormat

    let splitLineAt (line : string) index =
        line.[..index].TrimEnd(), line.[index+1..].TrimStart()

    let headLineAndRest (textToFormat : string) =
        match indexForLineSplit textToFormat with
        | 0 -> textToFormat, ""
        | index ->
            let indent = readIndent textToFormat
            let line, rest = splitLineAt textToFormat index
            line, indent + rest

    let rec splitIntoLines (textToFormat : string) =
        if textToFormat.Length > textwidth
        then
            match headLineAndRest textToFormat with
            | line, "" -> [line]
            | headLine, rest -> headLine :: splitIntoLines rest
        else [textToFormat]

    splitIntoLines textToFormat
    |> String.concat "\n"
