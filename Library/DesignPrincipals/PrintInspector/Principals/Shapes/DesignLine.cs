// /**********************************************************************************
//  * File : DesignLine.cs
//  * Date: 20250302
//  * Author: Keith Douglas
//  **********************************************************************************/

using PrintInspector.Principals.Shades;

namespace PrintInspector.Principals.Shapes;

/// <summary>
/// stores the representation of line
/// </summary>
public class DesignLine(DesignPoint anchor, DesignPoint sentinal, int lineWidth = 1)
{
    /// <summary>
    /// the anchor point of the line
    /// </summary>
    public DesignPoint Anchor { get; } = anchor;
    
    /// <summary>
    /// the sentinal point of the line
    /// </summary>
    public DesignPoint Sentinal { get; } = sentinal;

    /// <summary>
    /// the width of the line
    /// </summary>
    public int LineWidth { get; } = lineWidth;

    /// <summary>
    /// the fill color
    /// </summary>
    public DesignColor FillColor { get; set; } = new DesignColor(0, 0, 0);

}