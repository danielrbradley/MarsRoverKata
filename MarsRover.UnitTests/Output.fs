module MarsRover.UnitTests.Output

open NUnit.Framework
open FsUnit
open MarsRover.Interface
open MarsRover.Domain

[<Test>]
let ``0,0 facing North``() = 
    { PosX = 0
      PosY = 0
      Heading = North
      GridWidth = 10
      GridHeight = 10 }
    |> sprint
    |> should equal "0,0 facing North"

[<Test>]
let ``3,1 facing East``() = 
    { PosX = 3
      PosY = 1
      Heading = East
      GridWidth = 10
      GridHeight = 10 }
    |> sprint
    |> should equal "3,1 facing East"
