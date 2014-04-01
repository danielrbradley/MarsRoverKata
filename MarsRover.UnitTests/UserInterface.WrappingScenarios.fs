module MarsRover.UnitTests.UserInterface.WrappingScenarios

open NUnit.Framework
open FsUnit
open MarsRover.UserInterface
open MarsRover.Domain
open MarsRover.UnitTests.Vocabulary

[<Test>]
let ``Wrapping over``() = wrap -1 10 |> should equal 9

[<Test>]
let ``Wrapping under``() = wrap 10 10 |> should equal 0

[<Test>]
let ``Wrapping off bottom``() = 
    ``On grid of`` (10, 10)
    |> ``starting at`` (0, 0)
    |> facing South
    |> executing "F"
    |> should equal "0,9 facing South"

[<Test>]
let ``Wrapping off top``() = 
    ``On grid of`` (10, 10)
    |> ``starting at`` (0, 9)
    |> facing North
    |> executing "F"
    |> should equal "0,0 facing North"

[<Test>]
let ``Wrapping off left``() = 
    ``On grid of`` (10, 10)
    |> ``starting at`` (0, 0)
    |> facing West
    |> executing "F"
    |> should equal "9,0 facing West"

[<Test>]
let ``Wrapping off right``() = 
    ``On grid of`` (10, 10)
    |> ``starting at`` (9, 0)
    |> facing East
    |> executing "F"
    |> should equal "0,0 facing East"
