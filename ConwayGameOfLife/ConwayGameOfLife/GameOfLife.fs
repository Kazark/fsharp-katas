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