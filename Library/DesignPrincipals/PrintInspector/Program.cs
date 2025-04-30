using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OpenCvSharp;
using PrintingSystems;
using PrintingSystems.SVG;
using PrintInspector.Principals;
using Svg;

namespace PrintInspector
{
    class Program
    {
        static void Main(string[] args)
        {

            var GridPattern = new DesignDocument(1000, 800);
            GridPattern.CreateMargin(50);
            GridPattern.CalculateCorners(2);
            GridPattern.CreateGrid(10, 10, 10);

            CreateSVG(GridPattern);


            using var Grid = CreateTestGrid(GridPattern.Width,GridPattern.Height);
            Grid.DrawDocumentMargins(GridPattern);
            Grid.DrawDocumentGrid(GridPattern.Layers[0]);

            CreateSVG(GridPattern);


            using var TestWindow = new Window("Grid", Grid);


            Cv2.WaitKey();
        }


        private static Mat CreateTestGrid(int width, int height)
        {
            var GridSize = new Size(width, height);
            var BackgroundColor = new Scalar(255, 255, 255);

            var Grid = new Mat(GridSize, MatType.CV_8UC3, BackgroundColor);

            return Grid;

        }


        private static void CreateSVG(DesignDocument designDocument)
        {

            var GridImage = new ScreenVectorGraphic();

            GridImage.Save(@"C:\Art\TestImage.svg");


        }


    }
}
