using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesignPrinter.Dowding;
using DesignPrinter.Dowding.Radar;
using DesignPrinter.Dowding.Request;
using DesignPrinter.Dowding.Response;
using DesignPrinter.Missives;
using DesignPrinter.Sample;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;

namespace DesignPrinter
{
    public class WindowsMachine
    {

        /// <summary>
        /// list of listeners 
        /// </summary>
        private readonly List<IApexListener> Listeners = new();

        /// <summary>
        /// list of suffixes 
        /// </summary>
        private static readonly List<string> SuffixList = new List<string> { "Penhaligan", "Windows" };

        public IMissive StartMeUp()
        {
            CreateFrontPage();
            CreateDisplayAgents();

            for (var C = 0; C < Listeners.Count; C++)
                Listeners[C].Open();
            return MissivePrinter.PrintCompleted();
        }

        public IMissive ShutMeDown()
        {
            return MissivePrinter.PrintFailure(null);
        }

        /// <summary>
        /// creates the front page for this service
        /// </summary>
        private void CreateFrontPage()
        {
            var EndPointList = new List<ApexEndPoint>
            {
                new ApexEndPoint("http", "localhost", 1798, SuffixList),
                new ApexEndPoint("http", "127.0.0.1", 1798, SuffixList)
            };

            var FrontPage = new ApexListener("FrontPage");
            FrontPage.AddEndPoint(EndPointList);
            FrontPage.AddMethodHandler("GET", FrontPageGetRequestHadler);
            FrontPage.AddMethodHandler("POST", FrontPagePostRequestHandler);
            Listeners.Add(FrontPage);

        }

        /// <summary>
        /// GET HTTP Request handler for /Penhaligan/Windows/
        /// </summary>
        /// <param name="missiveRequest">the missive request</param>
        /// <returns>the system report</returns>
        private Task<IMissive> FrontPageGetRequestHadler(IApexMissiveRequest missiveRequest)
        {
            var RequestMissive = MissivePrinter.CreateMissive(missiveRequest);
            
            RequestMissive.ResponseList.Add(new ApexJsonResponse(WindowsSystem.CreateWindowsSystemReport()));

            return Task.FromResult(RequestMissive);
        }


        /// <summary>
        /// POST HTTP Request handler for /Penhaligan/Windows/
        /// </summary> 
        /// <param name="missiveRequest">the missive request</param>
        /// <returns>the system report</returns>
        private Task<IMissive> FrontPagePostRequestHandler(IApexMissiveRequest missiveRequest)
        {
            var RequestMissive = MissivePrinter.CreateMissive(missiveRequest);


            return Task.FromResult(RequestMissive);
        }

        private void CreateDisplayAgents()
        {
            var DisplaySuffixList = new List<string>();

            DisplaySuffixList.AddRange(SuffixList);
            DisplaySuffixList.Add("Display");

            var EndPointList = new List<ApexEndPoint>
            {
                new ApexEndPoint("http", "localhost", 1798, DisplaySuffixList),
                new ApexEndPoint("http", "127.0.0.1", 1798, DisplaySuffixList)
            };

            var DisplayPage = new ApexListener("display");
            DisplayPage.AddEndPoint(EndPointList);
            DisplayPage.AddMethodHandler("GET", DisplayGetRequestHandler);
            DisplayPage.AddMethodHandler("POST", DisplayPostRequestHandler);
            DisplayPage.CloseRequestAction = CloseImageRequest;
            Listeners.Add(DisplayPage);

        }


        private Task<IMissive> DisplayGetRequestHandler(IApexMissiveRequest missiveRequest)
        {
            if (missiveRequest is not DowdingParameterRequest ParamRequest)
                return Task.FromResult(MissivePrinter.PrintFailure(null));

            var RequestMissive = MissivePrinter.CreateMissive(missiveRequest);

            var FrameData = new ScreenShotFrameRequest();
            FrameData.Initialize(ParamRequest);

            var Response = new ApexImageResponse(TakeScreenShot(FrameData), FrameData);

            var Completed = MissivePrinter.PrintCompleted(missiveRequest);
            Completed.AddResponse(Response);

            Response.SaveImage("C:\\Art\\TestImage.png");

            return Task.FromResult(Completed);
        }

        private Task<IMissive> DisplayPostRequestHandler(IApexMissiveRequest missiveRequest)
        {
            var RequestMissive = MissivePrinter.CreateMissive(missiveRequest);


            return Task.FromResult(RequestMissive);
        }


        public static Bitmap TakeScreenShot(ScreenShotFrameRequest frameRequest)
        {
            var ScreenShot = new Bitmap(frameRequest.SampleArea.Width, frameRequest.SampleArea.Height);

            var TopLeftSource = new Point(frameRequest.SampleArea.X, frameRequest.SampleArea.Y);
            var TopLeftTarget = new Point(0, 0);


            using var G = Graphics.FromImage(ScreenShot);
            G.CopyFromScreen(TopLeftSource, TopLeftTarget, new Size(frameRequest.SampleArea.Width, frameRequest.SampleArea.Height));

            return ScreenShot;
        }

        private void CloseImageRequest(HttpListenerResponse response, IMissive missive)
        {
             if (missive.ResponseList[0] is not ApexImageResponse ImageResponse) return;

             ImageResponse.ImageData.Save(response.OutputStream, ImageFormat.Bmp);
             response.Close();

        }

    }
}
