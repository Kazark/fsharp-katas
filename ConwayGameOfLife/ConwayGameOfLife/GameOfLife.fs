module GameOfLife

type Cell =
    | DeadCell
    | LivingCell
    override this.ToString() =
        match this with
        | DeadCell -> "Dead"
        | LivingCell -> "Alive"

let nextStateOf _ communitySize =
    match communitySize with
    | 2 -> LivingCell
    | 3 -> LivingCell
    | _ -> DeadCell