using DesignReporting.Missives;
using DesignReporting.Missives.Details;

namespace DesignReporting.Synthient;

/// <summary>
/// interface for machine intelligence systems
/// </summary>
public interface ISynthient   
{
    /// <summary>
    /// recruit this synthient for a job
    /// </summary>
    /// <param name="request">the request</param>
    /// <returns>the reply</returns>
    IMissive Recruit(IMissiveRequest request);

    /// <summary>
    /// returns a response to the query
    /// are you available
    /// </summary>
    /// <returns>a missive</returns>
    IMissive AreYouAvailable();
}