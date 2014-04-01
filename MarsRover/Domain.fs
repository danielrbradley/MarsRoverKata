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
    state

let moveBackward state =
    state

let turnLeft state =
    state

let turnRight state =
    state
