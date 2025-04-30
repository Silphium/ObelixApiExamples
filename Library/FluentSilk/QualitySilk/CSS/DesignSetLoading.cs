// /**********************************************************************************
//  * File : DesignSetLoading.cs
//  * Date: 20250301
//  * Author: Keith Douglas
//  **********************************************************************************/

using FluentSilk.Threads;
using System.Net.Http.Headers;
using DesignReporting.Missives;

namespace QualitySilk.CSS;

public class DesignSetLoading
{
    /// <summary>
    /// 
    /// </summary>

    private readonly List<string> _TestFilePath = ["c:\\", "foundry", "quality", "css"];



    [Theory]
    [InlineData("example1.css")]
    public void ShouldLoadCSSFile(string fileName)
    {
        var TestFilePath = new List<string>();
        TestFilePath.AddRange(_TestFilePath);
        TestFilePath.Add(fileName);

        var FileLocation = Path.Combine(TestFilePath.ToArray());

        Assert.True(File.Exists(FileLocation));

        var DesignTest = new ThreadDesignSet();
        var LoadTestResult = DesignTest.Load(FileLocation);

        Assert.IsAssignableFrom<ICompleteMissive>(LoadTestResult);



    }



}