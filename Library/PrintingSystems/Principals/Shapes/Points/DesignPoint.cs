// /**********************************************************************************
//  * File : IDesignCoordinate.cs
//  * Date: 20250321
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace PrintingSystems.Principals.Shapes.Points;

/// <summary>
/// this class is used to define a point value for a design document
/// </summary>

public class DesignPoint : IDesignPoint
{
    /// <summary>
    ///  the name of this design point
    /// </summary>
    public List<string> Names { get; set; } = [];

    /// <summary>
    /// publishes the value into a string format
    /// </summary>
    /// <returns></returns>
    public string Publish()
        => PointValue.ToString();

    /// <summary>
    /// returns the value with the value type appended as a suffix
    /// </summary>
    /// <param name="measures">the measurement type</param>
    /// <returns>the value as a string</returns>
    public string Publish(MeasuredDefinitions measures)
        => $"{PointValue}{measures.Suffix}";
    
    /// <summary>
    /// the whole value for this data point
    /// </summary>
    public int PointValue { get; }

    /// <summary>
    /// constructor used for an integer value
    /// </summary>
    /// <param name="pointValue"></param>
    public DesignPoint(int pointValue)
        => PointValue = pointValue;
    
}