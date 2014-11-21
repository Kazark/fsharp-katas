module GridSpecs

open NUnit.Framework
open FsUnit
open GameOfLife


[<TestFixture>]
type ``Spec for a two-dimensional grid with is singly-linked in each direction``() =
    [<Test>]
    member x.``Requesting a grid of only one row from an empty list gives an empty grid``() =
        let empty = Grid.ofOnlyOneRow []
        empty |> should equal Grid.empty
        empty |> Grid.topAsList |> should equal []

    [<Test>]
    member x.``Grid with one row can be created from a list``() =
        let grid = Grid.ofOnlyOneRow [1, 2, 3]
        grid |> Grid.topAsList |> should equal [1, 2, 3]

    [<Test>]
    member x.``Pushing an empty list onto an empty grid gives an empty grid``() =
        Grid.empty
        |> Grid.pushDown []
        |> should equal Grid.empty

    [<Test>]
    member x.``Pushing an empty list onto an nonempty grid returns the same grid``() =
        Grid.ofOnlyOneRow ["foo"]
        |> Grid.pushDown []
        |> Grid.topAsList
        |> should equal ["foo"]

    [<Test>]
    member x.``A list can be pushed down as a new row onto an empty grid``() =
        Grid.empty
        |> Grid.pushDown [true, false]
        |> Grid.topAsList
        |> should equal [true, false]