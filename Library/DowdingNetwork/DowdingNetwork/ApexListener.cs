using System.Net;
using DesignReporting.Missives;
using DowdingNetwork.Radar;
using DowdingNetwork.Request;


namespace DowdingNetwork;


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
    public List<ApexEndPoint> EndPoints { get; } = [];

    /// <summary>
    /// the list of responders for this 
    /// </summary>
    public List<ApexMethodHandler> MethodResponders { get; } = [];

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


    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="groepsnaam"></param>
    internal ApexListener(string groepsnaam)
    {
        GroepsNaam = groepsnaam;
    }




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

            RunRequestHandler();
        }

    }

    /// <summary>
    /// runs the request handler
    /// </summary>
    private void RunRequestHandler()
        => Task.Run(async () => { await ListenerRequestService(); });







}