// /**********************************************************************************
//  * File : IDesignPoint.cs
//  * Date: 20250321
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Collections.Generic;
using System.ComponentModel;

namespace PrintingSystems.Principals.Shapes.Points;

/// <summary>
/// interface for a design point
/// </summary>
public interface IDesignPoint
{
    /// <summary>
    ///  the name of this design point
    /// </summary>
    List<string> Names { get; set; }
    /// <summary>
    /// publishes the point value as a string
    /// </summary>
    /// <returns>the published value for this point</returns>
    public string Publish();

    /// <summary>
    /// publishes the point of value as a string with a value parameter
    /// </summary>
    /// <param name="measures">the measurement </param>
    /// <returns></returns>
    string Publish(MeasuredDefinitions measures);  
}