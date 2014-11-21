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