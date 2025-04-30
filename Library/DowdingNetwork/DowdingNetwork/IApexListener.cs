using DesignReporting.Missives;
using DowdingNetwork.Radar;

namespace DowdingNetwork;


/// <summary>
/// interface for the apex listener
/// </summary>
public interface IApexListener
{
    /// <summary>
    /// the group name for this handler
    /// </summary>
    public string GroepsNaam { get; }

    /// <summary>
    /// the list of end points supported by this listener
    /// </summary>
    public List<ApexEndPoint> EndPoints { get; }

    /// <summary>
    /// the list of responders for this 
    /// </summary>
    public List<ApexMethodHandler> MethodResponders { get; }

    /// <summary>
    /// used to start the listener
    /// </summary>
    /// <returns>a report of this operation</returns>
    public IMissive Open();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IMissive Close();


}