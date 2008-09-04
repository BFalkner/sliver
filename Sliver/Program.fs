#light

open System.ServiceProcess
open System
open WebService

[<STAThread>]
[<EntryPoint>]
let main(args) =
    ServiceBase.Run(new WebService())
    0
