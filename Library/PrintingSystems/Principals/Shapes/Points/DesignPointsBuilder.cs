// /**********************************************************************************
//  * File : DesignPointsBuilder.cs
//  * Date: 20250322
//  * Author: Keith Douglas
//  **********************************************************************************/

using PrintingSystems.Principals.Shapes.Boxes;

namespace PrintingSystems.Principals.Shapes.Points;

public static class DesignPointsBuilder
{
    /// <summary>
    /// adds a design point
    /// </summary>
    /// <param name="source">the source component</param>
    /// <param name="designPoint">the design point to be added</param>
    /// <returns>the mutated component</returns>
    public static IDesignPoints AddDesignPoint(this IDesignPoints source, IDesignPoint designPoint)
    {
        source.Points.Add(designPoint);
        return source;
    }


    /// <summary>
    /// adds a design point with an integer value and one name
    /// </summary>
    /// <param name="source">the source design point set</param>
    /// <param name="value">the value for this design point</param>
    /// <param name="pointName"></param>
    /// <returns></returns>
    public static IDesignPoints AddDesignPoint(this IDesignPoints source, int value, string pointName)
    {

        var NewPoint = new DesignPoint(value);
        NewPoint.AddName(pointName);
        source.AddDesignPoint(NewPoint);
        return source;
    }
}