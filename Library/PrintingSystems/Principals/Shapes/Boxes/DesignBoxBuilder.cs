// /**********************************************************************************
//  * File : DesignBoxBuilder.cs
//  * Date: 20250322
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.CodeDom;
using System.Linq;
using System.Security.Cryptography;
using PrintingSystems.Principals.Shapes.Points;

namespace PrintingSystems.Principals.Shapes.Boxes;

public static class DesignBoxBuilder
{
    /// <summary>
    /// the width of the box
    /// </summary>
    internal const string WidthToken = "width";

    /// <summary>
    /// the height of the box
    /// </summary>
    internal const string HeightToken = "height";

    /// <summary>
    /// adds a width value to the design box
    /// </summary>
    /// <param name="source">the source design box</param>
    /// <param name="width">the document width</param>
    /// <returns>the mutated design box</returns>
    public static DesignBox SetWidth(this DesignBox source, int width)
    {
        var TestWidth = source.Points.FirstOrDefault(node => node.Names.Contains(WidthToken));
        if (TestWidth is not null) source.Points.Remove(TestWidth);

        source.Width = new DesignPoint(width);
        source.Width.AddName(WidthToken);

        source.AddDesignPoint(source.Width);

        return source;

    }

    /// <summary>
    /// adds the width value to the design box
    /// </summary>
    /// <param name="source">the source design box</param>
    /// <param name="height">the document height</param>
    /// <returns>the mutated design box</returns>
    public static DesignBox SetHeight(this DesignBox source, int height)
    {

        var TestHeight = source.Points.FirstOrDefault(node => node.Names.Contains(HeightToken));
        if (TestHeight is not null) source.Points.Remove(TestHeight);
        
        source.Height = new DesignPoint(height);
        source.Height.AddName(HeightToken);
        source.AddDesignPoint(source.Height);

        return source;
    }


    public static DesignBox AddLayer(this DesignBox source, 
                            int leftX, int topY, int width, int height, string layerName = "layer")

    {
        var Layer = source.Boxes.FirstOrDefault(node => string.CompareOrdinal(layerName, node.Name) == 0);
        if (Layer is not null) source.Boxes.Remove(Layer);

        Layer = new DesignBox(leftX, topY, width, height)
        {
            Name = string.CompareOrdinal("layer", layerName) == 0 ? $"layer{source.LayerCount}" : layerName
        };
        source.Boxes.Add(Layer);

        return source;
    }




}