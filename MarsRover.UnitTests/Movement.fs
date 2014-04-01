module MarsRover.UnitTests.Movement

open NUnit.Framework
open FsUnit
open MarsRover.UserInterface
open MarsRover.Domain

let execute = execute (fun _ -> false)

module ``Starting at 1,1 facing North`` = 
    let start = 
        { PosX = 1
          PosY = 1
          Heading = North
          GridWidth = 10
          GridHeight = 10 }
    
    [<Test>]
    let ``Moving forward should increase y``() = 
        start
        |> execute "F"
        |> sprint
        |> should equal "1,2 facing North"
    
    [<Test>]
    let ``Moving backward should decrease y``() = 
        start
        |> execute "B"
        |> sprint
        |> should equal "1,0 facing North"

module ``Starting at 1,1 facing East`` = 
    let start = 
        { PosX = 1
          PosY = 1
          Heading = East
          GridWidth = 10
          GridHeight = 10 }
    
    [<Test>]
    let ``Moving forward should increase x``() = 
        start
        |> execute "F"
        |> sprint
        |> should equal "2,1 facing East"
    
    [<Test>]
    let ``Moving backward should decrease x``() = 
        start
        |> execute "B"
        |> sprint
        |> should equal "0,1 facing East"

module ``Starting at 1,1 facing South`` = 
    let start = 
        { PosX = 1
          PosY = 1
          Heading = South
          GridWidth = 10
          GridHeight = 10 }
    
    [<Test>]
    let ``Moving forward should decrease y``() = 
        start
        |> execute "F"
        |> sprint
        |> should equal "1,0 facing South"
    
    [<Test>]
    let ``Moving backward should increase y``() = 
        start
        |> execute "B"
        |> sprint
        |> should equal "1,2 facing South"

module ``Starting at 1,1 facing West`` = 
    let start = 
        { PosX = 1
          PosY = 1
          Heading = West
          GridWidth = 10
          GridHeight = 10 }
    
    [<Test>]
    let ``Moving forward should decrease x``() = 
        start
        |> execute "F"
        |> sprint
        |> should equal "0,1 facing West"
    
    [<Test>]
    let ``Moving backward should increase x``() = 
        start
        |> execute "B"
        |> sprint
        |> should equal "2,1 facing West"

module ``Multi-step scenarios`` = 
    module ``Starting at 0,0 facing North`` = 
        let start = 
            { PosX = 0
              PosY = 0
              Heading = North
              GridWidth = 10
              GridHeight = 10 }
        
        [<Test>]
        let ``Moving forward twice, turning right, then moving forward twice more``() = 
            start
            |> execute "FFRFF"
            |> sprint
            |> should equal "2,2 facing East"
