// /**********************************************************************************
//  * File : IDesignBox.cs
//  * Date: 20250302
//  * Author: Keith Douglas
//  **********************************************************************************/

namespace DesignPrincipals;

/// <summary>
/// common feature interface
/// </summary>
public interface IDesignBox
{
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
    int Area => Height * Width;
}