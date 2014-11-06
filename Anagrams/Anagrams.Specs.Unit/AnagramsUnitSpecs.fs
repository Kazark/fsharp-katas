namespace Anagrams.Specs.Unit
open FSpec.Dsl
open FSpec.Matchers

module WordSpecs =
    open Anagrams.Word
    let specs =
        describe "Word module" [
            describe "Two words of different lengths" [
                it "should not be anagrams of one another" <| fun _ ->
                    "aaa" |> isAnagramOf "aa" |> should (equal false)
            ]
            describe "'no' and 'on'" [
                it "should be anagrams of one another" <| fun _ ->
                    "no" |> isAnagramOf "on" |> should (equal true)
            ]
            describe "'foo' and 'bar'" [
                it "should be anagrams of one another" <| fun _ ->
                    "foo" |> isAnagramOf "bar" |> should (equal false)
            ]
        ]

module WordListSpecs =
    open Anagrams
    let specs =
        describe "WordList module" [
            describe "Finding the anagrams in a word list" [
                context "of just one word" [
                    it "should output just one word" <| fun _ ->
                        WordList.findAnagrams [ "alpha" ]
                        |> Seq.length
                        |> should (equal 0)
                ]
            ]
        ]

[<MbUnit.Framework.TestFixtureAttribute>]
type Wrapper() =
    inherit FSpec.MbUnitWrapper.MbUnitWrapperBase()