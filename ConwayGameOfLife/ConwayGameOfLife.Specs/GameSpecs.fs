module GameSpecs

open NUnit.Framework
open FsUnit
open GameOfLife

let glider0 =
    "O.O..\n" +
    ".OO..\n" +
    ".O...\n" +
    ".....\n" +
    ".....\n"

let glider1 =
    "..O..\n" +
    "O.O..\n" +
    ".OO..\n" +
    ".....\n" +
    ".....\n"

let glider2 =
    ".O...\n" +
    "..OO.\n" +
    ".OO..\n" +
    ".....\n" +
    ".....\n"

let glider3 =
    "..O..\n" +
    "...O.\n" +
    ".OOO.\n" +
    ".....\n" +
    ".....\n"

let glider4 =
    ".....\n" +
    ".O.O.\n" +
    "..OO.\n" +
    "..O..\n" +
    ".....\n"

[<TestFixture>]
type ``Given a simple glider set to move down and to the right, when I start a game of life`` () = 
    let gliderMoving =
        Plaintext.parse glider0
        |> Game.play
        |> Seq.map Board.formatGeneration
        |> Seq.take 5
        |> Seq.toList

    [<Test>]
    member x.``then the first state is the initial state`` () =
        gliderMoving.[0] |> should equal glider0
    [<Test>]
    member x.``and in the second state the glider has transformed but not moved`` () =
        gliderMoving.[1] |> should equal glider1
    (*[<Test>]
    member x.``and in the third state the glider has moved right`` () =
        gliderMoving.[2] |> should equal glider2
    [<Test>]
    member x.``and in the fourth state the glider has transformed again but not moved further`` () =
        gliderMoving.[3] |> should equal glider3
    [<Test>]
    member x.``and in the fifth state it has moved down and returned to its original shape`` () =
        gliderMoving.[4] |> should equal glider4*)