// /**********************************************************************************
//  * File : DesignBoxTests.cs
//  * Date: 20250325
//  * Author: Keith Douglas
//  **********************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintingSystems.Principals.Shapes.Boxes;
using PrintingSystems.Principals.Shapes.Points;

namespace PrintQuality.Shapes.Boxes;

[TestClass]
public class DesignBoxTests
{
    [TestMethod]
    [DataRow(0,0,100,100)]
    [DataRow(10,10,100,100)]
    public void ShouldCreateDesignBox(int leftX, int topY, int width, int height)
    {
        var TestBox = new DesignBox(leftX, topY, width, height);

        Assert.AreEqual(width, TestBox.Width.AsInt32());
        Assert.AreEqual(height, TestBox.Height.AsInt32()); 
        Assert.AreEqual(0, TestBox.Boxes.Count);

    }

    [TestMethod]
    [DataRow(0, 0, 100, 100)]
    public void ShouldCreateDesignBoxFromCorners(int leftX, int topY, int rightX, int bottomY)
    {

        var TopLeft = new DesignCoordinate(leftX, topY);
        var BottomRight = new DesignCoordinate(rightX, bottomY);

        var TestBox = new DesignBox(TopLeft, BottomRight);


        var Width = rightX = leftX;
        var Height = bottomY - topY;

        Assert.AreEqual(Width, TestBox.Width.AsInt32());
        Assert.AreEqual(Height, TestBox.Height.AsInt32());
        Assert.AreEqual(0, TestBox.Boxes.Count);

  
    }

    [TestMethod]
    [DataRow[0,0,1000,1000]]
    private void ShouldCreateBoxCorners(DesignBox testBox, int testLeftX, int testTopY, int testRightX, int testBottomY)
    {
        Assert.AreEqual(4, testBox.Corners.Count);
        var CornerIndex = 0;


        // The Top Left Corner
        Assert.AreEqual(testLeftX, testBox.Corners[CornerIndex].DeltaX.AsInt32());
        Assert.AreEqual(testTopY, testBox.Corners[CornerIndex].DeltaY.AsInt32());
        CornerIndex++;

        // The Top Right Corner 
        Assert.AreEqual(testRightX, testBox.Corners[CornerIndex].DeltaX.AsInt32());
        Assert.AreEqual(testTopY, testBox.Corners[CornerIndex].DeltaY.AsInt32());
        CornerIndex++;

        // The Bottom Left Corner
        Assert.AreEqual(testLeftX, testBox.Corners[CornerIndex].DeltaX.AsInt32());
        Assert.AreEqual(testBottomY, testBox.Corners[CornerIndex].DeltaY.AsInt32());
        CornerIndex++;

        // The Bottom Right Corner
        Assert.AreEqual(testRightX, testBox.Corners[CornerIndex].DeltaX.AsInt32());
        Assert.AreEqual(testBottomY, testBox.Corners[CornerIndex].DeltaY.AsInt32());
    }

}