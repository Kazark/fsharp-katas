namespace Anagrams
open System
module Main =
    let linesFromStdin() =
        Seq.unfold(fun line ->
            if line = null then
                None
            else
                Some(line,Console.ReadLine())
        )(Console.ReadLine())

    [<EntryPoint>]
    let main _ = 
        linesFromStdin() |> AnagramList.findAnagrams |> Console.Write
        0
