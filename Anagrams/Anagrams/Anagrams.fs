namespace Anagrams
open System

module AnagramList = 
    type AnagramsMap = Map<string, list<string>>

    let empty = Map.empty<string, list<string>>

    let add (word : string) (anagramsMap : AnagramsMap) =
        let sortedWord = Seq.sort word |> String.Concat
        let anagramsForWord =
            if anagramsMap.ContainsKey sortedWord then
                List.Cons(word, anagramsMap.Item sortedWord)
            else
                [word]
        anagramsMap.Add(sortedWord, anagramsForWord)

    let addTo (anagramsMap : AnagramsMap) (word : string) =
        add word anagramsMap 

    let format (anagramsMap : AnagramsMap) =
        let listsOfAnagrams =
            Map.toSeq anagramsMap |> Seq.map snd
        let formatLine anagrams = 
            Seq.sort anagrams |> String.concat " "
        listsOfAnagrams 
        |> Seq.map formatLine
        |> String.concat "\n"

    let findAnagrams lines =
        lines
        |> Seq.fold addTo empty
        |> format