namespace Anagrams
open System.IO

module IO =
    (* Taken and modified from
    http://geekswithblogs.net/akraus1/archive/2010/07/06/140788.aspx *)
    let readLines filepath =
        let reader = File.OpenText(filepath)
        Seq.unfold(fun line ->
            if line = null then
                reader.Close()
                None
            else
                Some(line,reader.ReadLine())
        )(reader.ReadLine())