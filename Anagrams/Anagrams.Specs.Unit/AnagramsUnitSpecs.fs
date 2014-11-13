namespace Anagrams.Specs.Unit
open FSpec.Dsl
open FSpec.Matchers

module AnagramListSpecs =
    open Anagrams;
    let specs =
        describe "Given an anagram list" [
            context "which is empty" [
                context "when I add an element" [
                    it "should contain that element" <| fun _ ->
                        AnagramList.empty
                        |> AnagramList.add "foo"
                        |> AnagramList.format
                        |> should (equal "foo\n")
                ]
            ]
        ]

[<MbUnit.Framework.TestFixtureAttribute>]
type Wrapper() =
    inherit FSpec.MbUnitWrapper.MbUnitWrapperBase()