// /**********************************************************************************
//  * File : DesignPoint.cs
//  * Date: 20250314
//  * Author: Keith Douglas
//  **********************************************************************************/

namespace PrintInspector.Principals.Shapes;

/// <summary>
/// contains the x and y co-ordinate of a point
/// </summary>
public class DesignPoint(int designX, int designY)
{
    /// <summary>
    /// the x co-ordinate
    /// </summary>
    public int DesignX { get; set; } = designX;

    /// <summary>
    /// the y co-ordinate
    /// </summary>
    public int DesignY { get; set; } = designY;

}