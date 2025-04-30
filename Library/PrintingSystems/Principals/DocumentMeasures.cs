// /**********************************************************************************
//  * File : DocumentMeasures.cs
//  * Date: 20250321
//  * Author: Keith Douglas
//  *
//  * links: https://www.w3schools.com/cssref/css_units.php#:~:text=Relative%20length%20units
//  *
//  **********************************************************************************/

using System.Collections.Generic;

namespace PrintingSystems.Principals;


public static class MD
{   
    /// <summary>
    /// used when the document is measured in pixels
    /// </summary>
    public static readonly MeasuredDefinitions Pixels = new(DocumentMeasures.Pixels, "px");

    /// <summary>
    /// used when the document is measured in points
    /// </summary>
    public static readonly MeasuredDefinitions Points = new(DocumentMeasures.Points, "pt");

    /// <summary>
    /// used when the document is measured in picas
    /// </summary>
    public static readonly MeasuredDefinitions Picas = new(DocumentMeasures.Picas, "pc");

    /// <summary>
    /// used when the document is measured in inches
    /// </summary>
    public static readonly MeasuredDefinitions Inches = new(DocumentMeasures.Inches, "in");

    /// <summary>
    /// used when the document is measured in millimeters
    /// </summary>
    public static readonly MeasuredDefinitions Millimeters = new(DocumentMeasures.Millimeters, "mm");

    /// <summary>
    /// used when the document is measured in centimeters
    /// </summary>
    public static readonly MeasuredDefinitions Centimeters = new(DocumentMeasures.Centimeters, "cm");

    /// <summary>
    /// the document measures
    /// </summary>
    public static List<MeasuredDefinitions> ForDocuments { get; }

    /// <summary>
    /// constructor
    /// </summary>
    static MD()
    {
        ForDocuments =
        [
            Pixels,
            Points,
            Picas,
            Inches,
            Millimeters,
            Centimeters
        ];
    }
}

public class MeasuredDefinitions(DocumentMeasures type, string suffix)
{
    /// <summary>
    /// the measurement type
    /// </summary>
    public DocumentMeasures Type { get; set; } = type;

    /// <summary>
    /// the suffix to use
    /// </summary>
    public string Suffix { get; set; } = suffix;

}

/// <summary>
/// Measured Document
/// </summary>
/// <remarks>
/// 
/// </remarks>
public enum DocumentMeasures
{
    Pixels,
    Points,
    Picas,
    Inches,
    Millimeters,
    Centimeters
}