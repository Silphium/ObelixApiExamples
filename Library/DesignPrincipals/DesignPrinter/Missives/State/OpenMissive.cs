using System;
using System.Collections.Generic;
using System.Linq;
using DesignPrinter.Missives.Details;
using DesignPrinter.Missives.Error;

namespace DesignPrinter.Missives.State;

public class OpenMissive : IMissive
{

    /// <summary>
    /// readonly list of all the valid status codes for this missive
    /// </summary>
    internal static IReadOnlyList<MissiveStatusCodes> ValidStatusCodeList
        = new List<MissiveStatusCodes>
        {
            MissiveStatusCodes.Continue,
            MissiveStatusCodes.SwitchingProtocols,
            MissiveStatusCodes.Processing,
            MissiveStatusCodes.EarlyHints,
            MissiveStatusCodes.Created,
            MissiveStatusCodes.Accepted
        };


    /// <summary>
    /// the current status code for this missive
    /// </summary>
    private MissiveStatusCodes _StatusCode = MissiveStatusCodes.Created;

    /// <summary>
    /// the guid identifier for this missive
    /// </summary>
    public Guid MissiveID { get; } = Guid.NewGuid();

    /// <summary>
    /// private list container for the missive responses
    /// </summary>
    private readonly List<IMissiveResponse> _ResponseList = new List<IMissiveResponse>();

    /// <summary>
    /// The missives formal response
    /// </summary>
    public IList<IMissiveResponse> ResponseList => _ResponseList;

    /// <summary>
    /// the request which caused this missive to be created
    /// </summary>
    public IMissiveRequest? Request { get; }

    /// <summary>
    /// the HTTP Status Code for this missive
    /// </summary>
    public MissiveStatusCodes StatusCode
    {
        get => _StatusCode;
        set
        {
            if (_StatusCode == value) return;

            if (!ValidStatusCodeList.Contains(value))
                throw new MissiveOutOfRangeException(this, ValidStatusCodeList.ToList(), value);

            _StatusCode = value;
        }
    }

    /// <summary>
    /// constructor
    /// </summary>
    /// <remarks>
    /// this has been declared to prevent creation of this class outside
    /// the assembly
    /// </remarks>
    internal OpenMissive() { }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    internal OpenMissive(IMissiveRequest request)
    {
        Request = request;
    }

}