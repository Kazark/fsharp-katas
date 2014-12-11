module FormatLines

let rec readIndent (indent : string) (text : string) =
    match text.[0] with
    | ' ' -> readIndent (sprintf "%s%c" indent text.[0]) (text.[1..])
    | _ -> indent

let OneLine textwidth (textToFormat : string) =
    if textToFormat.Length > textwidth
    then
        let indent = readIndent "" textToFormat
        sprintf "%s\n%s%s" (textToFormat.[..textwidth-1].TrimEnd()) indent textToFormat.[textwidth..]
    else textToFormat