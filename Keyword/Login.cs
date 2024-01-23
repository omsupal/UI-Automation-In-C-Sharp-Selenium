using System;
using Xunit;
using OpenQA.Selenium;
using UIAutomationTemplate;
using UIAutomationTemplate.Pages;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Automation_Freshers.Keyword;
using System.Threading;
using System.IO.Enumeration;
using System.IO;


namespace MyNamespace
{
	[Binding]
	public class Login : IClassFixture<Helper>
	{
		Helper setup;
		private Login_Page login_Page;
		private IWebDriver driver;
		public static ExtentTest scenario;
		public Hotel_Page hotelPage;
		public static ExtentReports extent { get; set; }
		public static ExtentTest test;


		public Login(Helper setup)
		{
			this.setup = setup;

			Browser.SETUP("chrome");

			driver = Browser.WEBDRIVER;
			login_Page = new Login_Page(driver);
			hotelPage = new Hotel_Page();
		}

		[Given(@"User opens URL ""(.*)""")]
		public void OpenBroswer(string URL)
		{

			setup.ExtentStart();

			//feature
			var feature = Helper.EXTENT.CreateTest<Feature>("Login");
			//scenario
			scenario = feature.CreateNode<Scenario>("Successful login with valid credentials");
			// steps
			test = scenario.CreateNode<Given>("User  opens URL (.*)");
			try
			{
				driver.Navigate().GoToUrl(URL);

				test.Log(Status.Pass, "User  opens URL (.*)");
			}
			catch
			{
				Helper.TakeScreenShot(Browser.WEBDRIVER, "OpenBrowser");
				test.AddScreenCaptureFromPath(Helper.screenshotpath);
				test.Log(Status.Fail, "User  opens URL (.*)");
				throw new InvalidOperationException("User  opens URL (.*)");

			}

		}

		[When(@"user enters UserName as ""(.*)"" and Password as ""(.*)""")]
		public void SignIn(string userName, string password)
		{
			try
			{
				login_Page.Login(userName, password);
				login_Page.ClickLogin();
				ExtentTest test = scenario.CreateNode<When>("user enters UserName and Password");
				test.Log(Status.Pass, "user enters UserName as  and Password");
			}
			catch
			{
				Helper.TakeScreenShot(Browser.WEBDRIVER, "OpenBrowser");
				test.AddScreenCaptureFromPath(Helper.screenshotpath);
				test.Log(Status.Fail, "user enters UserName as  and Password");
				throw new InvalidOperationException("user enters invalid UserName as  or Password");

			}
		}

		[When(@"user click on Login button")]
		public void ClickOnLogin()
		{
			login_Page.ClickLogin();
			scenario.CreateNode<When>("click on Login button");
		}

		[When(@"Page Title should be Dashboard")]
		public void Verify_DashBoardPage()
		{
			login_Page.Dashboard();
			scenario.CreateNode<Then>("Dashboard Page should be displayed");

		}

		[Given(@"user navigate to the website ""(.*)""")]
		public void Givenusernavigatetothewebsite(string args1)
		{
			var feature = Helper.EXTENT.CreateTest<Feature>("swara");

			//scenario
			scenario = feature.CreateNode<Scenario>("Unsuccessful login");

			// steps
			scenario.CreateNode<Given>("user navigate to the website  (.*)");



			driver.Navigate().GoToUrl(args1);
		}

		[When(@"enters UserName as ""(.*)"" and Password as ""(.*)""")]
		public void WhenentersUserNameasandPasswordas(string args1, string args2)
		{

			login_Page.Login("swarali.thorat@traveazy.com", "Swara");
			scenario.CreateNode<When>("Enter Username and password");

		}

		[When(@"click on ""(.*)"" button")]
		public void Whenclickonbutton(string args1)
		{
			login_Page.ClickLogin();
			scenario.CreateNode<When>("Click on login Button");
		}

		[Then(@"error message Pop up displayed with ""(.*)""")]
		public void ThenerrormessagePopupdisplayedwith(string args1)
		{
			scenario.CreateNode<Then>("Error message Pop up should be displayed");

		}


	}
}
