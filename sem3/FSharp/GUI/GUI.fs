open System
open System.Drawing
open System.Windows.Forms
open System.Timers

type Config private() =
    static let formWidth = 400
    static let formHeight = 600
    static let platformWidth = 100
    static let platformHeight = 30
    static let radiusCircle = 15
    static let maxCircleNumber = 10
    static let maxSpeed = 6
    static let formColor = Color.AliceBlue
    static let platformBrush = Brushes.BlueViolet
    static let platformSpeed = 8
    static let magicConstantX = 20
    static let magicConstantY = 30
    static let gameName = "Catcher"
    static let spaces = String.replicate 40 " "

    static member FormWidth = formWidth
    static member FormHeight = formHeight
    static member PlatformWidth = platformWidth
    static member PlatformHeight = platformHeight
    static member RadiusCircle = radiusCircle
    static member MaxCircleNumber = maxCircleNumber
    static member FormColor = formColor
    static member PlatformBrush = platformBrush
    static member MaxSpeed = maxSpeed
    static member PlatformSpeed = platformSpeed
    static member MagicConstantX = magicConstantX
    static member MagicConstantY = magicConstantY
    static member GameName = gameName
    static member Spaces = spaces



type Platform(x : int, y : int, height : int, width : int) =
    let mutable x = x
    let mutable y = y

    member this.X = x
    member this.Y = y
    member this.Width = width
    member this.Height = height

    member this.MoveLeft() = if x > 0 then x <- x - Config.PlatformSpeed 
    member this.MoveRight() = if x < Config.FormWidth - width then x <- x + Config.PlatformSpeed

    member this.Draw(g : Graphics) = g.FillRectangle(Config.PlatformBrush, x, y, width, height)


type Circle(x : int, y : int, r : int, speed : int, color : Color) =
    let x = x
    let mutable y = y
    static let rnd = new Random()
    let brush = new SolidBrush(color)
    let speed = speed

    member this.Caught(platform : Platform) = x >= platform.X && 
                                              x <= platform.X + platform.Width &&
                                              y >= platform.Y &&
                                              y <= platform.Y + platform.Height
    
    member this.Fall() = y <- y + speed

    member this.IsVisible() = y <= Config.FormHeight

    static member Create() = new Circle(
                                        rnd.Next(Config.RadiusCircle, Config.FormWidth), 
                                        -Config.RadiusCircle, 
                                        Config.RadiusCircle, 
                                        rnd.Next(1, Config.MaxSpeed),
                                        Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255))
                                       )

    member this.Draw(g : Graphics) = g.FillEllipse(brush, x - r, y - r, 2 * r, 2 * r)

type GameForm() as this =
    inherit Form(
                    Text = Config.GameName + Config.Spaces + "0",
                    BackColor = Config.FormColor,
                    Width = Config.FormWidth,
                    FormBorderStyle = FormBorderStyle.Fixed3D,
                    Height = Config.FormHeight,
                    MinimizeBox = false,
                    MaximizeBox = false
                ) 

    let mutable counter = 0

    let mutable circleList = []
    let platform = new Platform(
                                    (Config.FormWidth - Config.PlatformWidth) / 2,
                                    Config.FormHeight / 20 * 18,
                                    Config.PlatformHeight,
                                    Config.PlatformWidth
                               )

    let timer = new Timer(
                            Interval = 40.0,
                            Enabled = true
                         )

    let leftDown = this.KeyDown
                        |> Event.filter (fun e -> e.KeyCode = Keys.Left)
                        |> Event.map ignore

    let rightDown = this.KeyDown
                        |> Event.filter (fun e -> e.KeyCode = Keys.Right)
                        |> Event.map ignore


    do this.DoubleBuffered <- true
       this.Height <- this.Height + Config.MagicConstantY
       this.Width <- this.Width + Config.MagicConstantX

       timer.Elapsed.Add(fun _ -> 
                                if circleList.Length < Config.MaxCircleNumber 
                                then circleList <- Circle.Create() :: circleList
                                List.iter (fun (c : Circle) -> c.Fall()) circleList
                                circleList <- List.filter (fun (c : Circle) -> 
                                                                let caught = c.Caught(platform)
                                                                let isVis = c.IsVisible()
                                                                if caught then counter <- counter + 1
                                                                elif not isVis && counter > 0
                                                                    then counter <- counter - 1
                                                                not caught && isVis
                                                          ) circleList
                                this.Text <- Config.GameName + Config.Spaces + counter.ToString()
                                this.Refresh()
                        )

       this.Paint.Add(fun e -> 
                             e.Graphics.SmoothingMode <- Drawing2D.SmoothingMode.HighQuality
                             e.Graphics.Clear(Config.FormColor)
                             List.iter (fun (c : Circle) -> c.Draw(e.Graphics)) circleList
                             platform.Draw(e.Graphics)
                     )

       leftDown.Add(fun _ -> platform.MoveLeft())      
       rightDown.Add(fun _ -> platform.MoveRight())

Application.Run(new GameForm())