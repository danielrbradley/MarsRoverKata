module MarsRover.UnitTests.Turning

open NUnit.Framework
open FsUnit
open MarsRover.Interface
open MarsRover.Domain

let execute = execute (fun _ -> false)

let ``Start facing`` (heading : Heading) = 
    { PosX = 0
      PosY = 0
      Heading = heading
      GridWidth = 10
      GridHeight = 10 }

let heading (state : State) = state.Heading

[<Test>]
let ``Turning right from North``() = 
    ``Start facing`` North
    |> execute "R"
    |> heading
    |> should equal East

[<Test>]
let ``Turning left from North``() = 
    ``Start facing`` North
    |> execute "L"
    |> heading
    |> should equal West

[<Test>]
let ``Turning right from South``() = 
    ``Start facing`` South
    |> execute "R"
    |> heading
    |> should equal West

[<Test>]
let ``Turning left from South``() = 
    ``Start facing`` South
    |> execute "L"
    |> heading
    |> should equal East

[<Test>]
let ``Turning right from East``() = 
    ``Start facing`` East
    |> execute "R"
    |> heading
    |> should equal South

[<Test>]
let ``Turning left from East``() = 
    ``Start facing`` East
    |> execute "L"
    |> heading
    |> should equal North

[<Test>]
let ``Turning right from West``() = 
    ``Start facing`` West
    |> execute "R"
    |> heading
    |> should equal North

[<Test>]
let ``Turning left from West``() = 
    ``Start facing`` West
    |> execute "L"
    |> heading
    |> should equal South
