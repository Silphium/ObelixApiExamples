// /**********************************************************************************
//  * File : FloatingDesignPoint.cs
//  * Date: 20250321
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Collections.Generic;

namespace PrintingSystems.Principals.Shapes.Points;

public class FloatingDesignPoint : IDesignPoint
{

    /// <summary>
    ///  the name of this design point
    /// </summary>
    public List<string> Names { get; set; } = [];

    /// <summary>
    /// the precision of the return
    /// </summary>
    public int Precision { get; set; } = 3;

    /// <summary>
    /// the point value
    /// </summary>
    public double PointValue { get; } = 0.0;

    /// <summary>
    /// constructor using a floating point value
    /// </summary>
    /// <param name="pointValue"></param>
    public FloatingDesignPoint(double pointValue)
    {
        PointValue = pointValue;
    }

    /// <summary>
    /// constructor using a string as an input value
    /// </summary>
    /// <param name="pointValue"></param>
    public FloatingDesignPoint(string pointValue)
    {
        if (!double.TryParse(pointValue, out var ValidPointValue)) return;
        
        PointValue = ValidPointValue;
    }

    

    /// <summary>
    /// publishes the point value as a string
    /// </summary>
    /// <returns>the published value for this point</returns>
    public string Publish()
        => PointValue.ToString($"F{Precision}");

    /// <summary>
    /// publishes the point of value as a string with a value parameter
    /// </summary>
    /// <param name="measures">the measurement </param>
    /// <returns></returns>
    public string Publish(MeasuredDefinitions measures)
        => $"{Publish()}{measures.Suffix}";
}