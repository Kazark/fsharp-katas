namespace ConwayGameOfLife.Specs

open NUnit.Framework
open FsUnit
open GameOfLife

[<TestFixture>]
type ``Given a cell was living in the previous generation`` () = 
    [<Test>]
    member x.``but had only one living neighbor, it should be dead now`` () =
        nextStateOf LivingCell 1 |> should equal DeadCell
    [<Test>]
    member x.``and had two living neighbors, it should have lived on`` () =
        nextStateOf LivingCell 2 |> should equal LivingCell
    [<Test>]
    member x.``and had three living neighbors, it should have lived on`` () =
        nextStateOf LivingCell 3 |> should equal LivingCell
