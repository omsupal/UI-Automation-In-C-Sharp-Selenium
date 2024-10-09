using Automation_Freshers.Services;

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

        [Fact]
        public void TestName()
        {
            setup.WEB_URL = "https://www.traveazy.me";
            Browser.SETUP("chrome");
            Browser.WEBDRIVER.Navigate().GoToUrl(setup.WEB_URL);
            Services.TakeScreenShot(Browser.WEBDRIVER, "Test");
            string url = Browser.WEBDRIVER.Url;
            //Browser.WEBDRIVER.FindElement(By.XPath(""));
            Assert.Contains("traveazy.me",url);
        }
    }
}