open System 

type CreatureType = 
    | Puppy
    | Kitten
    | Hedgehog
    | Bearcub
    | Piglet
    | Bat
    | Balloon

type DaylightType =
    | Luminary
    | Wind
    | Daylight

type IMagic = 
    abstract member CallStork : CreatureType -> unit
    abstract member CallDaemon : CreatureType -> unit

type IWind =
    abstract member Speed : int

type ILuminary =
    abstract member IsShiny : bool

type IDaylight = 
    abstract member Current : DaylightType

