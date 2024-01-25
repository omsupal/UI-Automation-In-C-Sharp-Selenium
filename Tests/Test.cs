namespace UIAutomationTemplate
{
    public class Test2 : IClassFixture<Helper>
    {
        Helper setup;
        public ExtentTest test;
        public static ExtentReports extent { get; set; }

        public Test2(Helper setup)
        {
            this.setup = setup;
        }


    }
}