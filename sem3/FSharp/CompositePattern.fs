open System

type IEquipment =
    abstract member Name : string

    abstract member Add : IEquipment -> unit
    abstract member Remove : IEquipment -> unit

type CompositeEquipment(name : string) = 
    let mutable _equipment : List<IEquipment> = []
    interface IEquipment with
        member x.Name = name
        member x.Add(eq) = _equipment <- eq :: _equipment
        member x.Remove(eq) = _equipment <- List.filter (fun x -> (x <> eq)) _equipment

type Chassis() =
    inherit CompositeEquipment("Chassis") //аппаратный блок компьютера

type Cabinet() =
    inherit CompositeEquipment("Cabinet") //корпус

type Bus() =                              //шина
    interface IEquipment with
        member x.Name = "Bus"
        member x.Add(eq) = failwith "Cannot add"
        member x.Remove(eq) = failwith "Cannot remove"
    
[<EntryPoint>]
let main argv = 

    let bus = new Bus()

    let chassis = (new Chassis() :> IEquipment).Add(bus)

    let cabinet = (new Cabinet() :> IEquipment).Add(new Chassis())

    0 // return an integer exit code
