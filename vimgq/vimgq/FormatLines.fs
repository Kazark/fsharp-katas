module FormatLines
open System

let rec readIndent (indent : string) (text : string) =
    match text.[0] with
    | ' ' -> readIndent (sprintf "%s%c" indent text.[0]) (text.[1..])
    | _ -> indent

let OneLine textwidth (textToFormat : string) =
    let rec oneLineAsLines (textToFormat : string) =
        if textToFormat.Length > textwidth
        then
            let indent = readIndent "" textToFormat
            textToFormat.[..textwidth-1].TrimEnd() :: oneLineAsLines (indent + textToFormat.[textwidth..].TrimStart())
        else [textToFormat]

    oneLineAsLines textToFormat
    |> String.concat "\n"
