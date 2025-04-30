using System.Windows.Forms;
using DesignPrinter.Missives.Details;
using DesignPrinter.Missives.State;

namespace DesignPrinter.Missives;

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



    public static IMissive CreateMissive(IMissiveRequest request) => new OpenMissive(request);


    /// <summary>
    /// returns a new completed missive
    /// </summary>
    /// <returns>a completed missive</returns>
    public static IMissive PrintCompleted(IMissiveRequest? request = null) => new CompleteMissive(request);

    /// <summary>
    /// returns a new failed missive
    /// </summary>
    /// <returns>a basic failed missive</returns>
    public static IMissive PrintFailure(IMissive? badMissive) 
                    => new FailedMissive(badMissive);




}
