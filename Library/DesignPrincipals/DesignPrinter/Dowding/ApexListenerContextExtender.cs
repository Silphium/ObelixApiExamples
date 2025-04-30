using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesignPrinter.Dowding.Radar;
using DesignPrinter.Dowding.Request;
using DesignPrinter.Missives;

namespace DesignPrinter.Dowding;

public static class ApexListenerContextExtender
{
    /// <summary>
    /// adds an endpoint 
    /// </summary>
    /// <param name="listener"></param>
    /// <param name="endPoint"></param>
    /// <returns></returns>
    internal static ApexListener AddEndPoint(this ApexListener listener, ApexEndPoint endPoint)
    {
        var TestPoint = listener.EndPoints.FirstOrDefault(node => node.Identifier == endPoint.Identifier);

        if (TestPoint is not null) return listener;

        listener.EndPoints.Add(endPoint);
        listener.Listener.Prefixes.Add(endPoint.GetURL());
        return listener;
    }


    /// <summary>
    /// adds a list of endpoints to use with this listener
    /// </summary>
    /// <param name="source">the apex listener</param>
    /// <param name="endPoints">the mutated apex listener</param>
    /// <returns></returns>
    internal static ApexListener AddEndPoint(this ApexListener source, List<ApexEndPoint> endPoints)
    {
        for (var C = 0; C < endPoints.Count; C++)
            source.AddEndPoint(endPoints[C]);

        return source;
    }



    /// <summary>
    /// adds a method handler to the apex listener instance
    /// </summary>
    /// <param name="listener">the apex listener</param>
    /// <param name="method">the http request method</param>
    /// <param name="methodHandler">the handler for this method type</param>
    /// <returns>the mutated apex listener</returns>
    public static ApexListener AddMethodHandler(this ApexListener listener,  string method, Func<IApexMissiveRequest, Task<IMissive>> methodHandler)
    {
        var TestMethod = method.ToUpper();

        if (listener.MethodResponders.Count > 0)
        {
            var TestHandler =
                listener.MethodResponders.FirstOrDefault(node => 
                            string.CompareOrdinal(TestMethod, node.RequestMethod) == 0);

            if (TestHandler is not null) return listener;

        }

        var NewHandler = new ApexMethodHandler(TestMethod, methodHandler);
        listener.MethodResponders.Add(NewHandler);
        return listener;

    }



}