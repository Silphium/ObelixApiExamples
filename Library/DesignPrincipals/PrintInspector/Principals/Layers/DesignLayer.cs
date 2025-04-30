// /**********************************************************************************
//  * File : DesignLayer.cs
//  * Date: 20250303
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Collections.Generic;
using PrintInspector.Principals.Shapes;

namespace PrintInspector.Principals.Layers;

/// <summary>
/// interface for a design layer
/// </summary>
public interface IDesignLayer
{
    /// <summary>
    /// the name of the layer
    /// </summary>
    string LayerName { get; }

    /// <summary>
    /// lines used by this design layer
    /// </summary>
    List<DesignLine> Boxes { get; }
}