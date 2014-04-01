module MarsRover.Domain

type Heading = 
    | North
    | South
    | East
    | West

type State = 
    { PosX : int
      PosY : int
      Heading : Heading }

let moveForward state = 
    match state.Heading with
    | North -> { state with PosY = state.PosY + 1 }
    | South -> { state with PosY = state.PosY - 1 }
    | East -> { state with PosX = state.PosX + 1 }
    | West -> { state with PosX = state.PosX - 1 }

let moveBackward state = 
    match state.Heading with
    | North -> { state with PosY = state.PosY - 1 }
    | South -> { state with PosY = state.PosY + 1 }
    | East -> { state with PosX = state.PosX - 1 }
    | West -> { state with PosX = state.PosX + 1 }

let turnLeft state = 
    match state.Heading with
    | North -> { state with Heading = West }
    | East -> { state with Heading = North }
    | South -> { state with Heading = East }
    | West -> { state with Heading = South }

let turnRight state = 
    match state.Heading with
    | North -> { state with Heading = East }
    | East -> { state with Heading = South }
    | South -> { state with Heading = West }
    | West -> { state with Heading = North }
