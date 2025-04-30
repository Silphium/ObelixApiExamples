// /**********************************************************************************
//  * File : DesignLineTests.cs
//  * Date: 20250322
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Runtime.Remoting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintingSystems.Principals.Shapes.Lines;
using PrintingSystems.Principals.Shapes.Points;

namespace PrintQuality;


[TestClass]
public class DesignLineTests
{
    [TestMethod]
    [DataRow(0, 0, 0, 10, 0, 10)]
    public void ShouldCreateLine(int anchorX, int anchorY, int sentinalX, int sentinalY, int deltaX, int deltaY)
    {
        var Anchor = new DesignCoordinate(anchorX, anchorY);
        var Sentinal = new DesignCoordinate(sentinalX, sentinalY);

        var TestLine = new DesignLine(Anchor, Sentinal);

        Assert.IsInstanceOfType(TestLine.Anchor.DeltaX, typeof(DesignPoint));
        Assert.IsInstanceOfType(TestLine.Anchor.DeltaY, typeof(DesignPoint));

        Assert.IsInstanceOfType(TestLine.Sentinal.DeltaX, typeof(DesignPoint));
        Assert.IsInstanceOfType(TestLine.Sentinal.DeltaY, typeof(DesignPoint));

        Assert.AreEqual(deltaX, TestLine.DeltaX.AsInt32());
        Assert.AreEqual(deltaY, TestLine.DeltaY.AsInt32());
    }

}