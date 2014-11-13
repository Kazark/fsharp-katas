namespace Anagrams
open System

module AnagramList = 
    let empty =
        Map.empty<string, list<string>>
    let add (word : string) (anagrams : Map<string, list<string>>) =
        let sortedWord = Seq.sort word |> String.Concat
        let anagramsForWord =
            if anagrams.ContainsKey sortedWord then
                List.Cons(word, anagrams.Item sortedWord)
            else
                [word]
        anagrams.Add(sortedWord, anagramsForWord)
    let format (anagrams : Map<string, list<string>>) =
        Map.toSeq anagrams
        |> Seq.map snd
        |> Seq.map (fun strlist -> String.concat " " strlist)
        |> String.concat "\n"
