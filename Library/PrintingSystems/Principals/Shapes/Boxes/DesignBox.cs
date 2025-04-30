// /**********************************************************************************
//  * File : DesignBox.cs
//  * Date: 20250322
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;
using PrintingSystems.Principals.Shapes.Lines;
using PrintingSystems.Principals.Shapes.Points;

namespace PrintingSystems.Principals.Shapes.Boxes;

public class DesignBox : IDesignPoints
{
    /// <summary>
    /// the corners of the box
    /// </summary>
    public List<DesignCoordinate> Corners { get; } = [];
    
    /// <summary>
    /// the list of boxes used by 
    /// </summary>
    public List<DesignBox> Boxes { get; } = [];
    
    /// <summary>
    /// the name of this set of design points
    /// </summary>
    public string Name { get; protected internal set; } = string.Empty;

    /// <summary>
    /// the list of design points
    /// </summary>
    public List<IDesignPoint> Points { get; protected internal set; } = [];

    /// <summary>
    /// the width of the box
    /// </summary>
    public IDesignPoint Width { get;  protected internal set; }

    /// <summary>
    /// the height of the box
    /// </summary>
    public IDesignPoint Height { get; protected internal set; }


    /// <summary>
    /// the number of layer count
    /// </summary>
    internal int LayerCount { get; set; } = 0;


    internal DesignBox()
    {
    }

    /// <summary>
    /// constructor 
    /// </summary>
    /// <param name="leftX">the leftmost x co-ordinate</param>
    /// <param name="topY">the topmost y co-ordinate</param>
    /// <param name="width">the width of the box</param>
    /// <param name="height">the height of the box</param>
    public DesignBox(int leftX, int topY, int width, int height)
    {
        var TopLeft = new DesignCoordinate(leftX, topY);
        Corners.Add(TopLeft);
        
        var TopRight = new DesignCoordinate(leftX + width, topY);
        Corners.Add(TopRight);

        var BottomLeft = new DesignCoordinate(leftX, (topY + height));
        Corners.Add(BottomLeft);

        var BottomRight = new DesignCoordinate((leftX + width), (topY + height));
        Corners.Add(BottomRight);


        Width = new DesignPoint(width);
        Width.AddName(DesignBoxBuilder.WidthToken);
        Points.Add(Width);

        Height = new DesignPoint(height);
        Height.AddName(DesignBoxBuilder.HeightToken);
        Points.Add(Height);    
    }

    /// <summary>
    /// constructor using the top left and bottom right co-ordinates 
    /// </summary>
    /// <param name="topLeft">the top left co-ordinate</param>
    /// <param name="bottomRight">the bottom right co-ordinate</param>
    public DesignBox(DesignCoordinate topLeft, DesignCoordinate bottomRight)
    {
        Corners.Add(topLeft);
        var TopRight = new DesignCoordinate(bottomRight.DeltaX, topLeft.DeltaY);
        Corners.Add(TopRight);

        var BottomLeft = new DesignCoordinate(topLeft.DeltaX, bottomRight.DeltaY);
        Corners.Add(BottomLeft);
        Corners.Add(bottomRight);


        var TopHorizontal = new DesignLine(topLeft, TopRight);
        Width = TopHorizontal.DeltaX;
        Width.AddName(DesignBoxBuilder.WidthToken);
        Points.Add(Width);

        var LeftVertical = new DesignLine(topLeft, BottomLeft);
        Height = LeftVertical.DeltaY;
        Height.AddName(DesignBoxBuilder.HeightToken);
        Points.Add(Height);

    }
}