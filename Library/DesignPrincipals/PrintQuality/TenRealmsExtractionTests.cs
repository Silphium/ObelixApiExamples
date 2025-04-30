using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DesignPrinter;
using DesignPrinter.Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrintQuality
{
    [TestClass]
    public class TenRealmsExtractionTests
    {
        private readonly ScreenShotFrameRequest TestFrameRequest = null;

        public TenRealmsExtractionTests()
        {
            
            TestFrameRequest = new ScreenShotFrameRequest();
            TestFrameRequest.Display = Screen.AllScreens[1];
            TestFrameRequest.SampleArea = new Rectangle(
                TestFrameRequest.Display.Bounds.X,
                TestFrameRequest.Display.Bounds.Y,
                TestFrameRequest.Display.Bounds.Width,
                TestFrameRequest.Display.Bounds.Height);
            TestFrameRequest.Format = ImageFormat.Bmp;

        }




        [TestMethod]
        public void ShouldLoadScreenShot()
        {
            Assert.IsNotNull(TestFrameRequest);

            var TestImage = WindowsMachine.TakeScreenShot(TestFrameRequest);



        }
    }
}
