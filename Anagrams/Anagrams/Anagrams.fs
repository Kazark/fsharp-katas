namespace Anagrams
open System

module AnagramList = 
    let empty =
        Map.empty<string, list<string>>
    let add word (anagrams : Map<string, list<string>>) =
        anagrams.Add(word, [word])
    let format (anagrams : Map<string, list<string>>) =
        Map.toSeq anagrams
        |> Seq.map snd
        |> Seq.map List.head
        |> String.concat "\n"
