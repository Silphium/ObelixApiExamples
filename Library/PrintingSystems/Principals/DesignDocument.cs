// /**********************************************************************************
//  * File : IDesignDocument.cs
//  * Date: 20250321
//  * Author: Keith Douglas
//  **********************************************************************************/


using System.Linq;
using PrintingSystems.Principals.Shapes.Boxes;
using PrintingSystems.Principals.Shapes.Points;

namespace PrintingSystems.Principals;

public class DesignDocument : DesignBox
{
    /// <summary>
    /// the type of measurement for this document
    /// </summary>
    public MeasuredDefinitions Scale { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width">the width of the document</param>
    /// <param name="height">the height of the document</param>
    /// <param name="scale">the measurement scale</param>
    public DesignDocument(int width, int height, MeasuredDefinitions scale) : base(0,0, width, height)
    {
        Scale = scale;

    }

    /// <summary>
    /// the bleed token
    /// </summary>
    private const string BleedToken = "bleed";

    /// <summary>
    /// set's the document's bleed size
    /// </summary>
    /// <param name="bleedSize">the size of the bleed area</param>
    public void SetDocumentBleed(int bleedSize)
        => SetDocumentBleed(bleedSize, bleedSize, bleedSize, bleedSize);

    /// <summary>
    /// sets the document's bleed area
    /// </summary>
    /// <param name="bleedWidth">the width of the bleed area</param>
    /// <param name="bleedHeight">the height of the bleed area</param>
    public void SetDocumentBleed(int bleedWidth, int bleedHeight)
        => SetDocumentBleed(bleedWidth, bleedWidth, bleedHeight, bleedHeight);

    /// <summary>
    /// sets the document's bleed area
    /// </summary>
    /// <param name="leftBleed">the size of the left bleed</param>
    /// <param name="rightBleed">the size of the right bleed</param>
    /// <param name="topBleed">the size of the top bleed</param>
    /// <param name="bottomBleed">the size of the bottom bleed</param>
    public void SetDocumentBleed(int leftBleed, int rightBleed, int topBleed, int bottomBleed)
    {
        
        var BleedWidth = Width.AsInt32() - (leftBleed + rightBleed);
        var BleedHeight = Height.AsInt32() - (topBleed + bottomBleed);

        var DocumentBleed = new DesignBox(leftBleed, topBleed, BleedWidth, BleedHeight);
        Boxes.Add(DocumentBleed);

    }


    
}