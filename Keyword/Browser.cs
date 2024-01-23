using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System;

namespace Automation_Freshers.Keyword
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

		}

		/// <summary>
		/// This Method will wait for given time to checked whether respective element displayed or not
		/// This Method will throw TimeOutException incase given element is not displayed
		/// <param name="driver"></param>
		/// <param name="ele"></param>
		/// <param name="time"></param>
		/// </summary>
		public static bool Wait_IsDisplayed(IWebDriver driver, IWebElement ele, int time)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
			Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
			{
				if (ele.Displayed)
				{
					return true;
				}
				return false;
			});
			return wait.Until(waitForElement);
		}

		/// <summary>
		/// This Method will wait for given time to checked whether respective element enabled or not
		/// This Method will throw TimeOutException incase given element is not enabled
		/// <param name="driver"></param>
		/// <param name="ele"></param>
		/// <param name="time"></param>
		/// </summary>
		public static void Wait_IsEnabled(IWebDriver driver, IWebElement ele, int time)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
			Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
			{
				if (ele.Enabled)
				{
					return true;
				}
				return false;
			});
			wait.Until(waitForElement);
		}

		/// <summary>
		/// This Method will wait for given time to checked whether respective element selected or not
		/// This Method will throw TimeOutException incase given element is not selected
		/// <param name="driver"></param>
		/// <param name="ele"></param>
		/// <param name="time"></param>
		/// </summary>
		public static void Wait_IsSelected(IWebDriver driver, IWebElement ele, int time)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
			Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
			{
				if (ele.Selected)
				{
					return true;
				}
				return false;
			});
			wait.Until(waitForElement);
		}
	}
}
