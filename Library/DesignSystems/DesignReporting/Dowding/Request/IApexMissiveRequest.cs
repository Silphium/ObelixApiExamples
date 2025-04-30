using System.Collections.Specialized;
using DesignReporting.Missives.Details;

namespace DesignReporting.Dowding.Request;

/// <summary>
/// used to represent key information points from a
/// client's key information points.
/// </summary>
public interface IApexMissiveRequest 
{
    /// <summary>
    /// the request chrome
    /// </summary>
    IApexRequestChrome Chrome { get; }
}


/// <summary>
///   
/// </summary>
public interface IApexRequestChrome
{
    /// <summary>
    ///  
    /// </summary>
    public List<string> AcceptTypes { get; }

    /// <summary>
    /// the http request headers
    /// </summary>
    NameValueCollection Headers { get; }

    /// <summary>
    /// the url this request came from
    /// </summary>
    string RequestUrl { get; }

}