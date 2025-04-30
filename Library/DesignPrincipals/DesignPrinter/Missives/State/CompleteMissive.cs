using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using DesignPrinter.Missives.Details;

namespace DesignPrinter.Missives.State;


/// <summary>
/// concrete class for the interface ICompleteMissive
/// </summary>
/// <remarks>
/// HTTP Status Code 200 "OK" is the only valid status code
/// for this class
/// </remarks>
internal class CompleteMissive : ICompleteMissive
{
    /// <summary>
    /// the completed missive status code: always 200
    /// </summary>
    public MissiveStatusCodes StatusCode => MissiveStatusCodes.Accepted;

    /// <summary>
    /// the guid identifier for this missive
    /// </summary>
    public Guid MissiveID { get; }

    /// <summary>
    /// internal representation of the missive response list
    /// </summary>
    private readonly List<IMissiveResponse> _ResponseList = new List<IMissiveResponse>();

    /// <summary>
    /// the list of all responses
    /// </summary>
    public IList<IMissiveResponse> ResponseList => _ResponseList;

    /// <summary>
    /// the request which caused this missive to be created
    /// </summary>
    public IMissiveRequest? Request { get; }


    /// <summary>
    /// constructor for the completed missive with one response type
    /// </summary>
    internal CompleteMissive(IMissiveRequest? request = null)
    {
        MissiveID = Guid.Empty;
        Request = request;
    }

 
}