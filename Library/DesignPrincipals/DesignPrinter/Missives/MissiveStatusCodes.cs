namespace DesignPrinter.Missives;

/// <summary>
/// an enumeration of http status codes
/// </summary>
/// <remarks>
/// this is a more complete version than supplied by system.net
/// 1xx - Information Response
/// 2xx
/// </remarks>
public enum MissiveStatusCodes : int
{

    Continue = 100, 
    SwitchingProtocols = 101,
    Processing = 102,
    EarlyHints = 103,
    OK = 200,
    Created = 201,
    Accepted = 202,
    NonAuthoritativeInformation = 203,
    NoContent = 204,
    ResetContent = 205,
    PartialContent = 206,
    MultipleChoices = 300,
    ResourceMovedPermanently = 301,
    ResourceMovedTemporarily = 302,
    SeeAnotherResource = 303,
    ResourceNotModified = 304,
    UseProxy = 305,
    TemporaryRedirection = 308,
    BadRequest = 400,
    UnauthorizedRequest = 401, 
    PaymentRequired = 402,
    Forbidden = 403,
    PageNotFound = 404,
    MethodNotAllowed = 405, 
    NotAcceptable = 406,
    ProxyAuthenticationRequired = 407,
    RequestTimeout = 408,
    Conflict = 409,
    ResourceUnavailable = 410, 
    LengthRequired = 411,
    PreconditionFailed = 412,
    EntityTooLarge = 413,
    UrlTooLong = 414,
    UnsupportedMediaType = 415,
    RequestRangeNotSatisfiable = 416,
    ExpectationFailed = 417,
    Teapot = 418,
    UnprocessableEntity = 422,
    Locked = 423,
    FailedDependency = 424,
    UpgradeRequired = 426,
    InternalServerError = 500,
    MethodNotSupported = 501,
    GatewayError = 502,
    ServiceUnavailable = 503,
    GatewayTimeout = 504,
    VersionNotSupported = 505,
    InsufficientSpace = 507,
    NotExtended = 510

}