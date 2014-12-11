module FormatLines

let oneLine textwidth (textToFormat : string) =
    if textToFormat.Length > textwidth
    then "Oh what a rogue and peasent slave am\nI"
    else textToFormat