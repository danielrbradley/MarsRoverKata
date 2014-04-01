module MarsRover.UserInterface

type Commands =
    | MoveForward
    | MoveBackward
    | TurnLeft
    | TurnRight

let parseCommand (inputLetter : char) =
    match inputLetter with
    | 'F' -> MoveForward
    | 'B' -> MoveBackward
    | 'L' -> TurnLeft
    | 'R' -> TurnRight
    | _ -> failwith "Unrecognised command"
