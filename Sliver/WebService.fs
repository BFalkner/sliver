#light

module WebService

open System.ServiceProcess

type WebService() =
    inherit ServiceBase()
    
    override s.OnStart(args) = ()
    override s.OnStop() = ()
