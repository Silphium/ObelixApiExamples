// /**********************************************************************************
//  * File : GridDesignLayer.cs
//  * Date: 20250303
//  * Author: Keith Douglas
//  **********************************************************************************/

namespace DesignPrincipals.Layers;



public class GridDesignLayer : IDesignLayer
{
    /// <summary>
    /// the number of columns in this grid
    /// </summary>
    public int ColumnCount { get; }

    /// <summary>
    /// the number of rows in the grid
    /// </summary>
    public int RowCount { get; }

    /// <summary>
    /// the name of the layer
    /// </summary>
    public string LayerName { get; }

    /// <summary>
    /// base constructor
    /// </summary>
    /// <param name="layerName">the name of the layer</param>
    /// <param name="columnCount">the number of columns</param>
    /// <param name="rowCount">the number of rows</param>
    public GridDesignLayer(string layerName, int columnCount, int rowCount)
    {
        LayerName = layerName;
        ColumnCount = columnCount;
        RowCount = rowCount;
    }

    
}