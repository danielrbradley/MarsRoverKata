module MarsRover.UnitTests.UserInterface.Scenarios

open NUnit.Framework
open FsUnit
open MarsRover.UserInterface
open MarsRover.Domain

module ``Starting at 1,1 facing North`` = 
    let start = 
        { PosX = 1
          PosY = 1
          Heading = North }
    
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
    
    [<Test>]
    let ``Turning right should head east``() = 
        start
        |> execute "R"
        |> sprint
        |> should equal "1,1 facing East"
    
    [<Test>]
    let ``Turning left should head West``() = 
        start
        |> execute "L"
        |> sprint
        |> should equal "1,1 facing West"

module ``Starting at 1,1 facing East`` = 
    let start = 
        { PosX = 1
          PosY = 1
          Heading = East }
    
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
    
    [<Test>]
    let ``Turning right should head South``() = 
        start
        |> execute "R"
        |> sprint
        |> should equal "1,1 facing South"
    
    [<Test>]
    let ``Turning left should head North``() = 
        start
        |> execute "L"
        |> sprint
        |> should equal "1,1 facing North"

module ``Starting at 1,1 facing South`` = 
    let start = 
        { PosX = 1
          PosY = 1
          Heading = South }
    
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
    
    [<Test>]
    let ``Turning right should head West``() = 
        start
        |> execute "R"
        |> sprint
        |> should equal "1,1 facing West"
    
    [<Test>]
    let ``Turning left should head East``() = 
        start
        |> execute "L"
        |> sprint
        |> should equal "1,1 facing East"

module ``Starting at 1,1 facing West`` = 
    let start = 
        { PosX = 1
          PosY = 1
          Heading = West }
    
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
    
    [<Test>]
    let ``Turning right should head North``() = 
        start
        |> execute "R"
        |> sprint
        |> should equal "1,1 facing North"
    
    [<Test>]
    let ``Turning left should head South``() = 
        start
        |> execute "L"
        |> sprint
        |> should equal "1,1 facing South"

module ``Multi-step scenarios`` = 
    module ``Starting at 0,0 facing North`` = 
        let start = 
            { PosX = 0
              PosY = 0
              Heading = North }
        
        [<Test>]
        let ``Moving forward twice, turning right, then moving forward twice more``() = 
            start
            |> execute "FFRFF"
            |> sprint
            |> should equal "2,2 facing East"
