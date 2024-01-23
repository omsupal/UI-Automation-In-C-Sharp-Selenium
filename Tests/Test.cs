using System.Threading;
using System.IO.Enumeration;
using System.IO;
using System;
using Xunit;
using OpenQA.Selenium;
using UIAutomationTemplate.Pages;
using UIAutomationTemplate.Keyword_Repository;
using NPOI.XSSF.UserModel;
using AventStack.ExtentReports;
using UIAutomationTemplate.Utility;
using System.Configuration;
using Automation_Freshers.Helper;
using Automation_Freshers.Keyword;

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
        public void Hotel_Count_IsEqualTo_TotalRecords()
        {
            // test = null;
            //extent = setup.EXTENT;
            test = extent.CreateTest("Verify that listed hotel count is equal to total records displayed");

            //Test Data Preparing
            // var username = setup.GetTestData("TestData", 0, 1, 0);
            // var password = setup.GetTestData("TestData", 0, 1, 1);
            var username = setup.Configsetting.UserName;
            var password = setup.Configsetting.Password;
            test.Log(Status.Pass, "Setup Test Data"); //Log to extent report

            //Driver Setup
            Browser.SETUP("chrome");
            Helper.WEBDRIVER.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Helper.WEBDRIVER.Manage().Window.Maximize();
            Login_Page login = new Login_Page(Helper.WEBDRIVER);
           // Hotel hotel = new Hotel(Helper.WEBDRIVER);
            try
            {
                Helper.WEBDRIVER.Navigate().GoToUrl(Helper.B2B_URL);
                test.Log(Status.Pass, Helper.B2B_URL + " is opened");

            }
            catch
            {
                Helper.TakeScreenShot(Helper.WEBDRIVER,"");
                test.Log(Status.Fail, Helper.B2B_URL + " is opened");
                throw new InvalidOperationException(Helper.B2B_URL + " is not opened");
            }
            try
            {
                login.Login(username, password);
                login.ClickLogin();
                test.Log(Status.Pass, " User is logged-in");
            }
            catch
            {
                Helper.TakeScreenShot(Helper.WEBDRIVER, "");
                test.Log(Status.Fail, " User is logged-in");
                throw new InvalidOperationException("User is not logged-in");

            }
            try
            {
                //hotel.Navigate_To_Hotel();
                test.Log(Status.Pass, "Click on Hotel button");
            }
            catch
            {
                test.Log(Status.Fail, "Click on Hotel button");
                throw new InvalidOperationException("Hotel button element not found");
            }
            try
            {
                //hotel.Search_Hotel("Makkah", null, 1, 2, true, 1);
                //test.Log(Status.Pass, "Click on search by selecting valid data");
            }
            catch
            {
                test.Log(Status.Fail, "Click on search by selecting valid data");
                throw new InvalidOperationException("Error in search hotel");
            }
            try
            {
                // string hotelrecord = hotel.Get_Total_Records();
                // string hotelcount = hotel.Get_Hotel_Count();
               // hotel.Get_Hotel_Details("wahat");
                // Assert.Equal(hotelrecord, hotelcount);
                // test.Log(Status.Pass, "Total records is equal to total hotel count");
            }
            catch
            {
                Helper.TakeScreenShot(Helper.WEBDRIVER, "");
                test.Log(Status.Fail, "Total records is equal to total hotel count");
                throw new InvalidOperationException("Total records is not equal to total hotel count");
            }
        }

        [Fact]
        public void getTest()
        {
            VSTS_Helper.GetTestPlanAsync();
        }

    }
}