module MarsRover.UserInterface

type Commands =
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
