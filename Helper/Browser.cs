namespace Automation_Freshers.Helper
{
	public class Browser
	{
		public static IWebDriver WEBDRIVER { get; set; }

		/// <summary>
		/// This Method will be used to setup specific browser
		/// Pass this as string : chrome,firefox,edge,headless
		/// <param name="browsername"></param>
		/// </summary>
		public static void SETUP(string browsername)
		{
			if (browsername == "chrome")
			{
				new DriverManager().SetUpDriver(new ChromeConfig());
				WEBDRIVER = new ChromeDriver();
				WEBDRIVER.Manage().Window.Maximize();

			}
			else if (browsername == "firefox")
			{
				new DriverManager().SetUpDriver(new FirefoxConfig());
				WEBDRIVER = new FirefoxDriver();
			}
			else if (browsername == "edge")
			{
				new DriverManager().SetUpDriver(new EdgeConfig());
				WEBDRIVER = new EdgeDriver();
			}
			else if (browsername == "headless")
			{
				ChromeOptions options = new ChromeOptions();
				options.AddArgument("--headless");
				options.AddArgument("--window-size=1920,1080");
				new DriverManager().SetUpDriver(new ChromeConfig());
				WEBDRIVER = new ChromeDriver(options);
			}
			// Set implicit wait
			WEBDRIVER.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Adjust the time as needed
		}

	}
}
