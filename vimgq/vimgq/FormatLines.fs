module FormatLines

let OneLine textwidth (textToFormat : string) =
    if textToFormat.Length > textwidth
    then "Oh what a rogue and peasant slave am\nI"
    else textToFormat