module MarsRover.UnitTests.Obstacles

open NUnit.Framework
open FsUnit
open MarsRover.Interface
open MarsRover.Domain

module Vocabulary =
    let ``Starting at`` (x : int, y : int) = 
        { PosX = x
          PosY = y
          Heading = North
          GridWidth = 10
          GridHeight = 10 }

    let facing (h : Heading) (state : State) = { state with Heading = h }

    let executing hasObsticle (commands : string) (state : State) = 
        state
        |> execute hasObsticle commands
        |> sprint

open Vocabulary

module ``Given obstacle at 1,1`` =
    let hasObsticle coordinate =
        match coordinate with
        | (1,1) -> true
        | _ -> false

    let moveForward = executing hasObsticle "F"

    [<Test>]
    let ``When moving north from 1,0`` () =
        ``Starting at`` (1,0)
        |> facing North
        |> moveForward 
        |> should equal "1,0 facing North"

    [<Test>]
    let ``When moving south from 1,2`` () =
        ``Starting at`` (1,2)
        |> facing South
        |> moveForward 
        |> should equal "1,2 facing South"

    [<Test>]
    let ``When moving east from 0,1`` () =
        ``Starting at`` (0,1)
        |> facing East
        |> moveForward 
        |> should equal "0,1 facing East"

    [<Test>]
    let ``When moving west from 2,1`` () =
        ``Starting at`` (2,1)
        |> facing West
        |> moveForward 
        |> should equal "2,1 facing West"
