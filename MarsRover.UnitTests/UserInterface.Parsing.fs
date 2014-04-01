module MarsRover.UnitTests.UserInterface.Parsing

open NUnit.Framework
open FsUnit

open MarsRover.UserInterface

[<Test>]
let ``Move forward`` ()=
    parseCommand 'F' |> should equal MoveForward

[<Test>]
let ``Move backward`` ()=
    parseCommand 'B' |> should equal MoveBackward

[<Test>]
let ``Turn left`` ()=
    parseCommand 'L' |> should equal TurnLeft

[<Test>]
let ``Turn Right`` ()=
    parseCommand 'R' |> should equal TurnRight

