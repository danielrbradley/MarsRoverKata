module MarsRover.UnitTests.UserInterface.Output

open NUnit.Framework
open FsUnit
open MarsRover.UserInterface
open MarsRover.Domain

[<Test>]
let ``0,0 facing North``() =
    let state = {
        PosX = 0
        PosY = 0
        Heading = North
    }
    state |> sprint |> should equal "0,0 facing North"

[<Test>]
let ``3,1 facing East``() =
    let state = {
        PosX = 3
        PosY = 1
        Heading = East
    }
    state |> sprint |> should equal "3,1 facing East"
