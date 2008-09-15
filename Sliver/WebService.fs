#light

namespace Sliver
module WebService

open System
open System.Net
open System.ServiceProcess
open System.Text
open Template

type WebService() =
    inherit ServiceBase()
    
    [<DefaultValue>] val mutable listener : HttpListener
    
    member self.Callback(result) =
        let context = self.listener.EndGetContext(result)
        let _ = self.listener.BeginGetContext(new AsyncCallback(self.Callback), null)
        
        let res = match Template.load (context.Request.Url.LocalPath.Trim [|'/'|]) with
                    | Some t -> Encoding.UTF8.GetBytes(Template.compile t)
                    | None -> Encoding.UTF8.GetBytes("Document not found.")
        
        context.Response.ContentLength64 <- int64(res.Length)
        context.Response.OutputStream.Write(res, 0, res.Length)
        context.Response.OutputStream.Close()
        
    override self.OnStart(args) =
        self.listener <- new HttpListener()
        self.listener.Prefixes.Add("http://*:8080/")
        self.listener.Start()
        let _ = self.listener.BeginGetContext(new AsyncCallback(self.Callback), null)
        ()

    override self.OnStop() = self.listener.Stop()
