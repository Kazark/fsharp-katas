namespace Anagrams
open System

module AnagramList = 
    let empty =
        Map.empty<string, list<string>>
    let add _ _ = empty
    let format _ = "foo\n"
