// /**********************************************************************************
//  * File : DesignGridBuilder.cs
//  * Date: 20250313
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Management.Instrumentation;
using System.Xml.Linq;
using OpenCvSharp;
using PrintInspector.Principals;
using PrintInspector.Principals.Layers;

namespace PrintInspector;

public static class DesignGridBuilder
{
    /// <summary>
    /// the default margin color
    /// </summary>
    private static Scalar _MarginColor = new Scalar(0, 0, 255);

    /// <summary>
    /// the default grid color
    /// </summary>
    private static Scalar _GridColor = new Scalar(255, 0, 0);

    /// <summary>
    /// the width of the margin
    /// </summary>
    private static int _MarginWidth = 1;
    
    /// <summary>
    /// sets the margin color
    /// </summary>
    /// <param name="source">the source image matrix</param>
    /// <param name="red">the red value</param>
    /// <param name="green">the green value</param>
    /// <param name="blue">the blue value</param>
    /// <returns>the mutated source image</returns>
    public static Mat SetMarginColor(this Mat source, int red, int green, int blue)
    {
        _MarginColor = new Scalar(blue, green, red);

        return source;
    }


    /// <summary>
    /// draws the margins for the document
    /// </summary>
    /// <param name="source">the source image</param>
    /// <param name="design">the design document</param>
    /// <returns>the mutated image</returns>
    public static Mat DrawDocumentMargins(this Mat source, DesignDocument design)
    {
       
        var Anchor = new Point(design.Lines[0].Anchor.DesignX, design.Lines[0].Anchor.DesignY);
        var Sentinal = new Point(design.Lines[3].Sentinal.DesignX, design.Lines[3].Sentinal.DesignY);
        Cv2.Rectangle(source, Anchor, Sentinal, _MarginColor, _MarginWidth);
        return source;
    }

    /// <summary>
    /// draws the document grid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="designLayer"></param>
    /// <returns></returns>
    public static Mat DrawDocumentGrid(this Mat source, IDesignLayer designLayer)
    {
        var LineColor = _GridColor;
        for (var C = 0; C < designLayer.Boxes.Count; C++)
        {
            var Anchor = new Point(designLayer.Boxes[C].Anchor.DesignX, designLayer.Boxes[C].Anchor.DesignY);
            var Sentinal = new Point(designLayer.Boxes[C].Sentinal.DesignX, designLayer.Boxes[C].Sentinal.DesignY);

            Cv2.Rectangle(source, Anchor, Sentinal,LineColor, designLayer.Boxes[C].LineWidth);

            
        }
        return source;

    }
}