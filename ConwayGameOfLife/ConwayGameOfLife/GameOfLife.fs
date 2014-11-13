module GameOfLife

type Cell =
    | DeadCell
    | LivingCell
    override this.ToString() =
        match this with
        | DeadCell -> "Dead"
        | LivingCell -> "Alive"

let nextStateOf _ _ = DeadCell