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
        let anagrams = linesFromStdin() |> AnagramList.findAnagrams
        for line in anagrams do
            Console.WriteLine line
        0