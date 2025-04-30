namespace DesignPrinter.Missives.Details;

/// <summary>
/// root interface for 
/// </summary>
public interface IMissiveResponse
{
    /// <summary>
    /// the type of response 
    /// </summary>
    public string ResponseType { get; }

    /// <summary>
    /// the data for the response
    /// </summary>
    public string ResponseData { get; }
}