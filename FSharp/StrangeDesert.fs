open System

type Creature(itsName:string, itsAge:int, itsEnergy)=
    let mutable name = itsName
    let mutable age = itsAge
    let mutable energy = itsEnergy
    let mutable alive = true

    member this.Alive = alive
    member this.Die() =
        if (this.Alive) then alive <- false

    member this.Grow() =
        age <- age + 1

type Plant =
    inherit Creature

    val toxic : bool


type Animal =
    inherit Creature

    val speed : int
    val agility : int


type Cactus = 
    inherit Plant

    val toxic : bool

type Giraffe =
    inherit Animal

    val mutable caught : bool

    member this.Caught() = this.caught <- true
    member this.Free() = this.caught <- false

    member x.Eat (y : Cactus) = if (y.toxic) then x.Die()
                                             else y.Die()

    

type Tiger = 
    inherit Animal

    member x.Catch (y : Giraffe) =
        if (x.speed > y.speed) then y.Caught()

    member x.Eat (y : Giraffe) = if (x.agility > y.agility) && (y.caught) then y.Die()
                                                                          else y.Free()      