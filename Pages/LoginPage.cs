using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using UIAutomationTemplate.Utility;
using Automation_Freshers.Keyword;
namespace UIAutomationTemplate.Pages
{
    public class Login_Page
    {

        private IWebDriver driver;
		public bool Flag;
        private WebDriverWait wait;
        public Login_Page(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public void Login(string username, string password)
        {
            IWebElement Usernamefield = driver.FindElement(By.XPath("//input[@name='username']"));
            IWebElement Passwordfield = driver.FindElement(By.XPath("//input[@name='password']"));
            IWebElement Loginbutton = driver.FindElement(By.XPath("//button[@id='kt_login_signin_submit']"));

            JavaScriptUtility.drawBorder(Usernamefield, driver);
            Usernamefield.SendKeys(username);
            JavaScriptUtility.drawBorder(Passwordfield, driver);
            Passwordfield.SendKeys(password);
            JavaScriptUtility.drawBorder(Loginbutton, driver);
            // Loginbutton.Click();
            // Thread.Sleep(5000);
        }

        public void ClickLogin()
        {
            IWebElement Loginbutton = driver.FindElement(By.XPath("//button[@id='kt_login_signin_submit']"));
            Loginbutton.Click();
            IWebElement dashboard = driver.FindElement(By.XPath("//span[contains(text(),'Dashboard')]/parent::a"));
			  try {
                 Flag = Browser.Wait_IsDisplayed(driver,dashboard, 10);
             }
             catch{
             }

 

            if (Flag)
            {
                throw new InvalidOperationException("User not logged in");
            }
            Thread.Sleep(5000);
        }
        public void Dashboard()
        {
            IWebElement dashboard = driver.FindElement(By.XPath("//span[contains(text(),'Dashboard')]/parent::a"));
            dashboard.Click();
        }
       
        public void Register(string Name, string Lastname, string Mobno, string email, string Pass)
        {
            IWebElement Register = driver.FindElement(By.XPath("//a[contains(.,'Register !')]"));
            Register.Click();

            IWebElement firstname = driver.FindElement(By.XPath("//input[@name='firstname']"));
            IWebElement lastname = driver.FindElement(By.XPath("//input[@name='lastname']"));
            IWebElement mobilenumber = driver.FindElement(By.XPath("//input[@name='countryphonenumber']"));
            IWebElement emailid = driver.FindElement(By.XPath("//input[@name='signupemail']"));
            IWebElement password = driver.FindElement(By.XPath("//input[@name='signuppassword']"));
            IWebElement confirmpassword = driver.FindElement(By.XPath("//input[@name='cpassword']"));
            IWebElement termsandconditions = driver.FindElement(By.XPath("//input[@name='agree']"));
            IWebElement Registerbtn = driver.FindElement(By.XPath("//button[contains(.,'Register')]"));

            firstname.SendKeys(Name);
            lastname.SendKeys(Lastname);
            mobilenumber.SendKeys(Mobno);
            emailid.SendKeys(email);
            password.SendKeys(Pass);
            confirmpassword.SendKeys(Pass);
            termsandconditions.Click();
            Registerbtn.Click();
        }
        public void forgotpassword(string email)
        {
            IWebElement forgotpass = driver.FindElement(By.XPath("//a[contains(.,'Forgot Password?')]"));
            forgotpass.Click();
            IWebElement emailid = driver.FindElement(By.XPath("//input[@id='forgotpwdemail']"));
            IWebElement submitbtn = driver.FindElement(By.XPath("//button[contains(.,'Submit')]"));
            IWebElement cancelbtn = driver.FindElement(By.XPath("//button[contains(.,'Cancel')]"));
            emailid.SendKeys(email);
            submitbtn.Click();

        }
    }
}
