
namespace UIAutomationTemplate
{
	public class Helper : IDisposable
	{
		public static IWebDriver WEBDRIVER { get; set; }
		public static string B2B_URL { get; set; }
		public string WEB_URL { get; set; }
		public static string NODE_URL { get; set; }
		public static string driver { get; set; }
		public Configsetting Configsetting { get; private set; }


		public static ExtentTest test;
		

		public static void TestGrid()
		{
			// try{
			NODE_URL = "http://100.96.1.91:5555/wd/hub"; //Pass Node URL Here
			var capabilities = new ChromeOptions();
			capabilities.PlatformName = "Windows 10";
			capabilities.BrowserVersion = "108.0.5359.7100";
			RemoteWebDriver driver = new RemoteWebDriver(new Uri(NODE_URL), capabilities);
			driver.Manage().Window.FullScreen();
			driver.Navigate().GoToUrl(B2B_URL);
			// }
			// catch(Exception e)
			// {


			// }

		}

		

		

		public void Dispose()
		{
			Browser.WEBDRIVER.Quit();
			UIServices.EXTENT.Flush();
		}

		
	}

}
