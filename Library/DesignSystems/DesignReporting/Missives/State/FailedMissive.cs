using DesignReporting.Missives.Details;
using DesignReporting.Missives.Error;


namespace DesignReporting.Missives.State;

/// <summary>
/// failed missive class
/// </summary>
internal class FailedMissive : IFailedMissive
{
    /// <summary>
    /// the list of all acceptable status codes for this missive type
    /// </summary>
    internal static IReadOnlyList<MissiveStatusCodes> ValidStatusCodes
        = new List<MissiveStatusCodes>

        {
            MissiveStatusCodes.NoContent,
            MissiveStatusCodes.ResetContent,
            MissiveStatusCodes.BadRequest,
            MissiveStatusCodes.UnauthorizedRequest,
            MissiveStatusCodes.PaymentRequired,
            MissiveStatusCodes.Forbidden,
            MissiveStatusCodes.PageNotFound,
            MissiveStatusCodes.MethodNotAllowed,
            MissiveStatusCodes.NotAcceptable,
            MissiveStatusCodes.ProxyAuthenticationRequired,
            MissiveStatusCodes.RequestTimeout,
            MissiveStatusCodes.Conflict,
            MissiveStatusCodes.ResourceUnavailable,
            MissiveStatusCodes.LengthRequired,
            MissiveStatusCodes.PreconditionFailed,
            MissiveStatusCodes.EntityTooLarge,
            MissiveStatusCodes.UrlTooLong,
            MissiveStatusCodes.UnsupportedMediaType,
            MissiveStatusCodes.RequestRangeNotSatisfiable,
            MissiveStatusCodes.ExpectationFailed,
            MissiveStatusCodes.Teapot,
            MissiveStatusCodes.UnprocessableEntity,
            MissiveStatusCodes.Locked,
            MissiveStatusCodes.FailedDependency,
            MissiveStatusCodes.UpgradeRequired

        };

    /// <summary>
    /// a record of the missive which caused the failure
    /// </summary>
    public IMissive? BadMissive { get; }

    /// <summary>
    /// the guid id of this missive
    /// </summary>
    /// <remarks>
    /// empty is not valid for the guid value
    /// </remarks>
    public Guid MissiveID { get; }

    /// <summary>
    /// list storage for this missive's responses
    /// </summary>
    private readonly List<IMissiveResponse> _ResponseList = [];

    /// <summary>
    /// the list if responses for this missive
    /// </summary>
    public IList<IMissiveResponse> ResponseList => _ResponseList;

    /// <summary>
    /// the basic status code 
    /// </summary>
    private MissiveStatusCodes _StatusCode = MissiveStatusCodes.BadRequest;

    /// <summary>
    /// the http status code for this missive 
    /// </summary>
    /// <remarks>
    /// this value must be between 400 and 499
    /// </remarks>
    public MissiveStatusCodes StatusCode
    {
        get => _StatusCode;
        set
        {
            if (_StatusCode == value) return;

            if (!ValidStatusCodes.Contains(value))
                throw new MissiveOutOfRangeException(this, ValidStatusCodes.ToList(), value);


            _StatusCode = value;
        }
    }

    /// <summary>
    /// constructor for the failed missive
    /// </summary>
    /// <param name="badMissive">the source of the failure</param>
    internal FailedMissive(IMissive? badMissive)
    {
        if (badMissive is null)
        {
            MissiveID = Guid.NewGuid();
            return;
        }

        MissiveID = badMissive.MissiveID;
        BadMissive = badMissive;

    }

}
