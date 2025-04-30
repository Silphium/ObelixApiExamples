namespace PrintingQuality
{
    public class SystemReportingTests
    {
        [Fact]
        public void ShouldGenerateFullReport()
        {
            var TestPrinter = new DesignPrinter.WindowsMachine();
            var TestReport = TestPrinter.CreateWindowsSystemReport();

            Assert.NotEmpty(TestReport);


        }
    }
}