// /**********************************************************************************
//  * File : GridDesignLayer.cs
//  * Date: 20250303
//  * Author: Keith Douglas
//  **********************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using PrintInspector.Principals.Shapes;

namespace PrintInspector.Principals.Layers;



public class GridDesignLayer : IDesignLayer
{
    /// <summary>
    /// the bounds of this grid
    /// </summary>
    public IDesignBox Bounds { get; }
    
    /// <summary>
    /// the number of columns in this grid
    /// </summary>
    public int ColumnCount { get; }

    /// <summary>
    /// the width between columns
    /// </summary>
    public int GutterWidth { get; }

    /// <summary>
    /// the number of rows in the grid
    /// </summary>
    public int RowCount { get; }


    /// <summary>
    /// the height between rows
    /// </summary>
    public int FlowHeight { get; }

    /// <summary>
    /// the name of the layer
    /// </summary>
    public string LayerName { get; }

    /// <summary>
    /// lines used by this design layer
    /// </summary>
    public List<DesignLine> Boxes { get; private set; }

    

    /// <summary>
    /// base constructor
    /// </summary>
    /// <param name="layerName">the name of the layer</param>
    /// <param name="bounds"></param>
    /// <param name="columnCount">the number of columns</param>
    /// <param name="rowCount">the number of rows</param>
    public GridDesignLayer(string layerName, IDesignBox bounds, int columnCount, int rowCount)
    {
        LayerName = layerName;
        ColumnCount = columnCount;
        RowCount = rowCount;
        Bounds = bounds;
        GutterWidth = 0;
        FlowHeight = 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="layerName"></param>
    /// <param name="bounds"></param>
    /// <param name="columnCount"></param>
    /// <param name="rowCount"></param>
    /// <param name="space"></param>
    public GridDesignLayer(string layerName, IDesignBox bounds, int columnCount, int rowCount, int space)
    {
        LayerName = layerName;
        ColumnCount = columnCount;
        RowCount = rowCount;
        Bounds = bounds;
        GutterWidth = space;
        FlowHeight = space;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="layerName"></param>
    /// <param name="bounds"></param>
    /// <param name="columnCount"></param>
    /// <param name="rowCount"></param>
    /// <param name="gutterWidthWidth"></param>
    /// <param name="flowHeight"></param>
    public GridDesignLayer(string layerName, IDesignBox bounds, int columnCount, int rowCount, int gutterWidthWidth,
        int flowHeight)
    {
        LayerName = layerName;
        ColumnCount = columnCount;
        RowCount = rowCount;
        Bounds = bounds;
        GutterWidth = gutterWidthWidth;
        FlowHeight = flowHeight;
    }


    public void CreateGridLines(int lineWidth = 1)
    {
        
        Boxes = [];
        BuildColumns(lineWidth);
        BuildRows(lineWidth);

    }


    private void BuildColumns(int lineWidth = 1)
    {
         var TotalGutterSpace = (ColumnCount - 1) * GutterWidth;
        var TotalColumnSpace = Bounds.Width - TotalGutterSpace;
        var ColumnSpace = (int)TotalColumnSpace / ColumnCount;

        var TopY = Bounds.DeltaY;
        var BottomY = (Bounds.DeltaY + Bounds.Height);
        var ColumnLeftX = Bounds.DeltaX;
        var ColumnRightX = Bounds.DeltaX + ColumnSpace;

        Console.WriteLine($"Build Columns ColumnCount: {ColumnCount} GutterWidth {GutterWidth} ColumnSpace {ColumnSpace}");
        for (var C = 0; C < ColumnCount; C++)
        {
            Console.WriteLine($"Anchor X:{ColumnLeftX} Y:{TopY} Sentinal: X:{ColumnRightX} Y:{BottomY}");
            var Anchor = new DesignPoint(ColumnLeftX, TopY);
            var Sentinal = new DesignPoint(ColumnRightX, BottomY);
            var GridLine = new DesignLine(Anchor, Sentinal, lineWidth);
            Boxes.Add(GridLine);

            ColumnLeftX += (ColumnSpace + GutterWidth);
            ColumnRightX = ColumnLeftX + ColumnSpace;
        }
    }


    private void BuildRows(int lineWidth = 1)
    {

        var TotalFlowHeight = (RowCount - 1) * FlowHeight;
        var TotalRowSpace = Bounds.Height - TotalFlowHeight;
        var RowSpace = (int)TotalRowSpace / RowCount;

        var LeftX = Bounds.DeltaX;
        var RightX = Bounds.DeltaX + Bounds.Width;
        var RowTopY = Bounds.DeltaY;
        var RowBottomY = Bounds.DeltaY + RowSpace;
        Console.WriteLine($"Build Rows RowCount: {RowCount} FlowHeight {FlowHeight} RowSpace {RowSpace}");
        for (var C = 0; C < RowCount; C++)
        {
            Console.WriteLine($"Anchor X:{LeftX} Y:{RowTopY} Sentinal: X:{RightX} Y:{RowBottomY}");
            var Anchor = new DesignPoint(LeftX, RowTopY);
            var Sentinal = new DesignPoint(RightX, RowBottomY);
            var GridLine = new DesignLine(Anchor, Sentinal, lineWidth);
            Boxes.Add(GridLine);

            RowTopY += (RowSpace + FlowHeight);
            RowBottomY = RowTopY + RowSpace;
        }

    }

}