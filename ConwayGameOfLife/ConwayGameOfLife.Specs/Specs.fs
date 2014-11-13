namespace ConwayGameOfLife.Specs

open NUnit.Framework
open FsUnit
open GameOfLife

[<TestFixture>]
type ``Given a living cell`` () = 
    [<Test>]
    member x.``which has only one living neighbors, it should die in the next generation`` () =
        nextStateOf LivingCell 1 |> should equal DeadCell
