using DesignReporting.Missives.State;

namespace DesignReporting.Missives;

/// <summary>
///  Reporting Class: MissivePrinter
/// </summary>
public static class MissivePrinter
{

    /// <summary>
    /// creates an open missive 
    /// </summary>
    /// <returns>the open missive</returns>
    public static IMissive CreateMissive() => new OpenMissive();

    /// <summary>
    /// returns a new completed missive
    /// </summary>
    /// <returns>a completed missive</returns>
    public static IMissive PrintCompleted() => new CompleteMissive();

    /// <summary>
    /// returns a new failed missive
    /// </summary>
    /// <returns>a basic failed missive</returns>
    public static IMissive PrintFailure(IMissive? badMissive) 
                    => new FailedMissive(badMissive);




}
