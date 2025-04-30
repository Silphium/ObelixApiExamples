using DesignReporting.Dowding.Request;
using DesignReporting.Missives;
using DesignReporting.Missives.Details;
using DesignReporting.Synthient;
using DowdingNetwork;
using DowdingNetwork.Radar;
using FluentSilk;

namespace TheQuantumThief;

public class Penhaligan : ISynthient
{
    /// <summary>
    /// the list of all the listeners used by this application
    /// </summary>
    internal readonly List<ApexListener> Listeners = [];

    /// <summary>
    /// recruit this synthient for a job
    /// </summary>
    /// <param name="request">the request</param>
    /// <returns>the reply</returns>
    public IMissive Recruit(IMissiveRequest request)
    {
        var Response = CreateDoorWay();

        foreach (var Listener in Listeners)
        {
            Listener.Open();
        }
        

        return Response;
    }

    /// <summary>
    /// returns a response to the query
    /// are you available
    /// </summary>
    /// <returns>a missive</returns>
    public IMissive AreYouAvailable()
    {


        return CreateDoorWay();

    }


    private IMissive CreateDoorWay()
    {

        var FrontDoor = Listeners.FirstOrDefault(node =>
            string.CompareOrdinal(Properties.Resources.FrontDoor, node.GroepsNaam) == 0);

        if (FrontDoor is not null) return MissivePrinter.PrintCompleted();

        var FrontDoorSuffix = new List<string> { "Penhaligan" };
        var FrontDoorEndPointList = new List<ApexEndPoint>
        {

            new ApexEndPoint("http", "localhost", 2007, FrontDoorSuffix),
            new ApexEndPoint("http", "127.0.0.1", 2007, FrontDoorSuffix)
        };  

        FrontDoor = DowdingCommand.Create(Properties.Resources.FrontDoor, FrontDoorEndPointList);

        Listeners.Add(FrontDoor);

        FrontDoor.AddMethodHandler("GET", FrontDoorGetHandler);




        return MissivePrinter.PrintCompleted();
    }


    private Task<IMissive> FrontDoorGetHandler(IApexMissiveRequest missiveRequest)
    {

        var WebPage = new FluentWeb(); 







        return Task.FromResult(MissivePrinter.PrintFailure(null));
    }


}