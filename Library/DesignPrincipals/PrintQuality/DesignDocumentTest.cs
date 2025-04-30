// /**********************************************************************************
//  * File : DesignDocumentTest.cs
//  * Date: 20250321
//  * Author: Keith Douglas
//  **********************************************************************************/

using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintingSystems;
using PrintingSystems.Principals;
using PrintingSystems.Principals.Shapes.Points;

namespace PrintQuality;

[TestClass]
public class DesignDocumentTest
{
    [TestMethod]
    [DataRow(1000,1000, DocumentMeasures.Pixels)]
    public void ShouldCreateDesignDocument(int width, int height, DocumentMeasures measure)
    {
        var Measures = MD.ForDocuments.FirstOrDefault(node => node.Type == measure);
        Assert.IsNotNull(Measures); 
        
        var TestDoc = new DesignDocument(width, height, Measures);
        
        

    }


}