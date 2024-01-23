using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UIAutomationTemplate.Utility;
using Automation_Freshers.Keyword;

namespace UIAutomationTemplate.Pages
{
    public class Hotel_Page
    {

        public WebDriver wait;
        public static void Navigate_To_Hotel()
        {
            IWebElement hotelbtn = Browser.WEBDRIVER.FindElement(By.XPath("//span[contains(.,'Hotels')]/parent::a"));
            Browser.Wait_IsDisplayed(Browser.WEBDRIVER, hotelbtn, 20);
            JavaScriptUtility.drawBorder(hotelbtn, Browser.WEBDRIVER);
            hotelbtn.Click();
        }

        /*
        Method to search hotel
        please add check in check out date better add separete method
        */
        public static void Search_Hotel(string destination, int? children_per_room, int number_of_rooms, int adults_per_room, bool? isroomgroup, int? no_of_roomGroup_Or_Rooms)
        {
            IWebElement destinationdropdown = Browser.WEBDRIVER.FindElement(By.XPath("//select[@id='destinationId']"));
            Browser.Wait_IsDisplayed(Browser.WEBDRIVER, destinationdropdown, 20);
            JavaScriptUtility.drawBorder(destinationdropdown, Browser.WEBDRIVER);
            var selectElement = new SelectElement(destinationdropdown);
            selectElement.SelectByText(destination);
            IWebElement travellersNrooms = Browser.WEBDRIVER.FindElement(By.XPath("//label[contains(.,'Traveller and Room')]/following-sibling::div[1]"));
            Browser.Wait_IsDisplayed(Browser.WEBDRIVER, travellersNrooms, 10);

            JavaScriptUtility.drawBorder(travellersNrooms, Browser.WEBDRIVER);
            travellersNrooms.Click();

            if (isroomgroup == true)
            {
                if (number_of_rooms > 100)
                {
                    throw new InvalidOperationException("You exceeded the limit, only 100 room is allowed to book");
                }
                for (int i = 1; i <= no_of_roomGroup_Or_Rooms; i++)
                {
                    IWebElement room_No = Browser.WEBDRIVER.FindElement(By.XPath("//div[@class = 'groupSection']/div[" + i + "]//input[@name='selectedroomvalue']"));
                    Browser.Wait_IsDisplayed(Browser.WEBDRIVER, room_No, 10);
                    JavaScriptUtility.drawBorder(room_No, Browser.WEBDRIVER);

                    IWebElement adultPerRoom = Browser.WEBDRIVER.FindElement(By.XPath("//div[@class = 'groupSection']/div[" + i + "]//input[@name='adultspinner']"));
                    Browser.Wait_IsDisplayed(Browser.WEBDRIVER, adultPerRoom, 10);
                    JavaScriptUtility.drawBorder(adultPerRoom, Browser.WEBDRIVER);
                    room_No.Clear();
                    room_No.SendKeys(number_of_rooms.ToString());
                    adultPerRoom.Clear();
                    adultPerRoom.SendKeys(adults_per_room.ToString());
                    IWebElement add_group = Browser.WEBDRIVER.FindElement(By.XPath("//button[contains(text(),'Add Group')]"));
                    Browser.Wait_IsDisplayed(Browser.WEBDRIVER, add_group, 10);
                    JavaScriptUtility.drawBorder(add_group, Browser.WEBDRIVER);
                    add_group.Click();
                }

            }
            else
            {
                IWebElement more_room_option = Browser.WEBDRIVER.FindElement(By.XPath("//button[contains(text(),'More Room Options')]"));
                Browser.Wait_IsDisplayed(Browser.WEBDRIVER, more_room_option, 10);
                JavaScriptUtility.drawBorder(more_room_option, Browser.WEBDRIVER);
                more_room_option.Click();
                for (int i = 1; i <= no_of_roomGroup_Or_Rooms; i++)
                {
                    IWebElement adultspinner = Browser.WEBDRIVER.FindElement(By.XPath("//div[@class='roomSection-inner'][1]//input[@id = 'adultspinner']"));
                    Browser.Wait_IsDisplayed(Browser.WEBDRIVER, adultspinner, 10);
                    JavaScriptUtility.drawBorder(adultspinner, Browser.WEBDRIVER);
                    IWebElement childspinner = Browser.WEBDRIVER.FindElement(By.XPath("//div[@class='roomSection-inner'][1]//input[@id = 'adultspinner']"));
                    Browser.Wait_IsDisplayed(Browser.WEBDRIVER, childspinner, 10);
                    JavaScriptUtility.drawBorder(adultspinner, Browser.WEBDRIVER);
                    adultspinner.Clear();
                    adultspinner.SendKeys(adults_per_room.ToString());
                    childspinner.Clear();
                    childspinner.SendKeys(children_per_room.ToString());
                }
            }
            travellersNrooms.Click();
            IWebElement Searchbtn = Browser.WEBDRIVER.FindElement(By.XPath("//button[contains(.,'Search')]"));
            Browser.Wait_IsDisplayed(Browser.WEBDRIVER, Searchbtn, 10);
            JavaScriptUtility.drawBorder(Searchbtn, Browser.WEBDRIVER);
            Searchbtn.Click();

        }

        public static string Get_Total_Records()
        {
            IWebElement totalrecords = Browser.WEBDRIVER.FindElement(By.XPath("//input[@name='totalRecords']"));
            JavaScriptUtility.drawBorder(totalrecords, Browser.WEBDRIVER);
            JavaScriptUtility.scrollPageDown(Browser.WEBDRIVER);
            return totalrecords.GetAttribute("value");
        }

        public static string Get_Hotel_Count()
        {
            Thread.Sleep(2000);
            List<IWebElement> totalrecords = Browser.WEBDRIVER.FindElements(By.XPath("//input[@name='totalRecords']/following-sibling::div[contains(@class,'card')]")).ToList();
            return totalrecords.Count.ToString();
        }

        public static void select_Hotel(string hotel_name_OR_id)
        {
            Browser.WEBDRIVER.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            try { var tt = Int64.Parse(hotel_name_OR_id); }
            catch
            {
                IWebElement booknowbyname = Browser.WEBDRIVER.FindElement(By.XPath("//a[contains(.,'" + hotel_name_OR_id + "')]//parent::div/parent::div/following-sibling::div/descendant::a[contains(.,'Book Now')]"));
                Browser.Wait_IsDisplayed(Browser.WEBDRIVER, booknowbyname, 10);
                JavaScriptUtility.scrollIntoView(booknowbyname, Browser.WEBDRIVER);
                booknowbyname.Click();
            }
            IWebElement booknowbyid = Browser.WEBDRIVER.FindElement(By.XPath("//a[contains(@href,'" + hotel_name_OR_id + "')]//parent::div/parent::div/following-sibling::div/descendant::a[contains(.,'Book Now')]"));
            Browser.Wait_IsDisplayed(Browser.WEBDRIVER, booknowbyid, 10);
            JavaScriptUtility.scrollIntoView(booknowbyid, Browser.WEBDRIVER);
            booknowbyid.Click();
        }

        public static void Navigate_To_GuestDetail()
        {
            IWebElement Booknowbtn = Browser.WEBDRIVER.FindElement(By.XPath("//button[contains(.,'Book Now')]"));
			JavaScriptUtility.scrollIntoView(Booknowbtn, Browser.WEBDRIVER);
            Browser.Wait_IsDisplayed(Browser.WEBDRIVER, Booknowbtn, 10);
			Booknowbtn.Click();
        }

		
    }
}
