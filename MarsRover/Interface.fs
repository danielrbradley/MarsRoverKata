module MarsRover.Interface

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

let private explode (s : string) = 
    seq { 
        for c in s -> c
    }

let internal parseCommands (input : string) = 
    input
    |> explode
    |> Seq.map parseCommand

open Domain

let execute (hasObstacle : int * int -> bool) (input : string) (state : State) = 
    let apply (state : State) (command : Command) = 
        match command with
        | MoveForward -> moveForward hasObstacle state
        | MoveBackward -> moveBackward hasObstacle state
        | TurnLeft -> turnLeft state
        | TurnRight -> turnRight state
    input
    |> parseCommands
    |> Seq.fold apply state

let sprint (state : State) = sprintf "%i,%i facing %A" state.PosX state.PosY state.Heading
