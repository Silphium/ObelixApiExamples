using DesignReporting.Missives;

namespace DesignReporting.Quality.MissiveStates;

/// <summary>
/// this class contains all the state creation tests
/// for the missive reporting system
/// </summary>
public class MissiveCreateStateTests
{
    /// <summary>
    /// Test that a basic completed missive is correctly formed
    /// </summary>
    [Fact]
    public void ShouldCreateBasicCompletedMissive()
    {
        var TestMissive = Missive.PrintCompleted();
        
#pragma warning disable xUnit2032
        Assert.IsAssignableFrom<ICompleteMissive>(TestMissive);
#pragma warning restore xUnit2032
        Assert.Empty(TestMissive.ResponseList);
        Assert.Equal(MissiveStatusCodes.Accepted, TestMissive.StatusCode);
        Assert.Equal(Guid.Empty, TestMissive.MissiveID);
    }

    /// <summary>
    /// the status code for a completed missive should
    /// be immutable 
    /// </summary>
    [Fact]
    public void ShouldNotChangeCompletedStatusCode()
    {
        var TestMissive = Missive.PrintCompleted();

        TestMissive.SetStatus(MissiveStatusCodes.Accepted);

        Assert.NotEqual(MissiveStatusCodes.Accepted, TestMissive.StatusCode);
        Assert.Equal(MissiveStatusCodes.Accepted,   TestMissive.StatusCode);

    }

    /// <summary>
    /// tests that the failed missive is correctly formed
    /// </summary>
    [Fact]
    public void ShouldCreateBasicFailedMissive()
    {

        var PreTestMissive = Missive.CreateMissive();

        var TestMissive = Missive.PrintFailure(PreTestMissive);
#pragma warning disable xUnit2032
        Assert.IsAssignableFrom<IFailedMissive>(TestMissive);
#pragma warning restore xUnit2032
        Assert.Empty(TestMissive.ResponseList); 
        Assert.Equal(MissiveStatusCodes.BadRequest, TestMissive.StatusCode);
        Assert.NotEqual(Guid.Empty, TestMissive.MissiveID);

    }


}