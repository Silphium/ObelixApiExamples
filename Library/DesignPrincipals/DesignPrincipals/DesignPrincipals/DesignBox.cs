// /**********************************************************************************
//  * File : DesignBox.cs
//  * Date: 20250302
//  * Author: Keith Douglas
//  **********************************************************************************/

namespace DesignPrincipals;

/// <summary>
/// describes a box 
/// </summary>
public class DesignBox: IDesignBox
{
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