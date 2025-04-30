namespace FluentSilk.Threads;

public class DesignStyle
{
    /// <summary>
    /// the list of targets for this Style Declaration
    /// </summary>
    public readonly List<string> Targets = [];

    /// <summary>
    /// the list of all the CSS properties to be used
    /// with this cascading style.
    /// </summary>
    public readonly List<string> Properties = [];
    
}