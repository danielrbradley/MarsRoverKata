module MarsRover.UnitTests.Parsing

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
let ``Turn right`` ()=
    parseCommand 'R' |> should equal TurnRight

module ``Move forward then turn right`` =
    let commands =  parseCommands "FR"

    [<Test>]
    let ``the first command should be MoveForward`` () =
       commands 
       |> Seq.head 
       |> should equal MoveForward

    [<Test>]
    let ``The second command should be TurnRight`` () =
       commands 
       |> Seq.skip 1
       |> Seq.head 
       |> should equal TurnRight
