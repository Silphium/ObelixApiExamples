using System.Collections.Specialized;
using System.Net;
using DesignReporting.Dowding.Request;

namespace DowdingNetwork.Request;

public class DowdingParameterRequest : IApexParameterRequest
{
    /// <summary>
    /// the request chrome
    /// </summary>
    public IApexRequestChrome Chrome { get; }

    /// <summary>
    /// the contents of the request
    /// </summary>
    public IDictionary<string, object> Parameters { get; }


    /// <summary>
    /// the client's request
    /// </summary>
    /// <param name="clientRequest"></param>
    public DowdingParameterRequest(HttpListenerRequest clientRequest)
    {

        Chrome = new DowdingRequestChrome(clientRequest);

    }


    
}