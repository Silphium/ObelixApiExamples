using DesignPrincipals;

namespace PrincipalAffirmation;

public class DocumentCreation
{
    [Theory]
    [InlineData(100,100)]
    public void ShouldCreateDocument(int width, int height)
    {
        var DeltaXTest = 0;
        var DeltaYTest = 0;

        var TestDocument = new DesignDocument(width, height);

        // test that the document has been correctly formed
        Assert.Equal(DeltaXTest, TestDocument.DeltaX);
        Assert.Equal(DeltaYTest, TestDocument.DeltaY);

        Assert.Equal(width, TestDocument.Width);
        Assert.Equal(height, TestDocument.Height);

        var TestArea = width * height;
        Assert.Equal(TestArea, TestDocument.Area);
        Assert.Empty(TestDocument.Layers);

        // test that the margin has been correctly formed 
        Assert.Equal(DeltaXTest,  TestDocument.Margin.DeltaX);
        Assert.Equal(DeltaYTest, TestDocument.Margin.DeltaY);

        Assert.Equal(width, TestDocument.Margin.Width);
        Assert.Equal(height, TestDocument.Margin.Height);
        Assert.Equal(TestArea, TestDocument.Margin.Area);
    }
}