﻿namespace Anagrams.Specs.Unit
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
                it "should show that they are not anagrams of each other" <| fun _ ->
                    AnagramList.empty
                    |> AnagramList.add "foo"
                    |> AnagramList.add "bar"
                    |> AnagramList.format
                    |> should (equal "bar\nfoo")
            ]
            context "when I add 'dog' and 'god'" [
                it "should show them as anagrams" <| fun _ ->
                    AnagramList.empty
                    |> AnagramList.add "dog"
                    |> AnagramList.add "god"
                    |> AnagramList.format
                    |> should (equal "dog god")
            ]
            context "when I add a variety of words, some of which are anagrams of each other" [
                it "should be able to output them in a manner that reflects this fact" <| fun _ ->
                    AnagramList.empty
                    |> AnagramList.add "bar"
                    |> AnagramList.add "dog"
                    |> AnagramList.add "foo"
                    |> AnagramList.add "god"
                    |> AnagramList.add "no"
                    |> AnagramList.add "on"
                    |> AnagramList.format
                    |> should (equal "bar\ndog god\nfoo\nno on")
            ]
        ]

[<MbUnit.Framework.TestFixtureAttribute>]
type Wrapper() =
    inherit FSpec.MbUnitWrapper.MbUnitWrapperBase()