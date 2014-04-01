module MarsRover.UserInterface

type Command =
    | MoveForward
    | MoveBackward
    | TurnLeft
    | TurnRight

let internal parseCommand (inputLetter : char) =
    match inputLetter with
    | 'F' -> MoveForward
    | 'B' -> MoveBackward
    | 'L' -> TurnLeft
    | 'R' -> TurnRight
    | _ -> failwith "Unrecognised command"

let private explode (s:string) =
    seq {for c in s -> c}

let internal parseCommands (input : string) =
    input
    |> explode
    |> Seq.map parseCommand

open Domain

let private apply (state : State) (command : Command) =
    match command with
    | MoveForward -> moveForward state
    | MoveBackward -> moveBackward state
    | TurnLeft -> turnLeft state
    | TurnRight -> turnRight state

let execute (input : string) (state : State) =
    input
    |> parseCommands
    |> Seq.fold apply state

let sprint (state : State) =
    sprintf "%i,%i facing %A" state.PosX state.PosY state.Heading
