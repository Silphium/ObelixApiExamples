using DesignReporting.Missives.Details;


namespace DesignReporting.Missives;

/// <summary>
/// base interface for the missive reporting system
/// </summary>
/// <remarks>
/// it is not possible to create concrete instances
/// of this interface.
/// It should only be used a function return signature
/// </remarks>
public interface IMissive
{
    
    /// <summary>
    /// the HTTP Status Code for this missive
    /// </summary>
    public MissiveStatusCodes StatusCode { get; }

    /// <summary>
    /// the guid identifier for this missive
    /// </summary>
    public Guid MissiveID { get; }

    /// <summary>
    /// The missives formal response
    /// </summary>
    public IList<IMissiveResponse> ResponseList { get; }

}

/// <summary>
/// interface type: A Fully Completed MissivePrinter
/// </summary>
/// <remarks>
/// this should be the used message when an
/// operation has been completed successfully
/// this missive always returns http status code 200
/// </remarks>
public interface ICompleteMissive : IMissive { }


/// <summary>
/// interface type: a failed missive
/// </summary>
/// <remarks>
///  missives should be in the 400 http status code range
/// </remarks>
public interface IFailedMissive : IMissive
{
    /// <summary>
    /// a record of the missive which caused the failure
    /// </summary>
    public IMissive? BadMissive { get; }

}

/// <summary>
/// type interface system failure
/// </summary>
/// <remarks>
/// missives should be in the 500 http code status range
/// </remarks>
public interface ISystemFailureMissive : IFailedMissive { }


 