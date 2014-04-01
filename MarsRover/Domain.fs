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

let private applyWrap (state : State) = 
    match state.Heading with
    | North | South -> { state with PosY = wrap state.PosY state.GridHeight }
    | East | West -> { state with PosX = wrap state.PosX state.GridWidth }

let private applyMove (places : int) (state : State) = 
    match state.Heading with
    | North -> { state with PosY = state.PosY + places }
    | South -> { state with PosY = state.PosY - places }
    | East -> { state with PosX = state.PosX + places }
    | West -> { state with PosX = state.PosX - places }

let private isObstructed (hasObsatcle : int * int -> bool) (state : State) = hasObsatcle (state.PosX, state.PosY)

let private revertIfObstructed (isStateObstructed : State -> bool) (previousState : State) (newState : State) = 
    if isStateObstructed newState then previousState
    else newState

let private move (places : int) (hasObsatcle : int * int -> bool) (state : State) = 
    let isObstructed' = isObstructed hasObsatcle
    state
    |> applyMove places
    |> applyWrap
    |> revertIfObstructed isObstructed' state

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
