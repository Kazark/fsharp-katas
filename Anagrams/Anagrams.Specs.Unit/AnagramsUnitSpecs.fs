namespace Anagrams.Specs.Unit
open FSpec.Dsl
open FSpec.Matchers
open Anagrams.Word

module AnagramsUnitSpecs =
    let specs =
        describe "Anagrams module" [
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

[<MbUnit.Framework.TestFixtureAttribute>]
type Wrapper() =
    inherit FSpec.MbUnitWrapper.MbUnitWrapperBase()