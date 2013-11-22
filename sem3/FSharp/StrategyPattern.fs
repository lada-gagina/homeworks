open System

type IManufacturer =
    abstract member ProduceToy : unit -> unit

type FurManufacturer() =
    interface IManufacturer with
        member x.ProduceToy() = Console.WriteLine("Произведена игрушка из меха!")
                                

type WoodManufacturer() =
    interface IManufacturer with
        member x.ProduceToy() = Console.WriteLine("Произведена деревянная игрушка!")
                                

type TextileManufacturer() =
    interface IManufacturer with
        member x.ProduceToy() = Console.WriteLine("Произведена игрушка из ткани!")
                                


type Factory(firstStrategy : IManufacturer) =
    let mutable strategy = firstStrategy

    member x.SetStrategy(str : IManufacturer) = 
        strategy <- str

    member x.Manufacture() =
        strategy.ProduceToy()   


//////////////////////////////////////////////////////////////////////////////////////

[<EntryPoint>]
let main argv = 

    let factory = new Factory(new FurManufacturer())

    let toy1 = factory.Manufacture()

    factory.SetStrategy(new WoodManufacturer())

    let toy2 = factory.Manufacture()

    factory.SetStrategy(new TextileManufacturer())

    let toy3 = factory.Manufacture()
    0 // return an integer exit code