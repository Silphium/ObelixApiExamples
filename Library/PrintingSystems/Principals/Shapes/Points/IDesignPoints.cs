// /**********************************************************************************
//  * File : IDesignPoints.cs
//  * Date: 20250321
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Collections.Generic;

namespace PrintingSystems.Principals.Shapes.Points;

/// <summary>
/// interface for the attribute list 
/// </summary>
public interface IDesignPoints
{
    /// <summary>
    /// the name of this set of design points
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// the list of design points
    /// </summary>
    List<IDesignPoint> Points { get; }
}