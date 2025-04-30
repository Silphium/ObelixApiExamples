// /**********************************************************************************
//  * File : IDesignBox.cs
//  * Date: 20250302
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Collections.Generic;

namespace PrintInspector.Principals.Shapes;

/// <summary>
/// common feature interface
/// </summary>
public interface IDesignBox
{
    /// <summary>
    /// the design corners
    /// </summary>
    public List<DesignPoint> Corners { get; } 

    /// <summary>
    /// the four lines making up this box
    /// </summary>
    public List<DesignLine> Lines { get; }

    /// <summary>
    /// the left most x co-ordinate
    /// </summary>
    int DeltaX { get; }
    
    /// <summary>
    /// the top most y co-ordinate
    /// </summary>
    int DeltaY { get; }
    
    /// <summary>
    /// the design box width
    /// </summary>
    int Width { get; }
    
    /// <summary>
    /// the design box height
    /// </summary>
    int Height { get; }

    /// <summary>
    /// the area of the rectangle
    /// </summary>
    int Area { get; }

    /// <summary>
    /// calculates the four corners of the box
    /// </summary>
    /// <param name="lineWidth">the line width</param>
    void CalculateCorners(int lineWidth = 1);

}