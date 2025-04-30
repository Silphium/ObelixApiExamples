using FluentSilk;
using FluentSilk.Knot.Body;
using FluentSilk.Knot.Frame;
using FluentSilk.Knot.Head;

namespace QualitySilk;

public class SpiderFrameTests
{
    /// <summary>
    /// tests that a basic radial structure is
    /// created properly
    /// </summary>
    [Fact]
    public void ShouldCreateEmptyStructure()
    {
        const string expectedHtmlTag = "html";
        const string expectedHeadTag = "head";
        const string expectedBodyTag = "body";

        var TestPage = WebSpinner.CreateRadial();

        // the radial frame state tests
        Assert.NotNull(TestPage.SpiderWeb);
        Assert.IsAssignableFrom<RadialFrame>(TestPage.SpiderWeb);
        Assert.Empty(TestPage.SpiderWeb.GuyLines);
        Assert.Equal(2, TestPage.SpiderWeb.Dependants.Count);
        Assert.Equal(expectedHtmlTag, TestPage.SpiderWeb.Token);

        // the frame head state tests
        var TestHead = TestPage.SpiderWeb.Dependants[0];
        Assert.IsAssignableFrom<FrameHead>(TestHead);
        Assert.Empty(TestHead.Dependants);
        Assert.Empty(TestHead.GuyLines);
        Assert.Equal(expectedHeadTag, TestHead.Token);

        var TestBody = TestPage.SpiderWeb.Dependants[1];
        Assert.IsAssignableFrom<FrameBody>(TestBody);
        Assert.Empty(TestBody.Dependants);
        Assert.Empty(TestBody.GuyLines);
        Assert.Equal(expectedBodyTag, TestBody.Token);

    }

    [Fact]
    public void ShouldCreateBasicRadial()
    {
        var TestPage = WebSpinner.CreateRadial("The Quantum Thief");

        Assert.NotNull(TestPage.SpiderWeb);
        var TestString = WebSpinner.SpinRadial(TestPage.SpiderWeb);



    }
}