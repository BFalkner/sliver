#light

namespace Sliver
module WebService

open System
open System.Net
open System.ServiceProcess
open System.Text

type WebService() =
    inherit ServiceBase()
    
    [<DefaultValue>] val mutable listener : HttpListener
    
    member s.Callback(result) =
        let context = s.listener.EndGetContext(result)
        let _ = s.listener.BeginGetContext(new AsyncCallback(s.Callback), null)
        
        let res = Encoding.UTF8.GetBytes("<html><body><div>blah</div></body></html>")
        context.Response.ContentLength64 <- int64(res.Length)
        context.Response.OutputStream.Write(res, 0, res.Length)
        context.Response.OutputStream.Close()
        
    override s.OnStart(args) =
        s.listener <- new HttpListener()
        s.listener.Prefixes.Add("http://*:8080/")
        s.listener.Start()
        let _ = s.listener.BeginGetContext(new AsyncCallback(s.Callback), null)
        ()

    override s.OnStop() = s.listener.Stop()
