namespace Anagrams
open System

module Word =
    let isAnagramOf (word1:string) (word2:string) =
        let sortString (s:string) = Seq.sort s |> String.Concat
        sortString word1 = sortString word2

module WordList =
    let findAnagrams (lines : string seq) =
        []