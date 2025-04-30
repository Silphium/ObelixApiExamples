// /**********************************************************************************
//  * File : DesignPointMediator.cs
//  * Date: 20250321
//  * Author: Keith Douglas
//  **********************************************************************************/

using System;

namespace PrintingSystems.Principals.Shapes.Points;

/// <summary>
/// this class is used to mediate between the various
/// IDesignPoint instances to provide type consistent
/// return values
/// </summary>
public static class DesignPointMediator
{
    /// <summary>
    /// returns the value as an integer
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static int AsInt32(this IDesignPoint source)
        => source switch
            {
                DesignPoint IntPoint => IntPoint.PointValue,
                FloatingDesignPoint FloatPoint => Convert.ToInt32(FloatPoint.PointValue),
            _ => 0
            };

    /// <summary>
    /// returns the value as a double
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static double AsDouble(this IDesignPoint source)
        => source switch
        {
            DesignPoint IntPoint => Convert.ToDouble(IntPoint.PointValue),
            FloatingDesignPoint FloatPoint => FloatPoint.PointValue, 
            _ => 0
        };

}