using System.Xml.Linq;
using FluentSilk.Threads;

namespace FluentSilk.Knot;


/// <summary>
/// the basic knot
/// </summary>
/// <param name="token">the primary rendering value</param>
public class SpiderKnot(string token, string? knotValue = null) 
{
    /// <summary>
    /// the token this knot uses to express itself
    /// </summary>
    public string Token { get; } = token;

    /// <summary>
    /// the value of the knot
    /// </summary>
    public string? KnotValue { get; } = knotValue;

    /// <summary>
    /// list of all the dependents 
    /// </summary>
    public List<SpiderKnot> Dependants { get; } = [];

    /// <summary>
    /// the guy line
    /// </summary>
    public List<GuyLine> GuyLines { get; } = [];

    /// <summary>
    /// the XElement representation fo the knot
    /// its attributes and its dependants.
    /// </summary>
    public XElement? Node { get; protected set; } = null;

    /// <summary>
    /// renders the document into html
    /// </summary>
    public virtual XElement Render()
    {

        if (Node is not null) return Node;

        Node = new XElement(XName.Get(Token));

        for (var C = 0; C < GuyLines.Count; C++)
        {
            var NodeGuy = new XAttribute(GuyLines[C].LineName, GuyLines[C].LineValue);
            Node.Add(NodeGuy);
        }

        for (var C = 0; C < Dependants.Count; C++)
            Node.Add(Dependants[C].Render());

        if (KnotValue is null) return Node;

        Node.Value = KnotValue;
        return Node;

    }


}