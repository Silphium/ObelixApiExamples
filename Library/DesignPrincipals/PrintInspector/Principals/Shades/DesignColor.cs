// /**********************************************************************************
//  * File : DesignColor.cs
//  * Date: 20250314
//  * Author: Keith Douglas
//  **********************************************************************************/

namespace PrintInspector.Principals.Shades;


public class DesignColor(int red, int green, int blue, int alpha=0)
{
    /// <summary>
    /// the red value
    /// </summary>
    public int Red { get; } = red;

    /// <summary>
    /// the green value
    /// </summary>
    public int Green { get; } = green;

    /// <summary>
    /// and the blue value
    /// </summary>
    public int Blue { get; } = blue;


    /// <summary>
    /// the alpha channel value
    /// </summary>
    public int Alpha { get; } = alpha;


}