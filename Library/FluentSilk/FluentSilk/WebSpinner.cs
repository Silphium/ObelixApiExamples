using HtmlAgilityPack;
using FluentSilk.Knot;
using System.Xml.Linq;

namespace FluentSilk;

public static class WebSpinner
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static FluentWeb CreateRadial(string? radialTitle = null)
    {
        var TestSpider = new FluentWeb();
        return TestSpider.CreateWebPage(radialTitle);
    }



    public static string SpinRadial(SpiderKnot rootKnot)
    {
        var RootNodeContents = string.Empty;

        try
        {
            var RootNode = rootKnot.Render();

            RootNodeContents = RootNode.ToString();
        }
        catch (Exception Error)
        {
            var Fucked = true;
        }
        
        
        
        return RootNodeContents;

    }

}