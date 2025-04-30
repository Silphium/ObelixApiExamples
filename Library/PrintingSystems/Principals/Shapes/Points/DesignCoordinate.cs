// /**********************************************************************************
//  * File : IDesignCoordinate.cs
//  * Date: 20250321
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Collections.Generic;

namespace PrintingSystems.Principals.Shapes.Points;

public class DesignCoordinate
{
    /// <summary>
    /// list representation of the co-ordinates
    /// </summary>
    public List<IDesignPoint> Points { get; } = [];

    /// <summary>
    /// the X-Coordinate 
    /// </summary>
    public IDesignPoint DeltaX { get; }

    /// <summary>
    /// the Y-Coordinate
    /// </summary>
    public IDesignPoint DeltaY { get; }

    /// <summary>
    /// constructor using integers
    /// </summary>
    /// <param name="deltaX">the x-coordinate</param>
    /// <param name="deltaY">the y-coordinate</param>
    public DesignCoordinate(int deltaX, int deltaY)
    {
        DeltaX = new DesignPoint(deltaX);
        Points.Add(DeltaX);
        DeltaY = new DesignPoint(deltaY);
        Points.Add(DeltaY);
    }

    /// <summary>
    /// constructor using doubles
    /// </summary>
    /// <param name="deltaX">the x-coordinate</param>
    /// <param name="deltaY">the y-coordinate</param>
    public DesignCoordinate(double deltaX, int deltaY)
    {
        DeltaX = new FloatingDesignPoint(deltaX);
        Points.Add(DeltaX);
        DeltaY = new FloatingDesignPoint(deltaY);
        Points.Add(DeltaY);
    }

    /// <summary>
    /// constructor using two know design points
    /// </summary>
    /// <param name="deltaX">the x co-ordinate</param>
    /// <param name="deltaY">the y co-ordinate</param>
    public DesignCoordinate(IDesignPoint deltaX, IDesignPoint deltaY)
    {
        DeltaX = deltaX;
        Points.Add(DeltaX);

        DeltaY = deltaY;
        Points.Add(DeltaY);
    }


}