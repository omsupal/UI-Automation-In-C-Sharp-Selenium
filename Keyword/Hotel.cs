using UIAutomationTemplate.Pages;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using UIAutomationTemplate.Utility;
using TechTalk.SpecFlow;

namespace UIAutomationTemplate.Keyword_Repository
{
    [Binding]
    public class Hotel : Hotel_Page
    {
     
        [When(@"Search for Hotel with City ""(.*)"" child ""(.*)"", Room count ""(.*)"", Adult per room ""(.*)"", Room group applicable ""(.*)"" and roomGroupCount ""(.*)""")]
        public void Get_Hotel_Listing(string destination, int children_per_room, int number_of_rooms, int adults_per_room, bool? isroomgroup, int no_of_roomGroup_Or_Rooms)
        {
            //flag for isroomgroup
            Navigate_To_Hotel();
            Search_Hotel(destination, children_per_room, number_of_rooms, adults_per_room, isroomgroup, no_of_roomGroup_Or_Rooms);
          //  Thread.Sleep(5000);
        }

        [Then(@"Select hotel for booking ""(.*)""")]
        public void Get_Hotel_Details(string Hotel_Name_OR_Id)
        {
            select_Hotel(Hotel_Name_OR_Id);

        }

    }
}