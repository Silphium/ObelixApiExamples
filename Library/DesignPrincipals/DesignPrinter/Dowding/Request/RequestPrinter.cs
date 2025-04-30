using System.Net;

namespace DesignPrinter.Dowding.Request;

internal static class RequestPrinter
{

    /// <summary>
    /// prints a request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    internal static IApexMissiveRequest Print(HttpListenerRequest request)
    {
        if (string.CompareOrdinal("GET", request.HttpMethod) == 0)
        {
            return new DowdingParameterRequest(request);
       
        }
        return new DowdingContentRequest(request);
    }





}