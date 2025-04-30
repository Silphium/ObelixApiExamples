using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace DesignPrinter.Dowding.Request;

public class DowdingRequestChrome : IApexRequestChrome
{
    /// <summary>
    ///  
    /// </summary>
    public List<string> AcceptTypes { get; } = new List<string>();

    /// <summary>
    /// the http request headers
    /// </summary>
    public NameValueCollection Headers { get;}

    /// <summary>
    /// the url this request came from
    /// </summary>
    public string RequestUrl { get; } = string.Empty;

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