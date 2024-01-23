using System.Security;
using System;
using System.Net.Mail;
using System.Net;
using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Remote;
using Automation_Freshers.Keyword;

namespace UIAutomationTemplate
{
	public class Helper : IDisposable
	{
		public static IWebDriver WEBDRIVER { get; set; }
		public static ExtentReports EXTENT { get; set; }
		public static string B2B_URL { get; set; }
		public static string B2C_URL { get; set; }
		public static string NODE_URL { get; set; }
		public static string driver { get; set; }
		public static string screenshotpath { get; set; }
		public Configsetting Configsetting { get; private set; }


		public static ExtentTest test;
		public Helper()
		{
			//ExtentStart();
			B2B_URL = "https://b2b.umrahme.me/home/en-eu";
			B2C_URL = "https://www.umrahme.me/home/en-eu";

			// var builder = new ConfigurationBuilder()
			//          .SetBasePath(Directory.GetCurrentDirectory())
			//          .AddJsonFile("Config/ConfigSetting.json", optional: false);

			// IConfiguration config = builder.Build();

			// Configsetting = config.GetSection("ConfigSetting").Get<Configsetting>();

		}



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

		/// <summary>
		/// This Method will take the screenshot and save it in Screenshots folder
		/// <param name="driver"></param>
		/// <param name="screenshotname"></param>
		/// </summary>
		public static void TakeScreenShot(IWebDriver driver, string screenshotname)
		{
			String date_time = DateTime.Now.ToString("h:mm:ss tt");
			Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
			screenshotpath = "../../../Screenshots" + "//Screenshots" + screenshotname + ".png";
			screenshot.SaveAsFile("../../../Screenshots" + "//Screenshots" + screenshotname + ".png", ScreenshotImageFormat.Png);
		}

		/// <summary>
		/// This Method will Create new extent report
		/// </summary>
		public void ExtentStart()
		{
			EXTENT = new ExtentReports();
			var htmlreporter = new ExtentHtmlReporter(@"../../../Reports/" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
			EXTENT.AttachReporter(htmlreporter);
		}

		public void Dispose()
		{
			Browser.WEBDRIVER.Quit();
			Helper.EXTENT.Flush();
		}

		/// <summary>
		/// This Method will be used to send an email
		/// subject = which will contain Mail subjec"
		/// mailbody = which will contain the body of the mail (it accepts Html)
		/// fromemail = which will contain senders email
		/// toemail = which will contain receivers email
		/// password = which will contain password of the senders email
		/// SecureString SecuredPassword = new NetworkCredential("", "password").SecurePassword;
		/// <param name="subject"></param>
		/// <param name="mailbody"></param>
		/// <param name="fromemail"></param>
		/// <param name="password"></param>
		/// <param name="toemail"></param>
		/// </summary>
		public void SendMail(string subject, string mailbody, string fromemail, SecureString password, string toemail)
		{
			MailMessage mail = new MailMessage();
			mail.From = new MailAddress(fromemail);
			mail.To.Add(toemail);
			mail.Subject = subject;
			mail.Body = mailbody;
			mail.IsBodyHtml = true;
			// mail.CC.Add("ProductionSupport@traveazy.com");
			mail.Attachments.Add(new Attachment(@"../../../Reports/index.html"));
			SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
			client.Credentials = new NetworkCredential(fromemail, password);
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.EnableSsl = true;
			client.Send(mail);
		}


		/// <summary>
		/// This method will be for uploading file from windows explorer
		/// This methods need two parameters
		/// Relative_exe_Path = which will contain executable file relative path e.g "../../../Helper/upload.exe"
		/// relative_file_path = which will contain executable file relative path e.g "../../../DataFiles/TestData.xlsx"
		/// <param name="Relative_exe_Path"></param>
		/// <param name="relative_file_path"></param>
		/// </summary>
		public static void FileUpload(string Relative_exe_Path, string relative_file_path)
		{
			string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string sFile = System.IO.Path.Combine(sCurrentDirectory, @relative_file_path);
			string sFilePath = Path.GetFullPath(sFile);
			System.Diagnostics.Process.Start(@Relative_exe_Path, sFilePath);
		}
	}


}
