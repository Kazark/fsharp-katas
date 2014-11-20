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

module Board =
    type Position = ColumnAndRow of int * int
    type Mapped = Map<Position, Cell>
    type Nested = Cell seq seq

    let nestedToMapped nestedSeqs =
        let toCellAtPosition rowNumber row =
            let positionCell columnNumber cell =
                ColumnAndRow(columnNumber, rowNumber), cell
            Seq.mapi positionCell row
        Seq.mapi toCellAtPosition nestedSeqs
        |> Seq.concat
        |> Map.ofSeq

    let shiftUp nested = Seq.skip 1 nested
    let shiftLeft nested =
        Seq.map (fun row -> Seq.skip 1 row) nested
    let shiftRight nested =
        Seq.map (fun row -> DeadCell :: row) nested

    let formatGeneration _ =
        "O.O..\n" +
        ".OO..\n" +
        ".O...\n" +
        ".....\n" +
        ".....\n"

module Game =
    let nextGeneration gameBoard =
        gameBoard
    let play gameBoard =
        Seq.initInfinite (fun _ -> gameBoard)

module Plaintext =
    let parseCell cell =
        match cell with
        | 'O' -> LivingCell
        | _ -> DeadCell

    let parseRow row =
        Seq.map parseCell row

    let parse (plaintext : string) =
        plaintext.Split '\n'
        |> Seq.map parseRow