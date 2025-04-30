// /**********************************************************************************
//  * File : ScreenShotRequestContextExtender.cs
//  * Date: 20250310
//  * Author: Keith Douglas
//  **********************************************************************************/

using DesignPrinter.Dowding.Request;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DesignPrinter.Sample;

public static class ScreenShotRequestContextExtender
{
    /// <summary>
    ///  Initialize the frame request using the supplied parameter request
    /// </summary>
    /// <param name="source">the source frame request</param>
    /// <param name="requestParameters">the request parameters</param>
    /// <returns>the mutated frame request</returns>
    public static ScreenShotFrameRequest Initialize(this ScreenShotFrameRequest source,
        DowdingParameterRequest requestParameters)
    {

        return source.SetCaptureDisplay(requestParameters.Parameters)
            .SetCaptureFrame(requestParameters.Parameters)
            .SetImageFormat(requestParameters.Parameters);
    }

    /// <summary>
    /// sets the preferred capture display
    /// </summary>
    /// <param name="source">the source frame request</param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    private static ScreenShotFrameRequest SetCaptureDisplay(this ScreenShotFrameRequest source,
        IDictionary<string, object> parameters)
    {

        var ScreenIndex = GetParameterValue(FrameParameter.Display, parameters);
        if (ScreenIndex <= 0) return source;
        
        if (Screen.AllScreens.Length < ScreenIndex) return source;

        source.Display = Screen.AllScreens[ScreenIndex - 1];
        return source;
    }

    /// <summary>
    /// sets the capture frame 
    /// </summary>
    /// <param name="source">the source frame request</param>
    /// <param name="parameters">the parameters</param>
    /// <returns>the mutated frame request</returns>
    private static ScreenShotFrameRequest SetCaptureFrame(this ScreenShotFrameRequest source,
        IDictionary<string, object> parameters)
    {
        var DeltaX = GetParameterValue(FrameParameter.DeltaX, parameters);
        if (DeltaX < 0)
            DeltaX = source.Display.Bounds.X;

        var DeltaY = GetParameterValue(FrameParameter.DeltaY, parameters);
        if (DeltaY < 0)
            DeltaY = source.Display.Bounds.Y;

        var Width = GetParameterValue(FrameParameter.Width, parameters);
        if (Width < 0)
            Width = source.Display.Bounds.Width;

        var Height = GetParameterValue(FrameParameter.Height, parameters);
        if (Height < 0)
            Height = source.Display.Bounds.Height;

        source.SampleArea = new Rectangle(DeltaX, DeltaY, Width, Height);
        return source;
    }

    /// <summary>
    /// sets the image format 
    /// </summary>
    /// <param name="source">the source frame request</param>
    /// <param name="parameter"></param>
    /// <returns>the mutated source frame</returns>
    internal static ScreenShotFrameRequest SetImageFormat(this ScreenShotFrameRequest source, 
                            IDictionary<string, object> parameter)
    {

        if (!parameter.TryGetValue(FrameParameter.Format, out var ImageFormat)) return source;

        var ImageFormatValue = ImageFormat.ToString();

        if (string.CompareOrdinal("png", ImageFormatValue) == 0)
        {
            source.Format = System.Drawing.Imaging.ImageFormat.Png;
            return source;
        }

        if (string.CompareOrdinal("jpg", ImageFormatValue) != 0) return source;
        
        source.Format = System.Drawing.Imaging.ImageFormat.Jpeg;
        return source;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameterName"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    private static int GetParameterValue(string parameterName, IDictionary<string, object> parameters)
    {
        if (!parameters.TryGetValue(parameterName, out var ParamValue)) return -1;
        if (!int.TryParse(ParamValue.ToString(), out var IntValue)) return -1;
        return IntValue;
    }



}