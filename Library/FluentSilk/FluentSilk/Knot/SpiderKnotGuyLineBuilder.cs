using FluentSilk.Threads;

namespace FluentSilk.Knot;

public static class SpiderKnotGuyLineBuilder
{
    /// <summary>
    /// string identifier for the html ID tag 
    /// </summary>
    private static readonly string BoxIdentifier = "id";

    /// <summary>
    /// string identifier for the html Class tag
    /// </summary>
    private static readonly string BoxClassIdentifier = "class";

    /// <summary>
    /// adds an attribute to an html element
    /// </summary>
    /// <param name="source">the source spider knot</param>
    /// <param name="guyName">the attribute name</param>
    /// <param name="guyValue">the attribute value</param>
    /// <returns></returns>
    public static SpiderKnot AddGuyLine(this SpiderKnot source, string guyName, string guyValue)
        => source.AddGuyLine(new GuyLine(guyName, guyValue));


    /// <summary>
    /// adds an attribute to an element 
    /// </summary>
    /// <param name="source">the source spider knot</param>
    /// <param name="guyLine">the </param>
    /// <returns></returns>
    public static SpiderKnot AddGuyLine(this SpiderKnot source, GuyLine guyLine)
    {
        var TestLine = source.GuyLines.FirstOrDefault(node => string.CompareOrdinal(guyLine.LineName, node.LineName) == 0);
        if (TestLine is not null) return source;

        source.GuyLines.Add(guyLine);

        return source;
    }

    /// <summary>
    /// adds an id attribute to the html element represented by
    /// the parameter source 
    /// </summary>
    /// <param name="source">the source spider knot</param>
    /// <param name="knotID">the box id</param>
    /// <returns>the mutated spider knot</returns>
    public static SpiderKnot AddBoxID(this SpiderKnot source, string knotID)
        => source.AddGuyLine(BoxIdentifier, knotID);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="classID">the box's class id</param>
    /// <returns></returns>
    public static SpiderKnot AddClassID(this SpiderKnot source, string classID)
        => source.AddGuyLine(BoxClassIdentifier, classID);
}   