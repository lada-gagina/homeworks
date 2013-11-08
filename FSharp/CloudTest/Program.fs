open System 
open NUnit.Framework
open FsUnit

type CreatureType = 
    | Puppy
    | Kitten
    | Hedgehog
    | Bearcub
    | Piglet
    | Bat
    | Balloon

type DaylightType =
    | Morning
    | Midday
    | Evening
    | Night

type IMagic = 
    abstract member CallCourier : CreatureType -> unit

type IWind =
    abstract member Speed : int

type ILuminary =
    abstract member IsShining : unit -> bool

type IDaylight = 
    abstract member Current : DaylightType

type IWeatherFactory =
    abstract member CreateDaylight : unit -> IDaylight 
    abstract member CreateLuminary : unit -> ILuminary
    abstract member CreateWind : unit -> IWind

type Magic() =
    interface IMagic with
        member x.CallCourier(t : CreatureType) = () 

(*type Daylight() =
    interface IDaylight with
        member x.Current = 
            let rnd = new Random()
            match (rnd.Next(0, 3)) with
            | 0 -> DaylightType.Morning
            | 1 -> DaylightType.Midday
            | 2 -> DaylightType.Evening
            | 3 -> DaylightType.Night
            *)

type Factory(d : DaylightType, w : int, l : bool) =
    interface IWeatherFactory with
        member x.CreateDaylight() = 
            {new IDaylight with
                member x.Current = d
            }
        member x.CreateLuminary() =
            {new ILuminary with
                member x.IsShining() = l
            }
        member x.CreateWind() =
            {new IWind with
                member x.Speed = w
            }

type Creature(t : CreatureType) =
    member x.CreatureType = t

type Cloud(factory : IWeatherFactory) =
    let daylight = factory.CreateDaylight()
    let luminary = factory.CreateLuminary()
    let wind = factory.CreateWind()
 
    member private x.InternalCreate() =
      match (daylight.Current, luminary.IsShining()) with
        | (DaylightType.Morning, true) -> new Creature(CreatureType.Puppy) 
        | (DaylightType.Morning, false) -> if wind.Speed >= 5 && wind.Speed <= 10 then new Creature(CreatureType.Kitten) else new Creature(CreatureType.Balloon)
        | (DaylightType.Midday, true) -> if wind.Speed >= 5 && wind.Speed <= 10 then new Creature(CreatureType.Piglet) else new Creature(CreatureType.Balloon)
        | (DaylightType.Midday, false) -> if wind.Speed >= 0 && wind.Speed < 5 then new Creature(CreatureType.Hedgehog) else new Creature(CreatureType.Balloon)
        | (DaylightType.Evening, false) -> new Creature(CreatureType.Bearcub)
        | (DaylightType.Night, false) -> if wind.Speed >= 0 && wind.Speed < 5 then new Creature(CreatureType.Bat) else new Creature(CreatureType.Balloon)
        | otherwise -> new Creature(CreatureType.Balloon)

    member x.Create() =
      let creature = x.InternalCreate()
      let magic = new Magic() :> IMagic     
      magic.CallCourier(creature.CreatureType)
      creature

[<TestFixture>]
type Test() =
    [<Test>]
    member x.``1``() = 
        let factory = new Factory(Midday, 0, false)
        let cloud = new Cloud(factory)
        cloud.Create() |> should equal CreatureType.Hedgehog