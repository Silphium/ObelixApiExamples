// /**********************************************************************************
//  * File : DesignLayer.cs
//  * Date: 20250327
//  * Author: Keith Douglas
//  **********************************************************************************/

using PrintingSystems.Principals.Shapes.Points;

namespace PrintingSystems.Principals.Shapes.Boxes;


public class DesignLayer : DesignBox
{
    /// <summary>
    /// constructor 
    /// </summary>
    /// <param name="leftX">the leftmost x co-ordinate</param>
    /// <param name="topY">the topmost y co-ordinate</param>
    /// <param name="width">the width of the box</param>
    /// <param name="height">the height of the box</param>
    public DesignLayer(int leftX, int topY, int width, int height) : base(leftX, topY, width, height)
    {
    }

    /// <summary>
    /// constructor using the top left and bottom right co-ordinates 
    /// </summary>
    /// <param name="topLeft">the top left co-ordinate</param>
    /// <param name="bottomRight">the bottom right co-ordinate</param>
    public DesignLayer(DesignCoordinate topLeft, DesignCoordinate bottomRight) : base(topLeft, bottomRight)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bounds"></param>
    public DesignLayer(DesignBox bounds)
    {

        Corners.AddRange(bounds.Corners);
        Width = bounds.Width;
        Height = bounds.Height;


    }
}