using System.Collections.Specialized;
using System.Net;
using DesignReporting.Dowding.Request;

namespace DowdingNetwork.Request;

public class DowdingRequestChrome : IApexRequestChrome
{
    /// <summary>
    ///  
    /// </summary>
    public List<string> AcceptTypes { get; } = [];

    /// <summary>
    /// the http request headers
    /// </summary>
    public NameValueCollection Headers { get; private set; } = [];

    /// <summary>
    /// the url this request came from
    /// </summary>
    public string RequestUrl { get; } 

    /// <summary>
    /// the constructor
    /// </summary>
    /// <param name="clientRequest">the client request</param>
    public DowdingRequestChrome(HttpListenerRequest clientRequest)
    {
        if(clientRequest.AcceptTypes is not null)
            AcceptTypes.AddRange(clientRequest.AcceptTypes);

        if (!string.IsNullOrEmpty(clientRequest.RawUrl))
            RequestUrl = clientRequest.RawUrl;


        Headers = clientRequest.Headers;

    }


    




}