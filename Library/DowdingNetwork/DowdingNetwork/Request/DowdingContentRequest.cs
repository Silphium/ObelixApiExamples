using System.Collections.Specialized;
using System.Net;
using DesignReporting.Dowding.Request;

namespace DowdingNetwork.Request;

public class DowdingContentRequest : IApexContentRequest
{
    /// <summary>
    /// the request chrome
    /// </summary>
    public IApexRequestChrome Chrome { get; }


    public DowdingContentRequest(HttpListenerRequest clientRequest)
    {
        Chrome = new DowdingRequestChrome(clientRequest);
    }
}