namespace FluentSilk.Threads;

public class GuyLine(string lineName, object lineValue)
{
    /// <summary>
    /// the name of the line
    /// </summary>
    public string LineName { get; } = lineName;

    /// <summary>
    /// the line value
    /// </summary>
    public object LineValue { get; } = lineValue;

}