using System.Net;

namespace DesignPrinter.Dowding.Request;

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