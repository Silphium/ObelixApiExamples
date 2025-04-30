using System.Collections.Generic;
using DesignPrinter.Dowding.Radar;

namespace DesignPrinter.Dowding;

public static class DowdingCommand
{
    /// <summary>
    /// method to create and return an instance of the
    /// apex listener class with a single endpoint
    /// </summary>
    /// <returns>the listener</returns>
    public static ApexListener Create(string groepsnaam, ApexEndPoint endPoint)
    {
        var EndPointList = new List<ApexEndPoint> { endPoint };
        return Create(groepsnaam, EndPointList);
    }

     
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static ApexListener Create(string groepsnaam, List<ApexEndPoint> endPointList)
    {
        var Listener = new ApexListener(groepsnaam);

        foreach (var EndPoint in endPointList)
        {
            Listener.AddEndPoint(EndPoint);
        }
        return Listener;

    }
}