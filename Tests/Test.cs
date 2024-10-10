namespace UIAutomationTemplate
{
    public class Test2 : IClassFixture<Helper>
    {
        Helper setup;
        public ExtentTest test;
        public UIServices services;
        public static ExtentReports extent { get; set; }
        public ExtentTest extentTest { get; set; } // Renamed from Test to extentTest
        public Test2(Helper setup)
        {
            this.setup = setup;
            services = new UIServices();
            services.ExtentStart();
            extentTest = UIServices.EXTENT.CreateTest("Test_" + Guid.NewGuid().ToString()); // Unique test names
        }

        [Fact]
        public void TestName()
        {
            extentTest.Log(Status.Info, "Navigating to google");
            setup.WEB_URL = "https://www.google.com";

            Browser.SETUP("chrome");
            Browser.WEBDRIVER.Navigate().GoToUrl(setup.WEB_URL);

            // Log the successful step
            extentTest.Log(Status.Pass, "Successfully navigated to Google");
            UIServices.TakeScreenShot(Browser.WEBDRIVER, "Test");
            string url = Browser.WEBDRIVER.Url;
            // Add the screenshot to the Extent report
            extentTest.AddScreenCaptureFromPath("../../../Screenshots" + "//Screenshots" + "Test" + ".png");
            // Assert the title of the page
            Assert.Equal("Google", Browser.WEBDRIVER.Title);
            extentTest.Log(Status.Pass, "Page title verified successfully.");
        }
    }
}