using DesignPrinter.Missives.Details;
using DesignPrinter.Missives.State;

namespace DesignPrinter.Missives;

/// <summary>
/// context extender for the missive
/// </summary>
public static class MissiveContextExtender
{
    /// <summary>
    /// adds a response the missive
    /// </summary>
    /// <param name="missive">the missive</param>
    /// <param name="response">the response to be added</param>
    /// <returns>the mutated IMissive instance</returns>
    public static IMissive AddResponse(this IMissive missive, IMissiveResponse response)
    {
        missive.ResponseList.Add(response);
        return missive;
    }

    /// <summary>
    /// sets the status of the failed missive
    /// </summary>
    /// <param name="missive">the failed missive</param>
    /// <param name="statusCode">the new status code</param>
    /// <returns>the mutated missive</returns>
    public static IMissive SetStatus(this IMissive missive, MissiveStatusCodes statusCode)
    {
        if (missive is not FailedMissive FailMissive) return missive;
        
        FailMissive.StatusCode = statusCode;
        return FailMissive;

    }


}