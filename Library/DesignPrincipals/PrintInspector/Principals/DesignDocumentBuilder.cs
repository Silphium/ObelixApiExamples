// /**********************************************************************************
//  * File : DesignDocumentBuilder.cs
//  * Date: 20250303
//  * Author: Keith Douglas
//  **********************************************************************************/

#nullable enable
using System.Data;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;
using OpenCvSharp;
using PrintInspector.Principals.Layers;
using PrintInspector.Principals.Shapes;

namespace PrintInspector.Principals;


/// <summary>
/// builder class for the document margins
/// </summary>
public static class DesignDocumentBuilder
{
    /// <summary>
    /// creates a document margin
    /// </summary>
    /// <param name="source">the source document</param>
    /// <param name="topMargin">the top margin value in millimeters</param>
    /// <param name="leftMargin">the left margin value in millimeters</param>
    /// <param name="bottomMargin">the bottom margin value in millimeters</param>
    /// <param name="rightMargin">the right margin value in millimeters</param>
    /// <returns>the mutated document</returns>
    public static DesignDocument CreateMargin(this DesignDocument source, 
                                    int topMargin, int leftMargin,
                                        int bottomMargin, int rightMargin)
    {
        var WorkingWidth = source.Width - (leftMargin + rightMargin);
        var WorkingHeight = source.Height - (topMargin + bottomMargin);

        if (WorkingWidth < 1) return source;
        if (WorkingHeight < 1) return source;

        source.Margin = new DesignBox(WorkingWidth, WorkingHeight, 
                                    leftMargin, topMargin);

        return source;
    }

    /// <summary>
    /// creates the margin using a single value for all four document margins
    /// </summary>
    /// <param name="source">the source document</param>
    /// <param name="margin">the margin value in millimeters</param>
    /// <returns>the mutated document</returns>
    public static DesignDocument CreateMargin(this DesignDocument source, int margin)
        =>  CreateMargin(source, margin, margin, margin,margin);

    /// <summary>
    /// creates the margin using a value for the vertical margin
    /// and a value for the horizontal margin
    /// </summary>
    /// <param name="source">the source document</param>
    /// <param name="verticalMargin">the  vertical margin value in millimeters</param>
    /// <param name="horizontalMargin">the horizontal margin value in millimeters</param>
    /// <returns>the mutated document</returns>
    public static DesignDocument CreateMargin(this DesignDocument source, 
                                    int verticalMargin, int horizontalMargin)
        => CreateMargin(source, verticalMargin, horizontalMargin, 
                                    verticalMargin, horizontalMargin);


    /// <summary>
    /// creates a grid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="columnCount"></param>
    /// <param name="rowCount"></param>
    /// <param name="space"></param>
    /// <param name="layerName"></param>
    /// <returns></returns>
    public static DesignDocument CreateGrid(this DesignDocument source, int columnCount, int rowCount,
        int space = 0, string? layerName = null)
    {
        return source.CreateGrid(columnCount, rowCount, space, space, layerName);
    }
    public static DesignDocument CreateGrid(this DesignDocument source, int columnCount, int rowCount,
        int gutterWidth, int flowHeight, string? layerName = null)
    {

        var LayerName = string.IsNullOrEmpty(layerName) ? GetTracingLayerName(source) : layerName;

        var GridLayer = new GridDesignLayer(LayerName, source.Margin, columnCount, rowCount, gutterWidth, flowHeight);
        GridLayer.CreateGridLines();
        source.Layers.Add(GridLayer);

        return source;

    }

    private static string GetTracingLayerName(DesignDocument source)
        => new StringBuilder("TracingLayer").Append(source.Layers.Count).ToString();

}