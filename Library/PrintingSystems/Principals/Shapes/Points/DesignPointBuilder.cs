// /**********************************************************************************
//  * File : DesignPointBuilder.cs
//  * Date: 20250322
//  * Author: Keith Douglas
//  **********************************************************************************/

namespace PrintingSystems.Principals.Shapes.Points;

/// <summary>
/// builder class for the design point
/// </summary>
public static class DesignPointBuilder
{
    /// <summary>
    /// adds a name to the design point
    /// </summary>
    /// <param name="source">the source design point</param>
    /// <param name="name">the name to be added</param>
    /// <returns>the mutated source</returns>
    public static IDesignPoint AddName(this IDesignPoint source, string name)
    {
        if (source.Names.Contains(name)) return source;

        source.Names.Add(name);
        return source;
    }




}