namespace DesignReporting.Notes;

/// <summary>
/// composition interface: used for
/// extending a component with logging 
/// </summary>
public interface IDesignNote
{
    /// <summary>
    /// writes a note to the log file
    /// </summary>
    void WriteNode();

}