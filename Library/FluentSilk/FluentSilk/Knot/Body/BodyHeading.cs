using System.ComponentModel.DataAnnotations;
using FluentSilk.Threads;

namespace FluentSilk.Knot.Body;

public class BodyHeading : SpiderKnot
{


    /// <summary>
    /// the heading level
    /// </summary>
    private int _HeadingLevel = 1;

    /// <summary>
    /// th
    /// </summary>
    public int HeadingLevel
    {
        get => _HeadingLevel;
        set
        {
            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if(value < 1) return;

            if(value > 6 )return;

            _HeadingLevel = value;
        }
    }

    /// <summary>
    /// creates a body heading 
    /// </summary>
    /// <param name="headingLevel"></param>
    public BodyHeading(int headingLevel):base("h")
    {
        HeadingLevel = headingLevel;
    }


}