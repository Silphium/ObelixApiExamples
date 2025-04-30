namespace FluentSilk.Knot.Work;

public static class KnotWorkFactory
{
    /// <summary>
    /// adds a string text value for 
    /// </summary>
    /// <param name="source">the source knot</param>
    /// <param name="text">the text value</param>
    /// <returns>the mutated knot</returns>
    public static SpiderKnot AddStringText(this SpiderKnot source, string text)
    {
        var Text = new SpiderText(text);
        source.Dependants.Add(Text);

        return source;
    }



}