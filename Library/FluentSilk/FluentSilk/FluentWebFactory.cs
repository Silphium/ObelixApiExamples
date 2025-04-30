using FluentSilk.Knot.Frame;
using FluentSilk.Knot.Head;

namespace FluentSilk;

public static class FluentWebFactory
{
    /// <summary>
    /// mutates the IFluentWeb component creating a basic
    /// declaration 
    /// </summary>
    /// <param name="source">the fluent web component</param>
    /// <returns>the mutated fluent web component</returns>
    public static FluentWeb CreateWebPage(this FluentWeb source, string? title = null)
    {
        if (source.SpiderWeb is not null) return source;

        if (source is not { } Target) return source;

        var Frame = new RadialFrame();

        if (!string.IsNullOrEmpty(title))
            Frame.Head.AddTitle(title);

        Target.SpiderWeb = Frame;

        return Target;
    }
}