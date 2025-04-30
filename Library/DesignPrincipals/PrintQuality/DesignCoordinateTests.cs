// /**********************************************************************************
//  * File : DesignCoordinateTests.cs
//  * Date: 20250323
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintingSystems.Principals.Shapes.Points;

namespace PrintQuality;

[TestClass]
public class DesignCoordinateTests
{

    [TestMethod]
    [DataRow(0, 0)]
    [DataRow(0,10)]
    [DataRow(10,0)]
    [DataRow(0, -10)]
    [DataRow(-10,0)]
    [DataRow(-10,-10)]
    public void ShouldCreateIntegerCoordinates(int testX, int testY)
    {
        var TestChords = new DesignCoordinate(testX, testY);

        Assert.AreEqual(2, TestChords.Points.Count);

        Assert.IsInstanceOfType(TestChords.DeltaX, typeof(DesignPoint));
        Assert.IsInstanceOfType(TestChords.DeltaY,  typeof(DesignPoint));

        Assert.AreEqual(testX, TestChords.DeltaX.AsInt32());
        Assert.AreEqual(testY, TestChords.DeltaY.AsInt32());

    }

}