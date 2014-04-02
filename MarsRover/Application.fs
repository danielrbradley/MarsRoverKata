open System
open MarsRover.Domain
open MarsRover.Interface

let promptIsBlocked (x,y) =
    printf "Does (%i,%i) contain an osticle? y/n " x y
    let isKeyY = Console.ReadKey(false).Key = ConsoleKey.Y
    Console.WriteLine()
    isKeyY

let execute = execute promptIsBlocked

let parseGridSize (input : string) = 
    try 
        let parts = input.Split('x') |> Array.map (fun x -> int32 x)
        { PosX = 0
          PosY = 0
          Heading = North
          GridWidth = parts.[0]
          GridHeight = parts.[1] }
    with _ -> 
        { PosX = 0
          PosY = 0
          Heading = North
          GridWidth = 10
          GridHeight = 10 }

let rec commandLoop (state : State) = 
    Console.WriteLine(sprint state)
    printf "Enter your next command (type exit to quit): \r\n"
    let command = Console.ReadLine()
    if command = "exit" then ()
    else 
        try 
            state
            |> execute command
            |> commandLoop
        with ex -> 
            printf "Failed with %O" ex
            commandLoop state

let main() = 
    printf "What size grid would you like? (Default is \"10x10\")\r\n"
    let gridInput = Console.ReadLine()
    let initialState = parseGridSize gridInput
    commandLoop initialState

main()
