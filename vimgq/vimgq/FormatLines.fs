module FormatLines

let OneLine textwidth (textToFormat : string) =
    if textToFormat.Length > textwidth
    then sprintf "%s\n%s" (textToFormat.[..textwidth-1].TrimEnd()) textToFormat.[textwidth..]
    else textToFormat