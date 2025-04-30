using System.Collections.Generic;

namespace DesignPrinter.Dowding.Request;


/// <summary>
/// the apex parameter request type
/// </summary>
public interface IApexParameterRequest : IApexMissiveRequest
{
    
    
    /// <summary>
    /// the contents of the request
    /// </summary>
    public IDictionary<string,object> Parameters { get; }


}  