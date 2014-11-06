namespace Anagrams
module Word =
    let isAnagramOf (word1:string) (word2:string) =
        word1.Length = word2.Length