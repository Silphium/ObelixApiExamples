using FluentSilk.Knot.Work;
using FluentSilk.Threads;

namespace FluentSilk.Knot.Head;

public static class KnotHeadContextExtender
{
    /// <summary>
    /// adds the document title to the html page
    /// </summary>
    /// <param name="source">the source spider knot</param>
    /// <param name="titleText">the title text</param>
    /// <returns>the mutated spider knot</returns>
    public static SpiderKnot AddTitle(this SpiderKnot source, string titleText)
    {
        const string titleTag = "title";

        var TestKnot = source.Dependants.FirstOrDefault(node => 
                                string.CompareOrdinal(titleTag, node.Token) == 0);

        if (TestKnot is not null) return source;

        var TitleKnot = new SpiderKnot(titleTag, titleText);
        source.Dependants.Add(TitleKnot);
        
        return source;
    }

    /// <summary>
    /// html meta token
    /// </summary>
    private static readonly string MetaToken = "meta";

    /// <summary>
    /// creates a meta reference im the head section of the document
    /// using a single attribute expressed by name and value
    /// </summary>
    /// <param name="source">the source spider knot</param>
    /// <param name="metaName">the attribute name</param>
    /// <param name="metaValue">the attribute value</param>
    /// <returns>the mutated spider knot</returns>
    public static SpiderKnot AddMeta(this SpiderKnot source, string metaName, string metaValue) 
        => source.AddMeta(new GuyLine(metaName, metaValue));
    
    /// <summary>
    /// creates a meta reference in the head section of the document
    /// using a single attribute expressed using a GuyLine instance
    /// </summary>
    /// <param name="source">the source spider knot</param>
    /// <param name="guyLine">guy line class containing the meta attributes</param>
    /// <returns>the mutated spider knot</returns>
    public static SpiderKnot AddMeta(this SpiderKnot source, GuyLine guyLine)
    {

        if (source is not FrameHead) return source;
        
        var MetaKnot = new SpiderKnot(MetaToken);
        MetaKnot.GuyLines.Add(guyLine);

        source.Dependants.Add(MetaKnot);

        return source;
    }

    /// <summary>
    /// creates a meta reference in the head section of the document
    /// using a list of GuyLine attributes 
    /// </summary>
    /// <param name="source">the source spider knot</param>
    /// <param name="guyLines">the list of attributes</param>
    /// <returns>the mutated spider knot</returns>
    public static SpiderKnot AddMeta(this SpiderKnot source, List<GuyLine> guyLines)
    {
        if (source is not FrameHead) return source;

        var MetaKnot = new SpiderKnot(MetaToken);
        MetaKnot.GuyLines.AddRange(guyLines);

        source.Dependants.Add(MetaKnot);

        return source;
    }


}