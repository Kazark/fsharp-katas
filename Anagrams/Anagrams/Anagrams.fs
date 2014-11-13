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

    let format (anagramsMap : AnagramsMap) =
        let listsOfAnagrams =
            Map.toSeq anagramsMap |> Seq.map snd
        let formatLine anagrams = 
            Seq.sort anagrams |> String.concat " "
        listsOfAnagrams 
        |> Seq.map formatLine
        |> Seq.sort
        |> String.concat "\n"
