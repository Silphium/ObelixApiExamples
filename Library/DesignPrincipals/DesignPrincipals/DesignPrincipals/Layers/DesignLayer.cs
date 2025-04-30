// /**********************************************************************************
//  * File : DesignLayer.cs
//  * Date: 20250303
//  * Author: Keith Douglas
//  **********************************************************************************/

namespace DesignPrincipals.Layers;

/// <summary>
/// interface for a design layer
/// </summary>
public interface IDesignLayer
{
    /// <summary>
    /// the name of the layer
    /// </summary>
    string LayerName { get; }
}