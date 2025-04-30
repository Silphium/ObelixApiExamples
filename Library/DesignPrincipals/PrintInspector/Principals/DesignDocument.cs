using System;
using System.Collections.Generic;
using PrintInspector.Principals.Layers;
using PrintInspector.Principals.Shapes;

namespace PrintInspector.Principals;

/// <summary>
/// holds the dimensions of the document
/// </summary>
public class DesignDocument : IDesignBox
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
    /// the document layers
    /// </summary>
    public List<IDesignLayer> Layers { get; } = [];

    /// <summary>
    /// the left most x co-ordinate
    /// </summary>
    public int DeltaX => 0;

    /// <summary>
    /// the top most y co-ordinate
    /// </summary>
    public int DeltaY => 0;
    
    /// <summary>
    /// internal representation of the width
    /// </summary>
    private int _Width;

    /// <summary>
    /// the width of the document
    /// </summary>
    public int Width
    {
        get => _Width;
        set
        {
            if (_Width == value) return;
            if(value < 1) return;
            _Width = value;
        }
    }

    /// <summary>
    ///  internal representation of the document height
    /// </summary>
    private int _Height;

    /// <summary>
    /// tjh
    /// </summary>
    public DesignBox Margin { get; internal set; }

    /// <summary>
    /// the height of the document
    /// </summary>
    public int Height
    {
        get => _Height;
        set
        {
            if(_Height == value) return;
            if(_Height < 1) return;
            _Height = value;
        }
    }

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
        Margin.CalculateCorners(lineWidth);
        Corners = [];
        Corners.AddRange(Margin.Corners);

        Lines = [];
        Lines.AddRange(Margin.Lines);

    }

    

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="width">the width of the document</param>
    /// <param name="height">the height of the document</param>
    public DesignDocument(int width, int height)
    {
        _Width = width;
        _Height = height;

        Margin = new DesignBox(_Width, Height);
    }

}