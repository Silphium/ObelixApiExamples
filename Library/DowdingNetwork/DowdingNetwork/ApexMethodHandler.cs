using DesignReporting.Dowding.Request;
using DesignReporting.Missives;

namespace DowdingNetwork;

/// <summary>
/// this class represents and http listener handle
/// </summary>
public class ApexMethodHandler
{
    /// <summary>
    /// the type of method that forms this request
    /// </summary>
    public readonly string RequestMethod;

    /// <summary>
    /// the handler for this class
    /// </summary>
    public readonly Func<IApexMissiveRequest,Task<IMissive>> MethodHandler;

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="requestMethod">the request method</param>
    /// <param name="methodHandler">the methodHandler for that method</param>
    internal ApexMethodHandler(string requestMethod, Func<IApexMissiveRequest, Task<IMissive>> methodHandler)
    {
        RequestMethod = requestMethod;
        MethodHandler = methodHandler;
    }
}