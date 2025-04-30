// /**********************************************************************************
//  * File : NovelAnalytics.cs
//  * Date: 20250312
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms.VisualStyles;
using DesignPrinter.Sample;
using OpenCvSharp;

namespace DesignPrinter.Analytics;

public static class NovelAnalytics
{

    



    public static void AnalysePage(ScreenShotFrameRequest frameData)
    {

        var BaseImage = WindowsMachine.TakeScreenShot(frameData);


        using (var BaseStream = new MemoryStream())
        {
            BaseImage.Save(BaseStream, ImageFormat.Png);
        }

        //var TestImage = Cv2.ImDecode(BaseImage.)



    }



}