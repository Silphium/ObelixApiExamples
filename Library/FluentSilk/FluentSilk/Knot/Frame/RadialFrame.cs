using System.Xml;
using System.Xml.Linq;
using FluentSilk.Knot.Body;
using FluentSilk.Knot.Head;
using FluentSilk.Threads;

namespace FluentSilk.Knot.Frame;

/// <summary>
/// this class is used to describe a full web page
/// </summary>
public class RadialFrame : SpiderKnot
{
    private static readonly List<string> ValidLanguages = ["en"];

    private string _Language = ValidLanguages[0];

    /// <summary>
    /// the language used by the
    /// </summary>
    public string Language
    {
        get => _Language;
        set
        {
            if (string.CompareOrdinal(_Language, value) == 0) return;

            if(!ValidLanguages.Contains(value)) return;

            _Language = value;
        }
    }
    
    /// <summary>
    /// the html document head
    /// </summary>
    public FrameHead Head { get; }

    /// <summary>
    /// the html document body
    /// </summary>
    public FrameBody Body { get; }
    
    /// <summary>
    /// constructor
    /// </summary>
    public RadialFrame() : base("html")

    {
        Head = new FrameHead();
        Dependants.Add(Head);

        Body = new FrameBody();
        Dependants.Add(Body);

    }

}