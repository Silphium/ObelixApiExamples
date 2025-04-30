// /**********************************************************************************
//  * File : FrameParameter.cs
//  * Date: 20250311
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Diagnostics;

namespace DesignPrinter.Sample;

/// <summary>
/// enumeration class containing the parameter types
/// of a frame request
/// </summary>
internal static class FrameParameter
{
    /// <summary>
    /// the display parameter
    /// </summary>
    internal static string Display = "display";

    /// <summary>
    /// the delta x parameter
    /// </summary>
    internal static string DeltaX = "deltax";

    /// <summary>
    /// the delta y parameter
    /// </summary>
    internal static string DeltaY = "deltay";

    /// <summary>
    /// the width parameter
    /// </summary>
    internal static string Width = "width";

    /// <summary>
    /// the height parameter
    /// </summary>
    internal static string Height = "height";

    /// <summary>
    /// the scale parameter
    /// </summary>
    internal static string Scale = "scale";

    /// <summary>
    /// the forma parameter
    /// </summary>
    internal static string Format = "format";

    /// <summary>
    /// the primary monitor
    /// </summary>
    internal static string PrimaryDisplay = "primary";

}