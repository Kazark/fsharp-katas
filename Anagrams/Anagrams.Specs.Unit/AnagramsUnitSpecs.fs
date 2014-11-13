namespace Anagrams.Specs.Unit
open FSpec.Dsl
open FSpec.Matchers

module AnagramListSpecs =
    open Anagrams;
    let specs =
        describe "Given an empty anagram list" [
            context "when I add 'foo'" [
                it "should contain that element" <| fun _ ->
                    AnagramList.empty
                    |> AnagramList.add "foo"
                    |> AnagramList.format
                    |> should (equal "foo")
            ]
            context "when I add 'foo' and 'bar'" [
                it "should show them as anagrams" <| fun _ ->
                    AnagramList.empty
                    |> AnagramList.add "foo"
                    |> AnagramList.add "bar"
                    |> AnagramList.format
                    |> should (equal "bar\nfoo")
            ]
        ]

[<MbUnit.Framework.TestFixtureAttribute>]
type Wrapper() =
    inherit FSpec.MbUnitWrapper.MbUnitWrapperBase()