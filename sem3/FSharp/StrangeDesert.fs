open System

type Creature(itsName:string, itsAge:int) =
    let mutable name = itsName
    let mutable age = itsAge
    let mutable alive = true

    member this.Alive = alive
    member this.Age = age

    member this.Die() =
        if (this.Alive) then alive <- false

    member this.Grow() =
        age <- age + 1

type Plant(itsName:string, itsAge:int, itsToxicity:bool) =
    inherit Creature(itsName, itsAge)

    let toxic = itsToxicity


type Animal(itsName:string, itsAge:int, itsSpeed:int, itsAgility:int) =
    inherit Creature(itsName, itsAge)

    let speed = itsSpeed
    let agility = itsAgility

    member this.Speed = speed
    member this.Agility = agility


type Cactus(itsToxicity:bool) = 
    inherit Plant("Cactus", 0, itsToxicity)

    member this.Toxic = itsToxicity

//type PoisonousCactus() =
  //  inherit Plant("Cactus", 0, true)

type Giraffe(itsSpeed, itsAgility) =
    inherit Animal("Giraffe", 0, itsSpeed, itsAgility)

    let mutable caught = false
    
    member this.IsCaught = caught
    member this.Caught() = caught <- true
    member this.Free() = caught <- false

    member x.Eat (y : Cactus) = if (y.Toxic) then x.Die()
                                             else y.Die()

    

type Tiger(itsSpeed, itsAgility) = 
    inherit Animal("Tiger", 0, itsSpeed, itsAgility)

    member x.Catch (y : Giraffe) =
        if (x.Speed > y.Speed) then y.Caught()

    member x.Eat (y : Giraffe) = if (x.Agility > y.Agility) && (y.IsCaught) then y.Die()
                                                                            else y.Free()