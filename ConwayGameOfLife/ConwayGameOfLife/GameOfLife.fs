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

module Grid =
    type LinkedList2D<'T> =
        | Terminator
        | Node of value:'T * right:LinkedList2D<'T>

    let empty = Terminator

    let rec ofOnlyOneRow row =
        match row with
        | [] -> empty
        | value :: rest -> Node(value, ofOnlyOneRow rest)

    let rec topAsList node =
        match node with
        | Terminator -> []
        | Node(value, right) -> value :: topAsList right

    let pushDown row grid =
        match row, grid with
        | [], node -> node
        | row, Terminator -> ofOnlyOneRow row
        | row, node -> node

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