namespace Automation_Freshers.Helper
{
	public class Waits
	{
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