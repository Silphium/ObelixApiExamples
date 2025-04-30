using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPrinter.Dowding.Radar;

/// <summary>
/// contains all data required to
/// create an end point
/// </summary>
public class ApexEndPoint
{
    /// <summary>
    /// the guid identifier
    /// </summary>
    public readonly Guid Identifier;
    
    /// <summary>
    /// the protocol for this endpoint
    /// </summary>
    public string Protocol { get; } = string.Empty;

    /// <summary>
    /// the uri 
    /// </summary>
    public string ResourceIdentifier { get; } = string.Empty;

    /// <summary>
    /// the port required for this endpoint
    /// </summary>
    public int Port { get; } = 0;

    /// <summary>
    /// the list of suffix 
    /// </summary>
    public List<string> SuffixList { get; } = new List<string>();

    /// <summary>
    /// stores the full address
    /// </summary>
    private string _FullAddress = string.Empty;

    /// <summary>
    /// constructor
    /// </summary>
    internal ApexEndPoint()
    {
        Identifier = Guid.NewGuid();
        SuffixList = new List<string>();


    }

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="protocol"></param>
    /// <param name="resourceIdentifier"></param>
    /// <param name="port"></param>
    /// <param name="suffixList"></param>
    public ApexEndPoint(string protocol, string resourceIdentifier, int port, List<string> suffixList)
    {
        Identifier = Guid.NewGuid();
        Protocol = protocol;
        ResourceIdentifier = resourceIdentifier;
        Port = port;
        
        if(suffixList.Count == 0) return;

        SuffixList.AddRange(suffixList);


    }


    /// <summary>
    /// constructs are returns the universal resource locator
    /// </summary>
    /// <returns>the url9</returns>
    public string GetURL()
    {
        if (!string.IsNullOrEmpty(_FullAddress)) return _FullAddress;

        var AddressBuilder = new StringBuilder(150)
            .Append(Protocol)
            .Append("://")
            .Append(ResourceIdentifier);

        if (Port > 0) AddressBuilder.Append(':').Append(Port);
        
        AddressBuilder.Append('/');
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var Index = 0; Index < SuffixList.Count; Index++) 
            AddressBuilder.Append(SuffixList[Index]).Append('/');
        
        _FullAddress = AddressBuilder.ToString();
        return _FullAddress;

    }

}