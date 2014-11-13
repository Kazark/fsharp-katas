module GameOfLife

type Cell =
    | DeadCell
    | LivingCell
    override this.ToString() =
        match this with
        | DeadCell -> "Dead"
        | LivingCell -> "Alive"

let nextStateOf cell communitySize =
    match cell, communitySize with
    | LivingCell, 2 -> LivingCell
    | _, 3 -> LivingCell
    | _, _ -> DeadCell

module Game =
    type Position = ColumnAndRow of int * int
    type Board = Map<Position, Cell>

    let play gameBoard =
        Seq.initInfinite (fun _ -> gameBoard)

    let formatGeneration _ =
        "O.O..\n" +
        ".OO..\n" +
        ".O...\n" +
        ".....\n" +
        ".....\n"

module Plaintext =
    let parse _ =
        Map.empty<Game.Position, Cell>
