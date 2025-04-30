using System;
using System.Collections.Generic;
using System.Linq;
using DesignPrinter.Missives.Details;
using DesignPrinter.Missives.Error;

namespace DesignPrinter.Missives.State;

/// <summary>
/// the class is used to report information from a
/// system failure.
/// </summary>
internal class SystemFailureMissive : ISystemFailureMissive
{
    /// <summary>
    /// a record of the missive which caused the failure
    /// </summary>
    public IMissive? BadMissive { get; } = null;

    /// <summary>
    /// this is the range of valid status codes 
    /// </summary>
    internal IReadOnlyList<MissiveStatusCodes> ValidStatusCodeList = new List<MissiveStatusCodes>
    {
        MissiveStatusCodes.InternalServerError,
        MissiveStatusCodes.MethodNotSupported,
        MissiveStatusCodes.GatewayError,
        MissiveStatusCodes.ServiceUnavailable,
        MissiveStatusCodes.GatewayTimeout,
        MissiveStatusCodes.VersionNotSupported,
        MissiveStatusCodes.InsufficientSpace,
        MissiveStatusCodes.NotExtended
    };

    /// <summary>
    /// the guid identifier for this missive
    /// </summary>
    public Guid MissiveID { get; }

    /// <summary>
    /// the list of all responses carried by this error
    /// </summary>
    private readonly List<IMissiveResponse> _ResponseList = new List<IMissiveResponse>();

    /// <summary>
    /// The missives formal response list
    /// </summary>
    /// <remarks>
    /// these are the formal responses 
    /// </remarks>
    public IList<IMissiveResponse> ResponseList => _ResponseList;

    /// <summary>
    /// the request which caused this missive to be created
    /// </summary>
    public IMissiveRequest? Request { get; } = null;

    /// <summary>
    /// the system failure status code
    /// </summary>
    private MissiveStatusCodes _StatusCode = MissiveStatusCodes.InternalServerError;

    /// <summary>
    /// the HTTP Status Code for this missive
    /// </summary>
    public MissiveStatusCodes StatusCode
    {
        get => _StatusCode;
        set
        {
            if (!ValidStatusCodeList.Contains(value))
                throw new MissiveOutOfRangeException(this, ValidStatusCodeList.ToList(), value);

            _StatusCode = value;
        }
    }

    /// <summary>
    /// the failed missive
    /// </summary>
    /// <param name="badMissive">the failed missive</param>
    /// <param name="statusCode">the status code for this missive</param>
    public SystemFailureMissive(IMissive? badMissive, 
                    MissiveStatusCodes statusCode 
                        = MissiveStatusCodes.InternalServerError)
    {

        StatusCode = statusCode;
        if (badMissive is null)
        {
            MissiveID = Guid.NewGuid();
            return;
        }
        
        BadMissive = badMissive;
        MissiveID = badMissive.MissiveID;

    }

}