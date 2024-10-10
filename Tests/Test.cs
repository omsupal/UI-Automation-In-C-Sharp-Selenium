namespace UIAutomationTemplate
{
    public class Test2 : IClassFixture<Helper>
    {
        Helper setup;
        public ExtentTest test;
        public UIServices services;
        public ExtentTest extentTest { get; set; } // Renamed from Test to extentTest
        public Test2(Helper setup)
        {
            this.setup = setup;
            services = new UIServices();
            services.ExtentStart();
        }

        [Fact]
        public void TestName()
        {
            extentTest = UIServices.EXTENT.CreateTest("Test_" + Guid.NewGuid().ToString()); // Unique test names
            extentTest.Log(Status.Info, "Navigating to google");

            setup.WEB_URL = "https://www.google.com";
            Browser.SETUP("chrome");
            Browser.WEBDRIVER.Navigate().GoToUrl(setup.WEB_URL);

            // Log the successful step
            extentTest.Log(Status.Pass, "Successfully navigated to Google");

            // Add the screenshot to the Extent report
            UIServices.TakeScreenShot(Browser.WEBDRIVER, "Test");
            extentTest.AddScreenCaptureFromPath("../../../Screenshots" + "//Screenshots" + "Test" + ".png");

            // Assert the title of the page
            string url = Browser.WEBDRIVER.Url;
            Assert.Equal("Google", Browser.WEBDRIVER.Title);
            extentTest.Log(Status.Pass, "Page title verified successfully.");
        }

        [Theory]
        [InlineData("chrome", "https://www.google.com")]
        [InlineData("edge", "https://www.google.com")]
        public void TestNameTheory(string browsername, string weburl)
        {
            extentTest = UIServices.EXTENT.CreateTest("Test_" + Guid.NewGuid().ToString()); // Unique test names

            extentTest.Log(Status.Info, browsername);
            extentTest.Log(Status.Info, "Navigating to google");

            Browser.SETUP(browsername);
            Browser.WEBDRIVER.Navigate().GoToUrl(weburl);

            // Log the successful step
            extentTest.Log(Status.Pass, "Successfully navigated to Google");

            // Add the screenshot to the Extent report
            UIServices.TakeScreenShot(Browser.WEBDRIVER, "Test");
            extentTest.AddScreenCaptureFromPath("../../../Screenshots" + "//Screenshots" + "Test" + ".png");

            // Assert the title of the page
            string url = Browser.WEBDRIVER.Url;
            Assert.Equal("Google", Browser.WEBDRIVER.Title);
            extentTest.Log(Status.Pass, "Page title verified successfully.");

            // Ensure WebDriver and ExtentReport are properly disposed of after each test
            Browser.WEBDRIVER.Quit();
            Browser.WEBDRIVER.Dispose();

            // Flush the report to write test results after each run
            UIServices.EXTENT.Flush();
        }


    }
}