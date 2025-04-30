// /**********************************************************************************
//  * File : DesignBox.cs
//  * Date: 20250302
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PrintInspector.Principals.Shapes;

/// <summary>
/// describes a box 
/// </summary>
public class DesignBox: IDesignBox
{
    /// <summary>
    /// the design corners
    /// </summary>
    public List<DesignPoint> Corners { get; private set; }

    /// <summary>
    /// the four lines making up this box
    /// </summary>
    public List<DesignLine> Lines { get; private set; }

    /// <summary>
    /// Top LEFT box corner
    /// </summary>
    public int DeltaX { get; }
    
    /// <summary>
    /// the top most y co-ordinate
    /// </summary>
    public int DeltaY { get; }

    /// <summary>
    /// the design box width
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// the design box height
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// the area of the rectangle
    /// </summary>
    public int Area => Width * Height;

    /// <summary>
    /// calculates the four corners of the box
    /// </summary>
    /// <param name="lineWidth">the line width</param>
    public void CalculateCorners(int lineWidth = 1)
    {
        var RightX = (DeltaX + Width);
        var BottomY = (DeltaY + Height);

        var TopLeft = new DesignPoint(DeltaX, DeltaY);    
        var TopRight = new DesignPoint(RightX, DeltaY);
        var BottomLeft = new DesignPoint(DeltaX, BottomY);
        var BottomRight = new DesignPoint(RightX, BottomY);

        Corners = [TopLeft, TopRight, BottomLeft, BottomRight];

        var TopLine = new DesignLine(TopLeft, TopRight, lineWidth);
        var LeftLine = new DesignLine(TopLeft, BottomLeft, lineWidth);
        var BottomLine = new DesignLine(BottomLeft, BottomRight, lineWidth);
        var RightLine = new DesignLine(TopRight, BottomRight, lineWidth);

        Lines = [TopLine, LeftLine, BottomLine, RightLine];

    }

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="width">the width of the design box</param>
    /// <param name="height">the height of the design box</param>
    /// <param name="deltaX">the left most x co-ordinate of the box</param>
    /// <param name="deltaY">the top most y co-ordinate of the box</param>
    public DesignBox(int width, int height, int deltaX = 0, int deltaY = 0)
    {
        Width = width;
        Height = height;
        DeltaX = deltaX;
        DeltaY = deltaY;
    }
}