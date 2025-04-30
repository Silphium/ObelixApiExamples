// /**********************************************************************************
//  * File : DesignLine.cs
//  * Date: 20250321
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Collections.Generic;
using System.Dynamic;
using System.Security.AccessControl;
using PrintingSystems.Principals.Shapes.Points;

namespace PrintingSystems.Principals.Shapes.Lines;



public class DesignLine : IDesignPoints
{
    /// <summary>
    /// the name of this set of design points
    /// </summary>
    public string Name { get; } = string.Empty;

    /// <summary>
    /// the list of design points
    /// </summary>
    public List<IDesignPoint> Points { get; }

    /// <summary>
    /// the anchor point of the line
    /// </summary>
    public DesignCoordinate Anchor { get; }

    /// <summary>
    /// the sentinal point of the line
    /// </summary>
    public DesignCoordinate Sentinal { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="anchor"></param>
    /// <param name="sentinal"></param>
    public DesignLine(DesignCoordinate anchor, DesignCoordinate sentinal) 
    {
        Anchor = anchor;
        Sentinal = sentinal;
        Points = [];
    }

    /// <summary>
    /// the difference between the two x co-ordinates
    /// </summary>
    /// <remarks>
    /// calculation: sentinal - anchor
    /// </remarks>
    public IDesignPoint DeltaX
    {
        get
        {
            switch (Anchor.DeltaX)
            {
                case DesignPoint AnchorX
                    when (Sentinal.DeltaX is DesignPoint SentinalX):
                    return new DesignPoint(SentinalX.PointValue - AnchorX.PointValue);
                case FloatingDesignPoint FloatingAnchor
                    when (Sentinal.DeltaX is FloatingDesignPoint FloatingSentinal):
                    return new FloatingDesignPoint(FloatingSentinal.PointValue - FloatingAnchor.PointValue);
                default:
                    return new DesignPoint(0);
            }
        }

    }

    /// <summary>
    /// returns the difference between the two y values
    /// </summary>
    public IDesignPoint DeltaY 
    {
        get
        {
            switch (Anchor.DeltaY)
            {
                case DesignPoint AnchorY 
                    when (Sentinal.DeltaY is DesignPoint SentinalY):
                    return new DesignPoint(SentinalY.PointValue - AnchorY.PointValue);
                case FloatingDesignPoint FloatingAnchor
                    when (Sentinal.DeltaY is FloatingDesignPoint FloatingSentinal):
                    return new FloatingDesignPoint(FloatingSentinal.PointValue - FloatingAnchor.PointValue);
                default:
                    return new DesignPoint(0);
            }
        }
    }
    
}