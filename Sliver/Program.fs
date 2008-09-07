#light

open System.ServiceProcess
open System
open Sliver.WebService

[<STAThread>]
[<EntryPoint>]
let main(args) =
    ServiceBase.Run(new WebService())
    0
