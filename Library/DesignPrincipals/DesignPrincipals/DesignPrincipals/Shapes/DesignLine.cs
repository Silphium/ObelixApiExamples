// /**********************************************************************************
//  * File : DesignLine.cs
//  * Date: 20250302
//  * Author: Keith Douglas
//  **********************************************************************************/

namespace PrincipalAffirmation;

/// <summary>
/// stores the representation of line
/// </summary>
public class DesignLine(int anchorX, int anchorY,  int sentinalX, int sentinalY)
{
    /// <summary>
    /// the anchor x co-ordinate
    /// </summary>
    public int AnchorX { get; } = anchorX;

    /// <summary>
    /// the anchorY co-ordinate
    /// </summary>
    public int AnchorY { get; } = anchorY;

    /// <summary>
    /// the sentinal x co-ordinate
    /// </summary>
    public int SentinalX { get; } = sentinalX;

    /// <summary>
    /// the sentinal y cio
    /// </summary>
    public int SentinalY { get; } = sentinalY;

}