// /**********************************************************************************
//  * File : DocumentMarginBuilder.cs
//  * Date: 20250303
//  * Author: Keith Douglas
//  **********************************************************************************/
namespace DesignPrincipals;


/// <summary>
/// builder class for the document margins
/// </summary>
public static class DocumentMarginBuilder
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
}