using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DesignPrinter.Dowding.Radar;
using DesignPrinter.Dowding.Request;
using DesignPrinter.Missives;

namespace DesignPrinter.Dowding;


/// <summary>
/// http listener 
/// </summary>
public sealed class ApexListener : IApexListener
{
    /// <summary>
    /// the group name for this handler
    /// </summary>
    public string GroepsNaam { get; }

    /// <summary>
    /// the list of end points supported by this listener
    /// </summary>
    public List<ApexEndPoint> EndPoints { get; } 

    /// <summary>
    /// the list of responders for this 
    /// </summary>
    public List<ApexMethodHandler> MethodResponders { get; }

    /// <summary>
    /// 
    /// </summary>
    public Action<HttpListenerResponse,IMissive> CloseRequestAction; 

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="groepsnaam"></param>
    internal ApexListener(string groepsnaam)
    {
        GroepsNaam = groepsnaam;
        EndPoints = new List<ApexEndPoint>();
        MethodResponders = new List<ApexMethodHandler>();
        CloseRequestAction = CloseRequest;

    }

    /// <summary>
    /// used to start the listener
    /// </summary>
    /// <returns>a report of this operation</returns>
    public IMissive Open()
    {
        try
        {
            Listener.Start();
            RunRequestHandler();
            return MissivePrinter.PrintCompleted();

        }
        catch (Exception)
        {
           return  MissivePrinter.PrintFailure(null);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IMissive Close()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// the http listener 
    /// </summary>
    internal readonly HttpListener Listener = new HttpListener();


    private async Task ListenerRequestService()
    {
        var Context = await Listener.GetContextAsync();
        var Report = MissivePrinter.CreateMissive();
        try
        {
            var Responder = MethodResponders.FirstOrDefault(node =>
                string.CompareOrdinal(Context.Request.HttpMethod, node.RequestMethod) == 0);

            if (Responder is null)
            {


                return;
            }

            var ClientRequest = RequestPrinter.Print(Context.Request);

            Report = await Responder.MethodHandler(ClientRequest);


        }
        catch (Exception Error)
        {

        }
        finally
        {
            CloseRequestAction(Context.Response, Report);
            RunRequestHandler();
        }

    }

    /// <summary>
    /// runs the request handler
    /// </summary>
    private void RunRequestHandler()
        => Task.Run(async () => { await ListenerRequestService(); });



    /// <summary>
    /// this is called to close the request
    /// </summary>
    /// <param name="respond"></param>
    /// <param name="missive"></param>
    private void CloseRequest(HttpListenerResponse respond, IMissive missive)
    {
        respond.StatusCode = (int)missive.StatusCode;

        using var Writer = new StreamWriter(respond.OutputStream);
        Writer.Write(missive.ResponseList[0].ResponseData);

    }
}