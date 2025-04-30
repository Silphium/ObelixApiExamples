// /**********************************************************************************
//  * File : ScreenShotFrameRequest.cs
//  * Date: 20250310
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DesignPrinter.Sample;

public class ScreenShotFrameRequest
{
    
    /// <summary>
    /// the display used for the frame capture
    /// </summary>
    public Screen Display { get; set; } = Screen.PrimaryScreen;

    /// <summary>
    /// the sample area
    /// </summary>
    public Rectangle SampleArea { get; set; }

    /// <summary>
    /// the scale of the image
    /// </summary>
    public double Scale { get; set; } = 1.0;

    /// <summary>
    /// the image format
    /// </summary>
    public ImageFormat Format { get; set; } = ImageFormat.Bmp;

}