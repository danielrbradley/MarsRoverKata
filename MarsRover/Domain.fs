module MarsRover.Domain

type Heading = 
    | North
    | South
    | East
    | West

type State = 
    { PosX : int
      PosY : int
      Heading : Heading
      GridWidth : int
      GridHeight : int }

let internal wrap pos size = 
    if pos < 0 then size + pos
    else pos % size

let private move (places : int) (state : State) = 
    match state.Heading with
    | North -> { state with PosY = wrap (state.PosY + places) state.GridHeight }
    | South -> { state with PosY = wrap (state.PosY - places) state.GridHeight }
    | East -> { state with PosX = wrap (state.PosX + places) state.GridWidth }
    | West -> { state with PosX = wrap (state.PosX - places) state.GridWidth }

let moveForward = move 1
let moveBackward = move -1

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
