using System.Collections.Generic;
using System.Net;

namespace DesignPrinter.Dowding.Request;

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
        Parameters = new Dictionary<string, object>();
        var UrlSet = clientRequest.RawUrl.Split('?');
        if(UrlSet.Length == 1) return;

        var ParamSet = UrlSet[1].Split(';');

        for (var C = 0; C < ParamSet.Length; C++)
        {
            var ParamData = ParamSet[C].Split('=');
            Parameters.Add(new KeyValuePair<string, object>(ParamData[0].ToLower(), ParamData[1].ToLower()));
        }
    }
}