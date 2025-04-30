// /**********************************************************************************
//  * File : ApexImageResponse.cs
//  * Date: 20250308
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DesignPrinter.Missives.Details;
using DesignPrinter.Sample;

namespace DesignPrinter.Dowding.Response;


public class ApexImageResponse : IMissiveResponse
{

    /// <summary>
    /// the type of response 
    /// </summary>
    public string ResponseType { get; } = string.Empty;

    /// <summary>
    /// the data for the response
    /// </summary>
    public string ResponseData { get; } = string.Empty;


    /// <summary>
    /// the image data
    /// </summary>
    public Bitmap ImageData { get; }

    /// <summary>
    /// the frame request information
    /// </summary>
    public readonly ScreenShotFrameRequest FrameRequest;

/// <summary>
    /// 
    /// </summary>
    /// <param name="screenShot"></param>
    public ApexImageResponse(Bitmap screenShot, ScreenShotFrameRequest frameRequest)
    {
        ImageData = screenShot;
        FrameRequest = frameRequest;

    }


    public void SaveImage(string fileLocation)
        => ImageData.Save(fileLocation, FrameRequest.Format);





}