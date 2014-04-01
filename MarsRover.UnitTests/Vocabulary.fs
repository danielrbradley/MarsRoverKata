module MarsRover.UnitTests.Vocabulary

open FsUnit
open MarsRover.UserInterface
open MarsRover.Domain

let ``On grid of`` (width : int, height : int) = 
    { PosX = 0
      PosY = 0
      Heading = North
      GridWidth = width
      GridHeight = height }

let ``starting at`` (x : int, y : int) (state : State) = 
    { state with PosX = x
                 PosY = y }

let facing (h : Heading) (state : State) = { state with Heading = h }

let executing (commands : string) (state : State) = 
    state
    |> execute commands
    |> sprint
