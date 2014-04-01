module MarsRover.UnitTests.UserInterface.WrappingScenarios

open NUnit.Framework
open FsUnit
open MarsRover.UserInterface
open MarsRover.Domain

[<Test>]
let ``Wrapping over``() = wrap -1 10 |> should equal 9

[<Test>]
let ``Wrapping under``() = wrap 10 10 |> should equal 0

module Vocabulary =
    let ``On 10x10 grid`` = 
        { PosX = 0
          PosY = 0
          Heading = North
          GridWidth = 10
          GridHeight = 10 }

    let ``starting at`` (x : int, y : int) (state : State) = 
        { state with PosX = x
                     PosY = y }

    let facing (h : Heading) (state : State) = { state with Heading = h }

    let executing (commands : string) (state : State) = 
        state
        |> execute (fun _ -> false) commands
        |> sprint

open Vocabulary

[<Test>]
let ``Wrapping off bottom``() = 
    ``On 10x10 grid``
    |> ``starting at`` (0, 0)
    |> facing South
    |> executing "F"
    |> should equal "0,9 facing South"

[<Test>]
let ``Wrapping off top``() = 
    ``On 10x10 grid``
    |> ``starting at`` (0, 9)
    |> facing North
    |> executing "F"
    |> should equal "0,0 facing North"

[<Test>]
let ``Wrapping off left``() = 
    ``On 10x10 grid``
    |> ``starting at`` (0, 0)
    |> facing West
    |> executing "F"
    |> should equal "9,0 facing West"

[<Test>]
let ``Wrapping off right``() = 
    ``On 10x10 grid``
    |> ``starting at`` (9, 0)
    |> facing East
    |> executing "F"
    |> should equal "0,0 facing East"
