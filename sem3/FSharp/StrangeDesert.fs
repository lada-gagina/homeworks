open System

[<AbstractClass>]
type Creature(name : string) =
    let mutable name = name
    let mutable age = 0
    let mutable alive = true

    member this.Alive = alive
    member this.Age = age

    member this.Die() = alive <- false
                        

    member this.Grow() =
        age <- age + 1

[<AbstractClass>]
type Plant(name : string, toxicity : bool) =
    inherit Creature(name)

    let toxic = toxicity

    member this.Toxic = toxicity

[<AbstractClass>]
type Animal(name : string, speed : int, agility : int) =
    inherit Creature(name)

    let speed = speed
    let agility = agility

    member this.Speed = speed
    member this.Agility = agility

type Cactus(toxicity : bool) = 
    inherit Plant("Cactus", toxicity)

type Giraffe(speed, agility) =
    inherit Animal("Giraffe", speed, agility)

    let mutable caught = false
    
    member this.IsCaught = caught
    member this.Caught() = caught <- true
    member this.Free() = caught <- false

    member x.Eat (y : Cactus) = if not y.Toxic && x.Alive then y.Die() 
                                                          else x.Die()

    
type Tiger(speed, agility) = 
    inherit Animal("Tiger", speed, agility)

    member x.Catch (y : Giraffe) =
        if x.Alive && x.Speed > y.Speed then y.Caught()

    member x.Eat (y : Giraffe) = if x.Alive && 
                                    y.Alive && 
                                    x.Agility > y.Agility && 
                                    y.IsCaught then y.Die()
                                               else y.Free()

let kindCactus = new Cactus(true)
let angryCactus = new Cactus(false)
let cleverGiraffe = new Giraffe(10, 50)
let stupidGiraffe = new Giraffe(10, 30)
let tiger = new Tiger(20, 40)

stupidGiraffe.Eat(kindCactus)
tiger.Catch(stupidGiraffe)
tiger.Eat(stupidGiraffe)
tiger.Catch(cleverGiraffe)
tiger.Eat(cleverGiraffe)
cleverGiraffe.Eat(kindCactus)