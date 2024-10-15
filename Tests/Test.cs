namespace UIAutomationTemplate
{
    public class Test2 : IClassFixture<Helper>
    {
        Helper setup;
        public ExtentTest test;
        public ExtentTest extentTest { get; set; }
        public Test2(Helper setup)
        {
            this.setup = setup;
        }

        [Fact]
        public void TestName()
        {
            extentTest = setup.services.EXTENT.CreateTest("Test_" + Guid.NewGuid().ToString()); // Unique test names
            extentTest.Log(Status.Info, "Navigating to google");

            setup.WEB_URL = "https://www.traveazy.me/hotel/en-sa";
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl(setup.WEB_URL);
            _ = setup._browser.LogNetworkRequests(setup._browser.WEBDRIVER, setup.WEB_URL);
            // Log the successful step
            extentTest.Log(Status.Pass, "Successfully navigated to Google");

            // Add the screenshot to the Extent report
            UIServices.TakeScreenShot(setup._browser.WEBDRIVER, "omkar");
            extentTest.AddScreenCaptureFromPath("../../../Screenshots" + "//Screenshots" + "omkar" + ".png");

            // Assert the title of the page
            string url = setup._browser.WEBDRIVER.Url;
            Assert.Equal("Google", setup._browser.WEBDRIVER.Title);
            extentTest.Log(Status.Pass, "Page title verified successfully.");
        }

        [Theory]
        [InlineData("chrome", "https://www.google.com")]
        [InlineData("edge", "https://www.google.com")]
        public void TestNameTheory(string browsername, string weburl)
        {
            extentTest = setup.services.EXTENT.CreateTest("Test_" + Guid.NewGuid().ToString()); // Unique test names


            extentTest.Log(Status.Info, browsername);
            extentTest.Log(Status.Info, "Navigating to google");

            setup._browser.SETUP(browsername);
            setup._browser.WEBDRIVER.Navigate().GoToUrl(weburl);

            // Log the successful step
            extentTest.Log(Status.Pass, "Successfully navigated to Google");

            // Add the screenshot to the Extent report
            UIServices.TakeScreenShot(setup._browser.WEBDRIVER, browsername);
            extentTest.AddScreenCaptureFromPath("../../../Screenshots" + "//Screenshots" + browsername + ".png");

            // Assert the title of the page
            string url = setup._browser.WEBDRIVER.Url;
            Assert.Equal("Google", setup._browser.WEBDRIVER.Title);
            extentTest.Log(Status.Pass, "Page title verified successfully.");

            // Ensure WebDriver and ExtentReport are properly disposed of after each test
            setup._browser.WEBDRIVER.Quit();
            setup._browser.WEBDRIVER.Dispose();

            // Flush the report to write test results after each run
            //setup.services.EXTENT.Flush();
        }

        [Fact]
        public void HandleSimpleAlert()
        {

            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com/javascript_alerts");

            IWebElement alertButton = setup._browser.WEBDRIVER.FindElement(By.XPath("//button[text()='Click for JS Alert']"));
            alertButton.Click();
            IAlert alert = setup._browser.WEBDRIVER.SwitchTo().Alert();
            string alertText = alert.Text;

            Console.WriteLine("Alert Text: " + alertText);

            alert.Accept();

            IWebElement result = setup._browser.WEBDRIVER.FindElement(By.Id("result"));
            Assert.Equal("You successfully clicked an alert", result.Text);
        }

        [Fact]
        public void HandleConfirmationAlert_Accept()
        {

            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com/javascript_alerts");


            IWebElement confirmButton = setup._browser.WEBDRIVER.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
            confirmButton.Click();


            IAlert confirmationAlert = setup._browser.WEBDRIVER.SwitchTo().Alert();
            string alertText = confirmationAlert.Text;
            Console.WriteLine("Confirmation Alert Text: " + alertText);
            confirmationAlert.Accept();


            IWebElement result = setup._browser.WEBDRIVER.FindElement(By.Id("result"));
            Assert.Equal("You clicked: Ok", result.Text);
        }


        [Fact]
        public void HandlePromptAlert()
        {
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com/javascript_alerts");

            IWebElement promptButton = setup._browser.WEBDRIVER.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
            promptButton.Click();
            IAlert promptAlert = setup._browser.WEBDRIVER.SwitchTo().Alert();
            string alertText = promptAlert.Text;
            Console.WriteLine("Prompt Alert Text: " + alertText);
            string inputText = "Sample Text";
            promptAlert.SendKeys(inputText);
            promptAlert.Accept();

            IWebElement result = setup._browser.WEBDRIVER.FindElement(By.Id("result"));
            Assert.Equal($"You entered: {inputText}", result.Text);
        }

        [Fact]
        public void FindMultipleElements()
        {
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com");

            // Find all links (<a> elements) on the page
            var links = setup._browser.WEBDRIVER.FindElements(By.TagName("a"));

            Console.WriteLine("Total links found: " + links.Count);


            foreach (var link in links)
            {
                Console.WriteLine("Link text: " + link.Text);
            }

            // Verify at least one link was found
            Assert.True(links.Count > 0, "No links were found on the page.");
        }

        [Fact]
        public void TestFlashElement()
        {
            // Set up WebDriver and navigate to the test page
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com");

            // Locate an element to flash (e.g., a link)
            IWebElement element = setup._browser.WEBDRIVER.FindElement(By.LinkText("A/B Testing"));

            // Use JavaScriptUtility to flash the element
            JavaScriptUtility.flash(element, setup._browser.WEBDRIVER);

            // Optionally, assert if element exists or is displayed
            Assert.True(element.Displayed);

        }

        [Fact]
        public void TestDrawBorderOnElement()
        {
            // Set up WebDriver and navigate to the test page
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com");

            // Locate an element to draw a border (e.g., a heading)
            IWebElement element = setup._browser.WEBDRIVER.FindElement(By.XPath("//h1"));

            // Use JavaScriptUtility to draw a border around the element
            JavaScriptUtility.drawBorder(element, setup._browser.WEBDRIVER);

            // Verify that the element is still displayed after drawing the border
            Assert.True(element.Displayed);
        }

        [Fact]
        public void TestClickElementByJavaScript()
        {
            // Set up WebDriver and navigate to the test page
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com");

            // Locate an element to click (e.g., a link)
            IWebElement element = setup._browser.WEBDRIVER.FindElement(By.LinkText("A/B Testing"));

            // Use JavaScriptUtility to click the element
            JavaScriptUtility.clickElementByJS(element, setup._browser.WEBDRIVER);

            // Verify the page navigated after clicking
            Assert.Equal("https://the-internet.herokuapp.com/abtest", setup._browser.WEBDRIVER.Url);
        }

        [Fact]
        public void TestGenerateAlertByJavaScript()
        {
            // Set up WebDriver and navigate to the test page
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com");

            // Use JavaScriptUtility to generate a custom alert
            JavaScriptUtility.generateAlert(setup._browser.WEBDRIVER, "This is a test alert!");

            // Switch to the alert and accept it
            IAlert alert = setup._browser.WEBDRIVER.SwitchTo().Alert();
            Assert.Equal("This is a test alert!", alert.Text);
            alert.Accept();
        }

        [Fact]
        public void TestScrollPageDownByJavaScript()
        {
            // Set up WebDriver and navigate to the test page
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com/infinite_scroll");

            // Use JavaScriptUtility to scroll the page down
            JavaScriptUtility.scrollPageDown(setup._browser.WEBDRIVER);
        }

        [Fact]
        public void TestScrollElementIntoView()
        {
            // Set up WebDriver and navigate to the test page
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com/large");

            // Locate an element that is not in the initial view
            IWebElement element = setup._browser.WEBDRIVER.FindElement(By.Id("large-table"));

            // Use JavaScriptUtility to scroll to the element
            JavaScriptUtility.scrollIntoView(element, setup._browser.WEBDRIVER);

            // Verify that the element is now displayed after scrolling
            Assert.True(element.Displayed);
        }

        [Fact]
        public void TestGetTitleByJavaScript()
        {
            // Set up WebDriver and navigate to the test page
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com");

            // Use JavaScriptUtility to get the title of the page
            string title = JavaScriptUtility.getTitleByJS(setup._browser.WEBDRIVER);

            // Verify that the title matches the expected title
            Assert.Equal("The Internet", title);
        }

        [Fact]
        public void TestDragAndDrop()
        {
            // Set up WebDriver and navigate to a test page that has drag and drop functionality
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com/drag_and_drop");

            // Locate the source element (the element to be dragged)
            IWebElement sourceElement = setup._browser.WEBDRIVER.FindElement(By.Id("column-a"));

            // Locate the target element (where the source element should be dropped)
            IWebElement targetElement = setup._browser.WEBDRIVER.FindElement(By.Id("column-b"));

            // Create an instance of the Actions class
            Actions action = new Actions(setup._browser.WEBDRIVER);

            // Perform drag and drop action
            action.DragAndDrop(sourceElement, targetElement).Perform();

            // Verify the drag and drop was successful (e.g., by checking the position or text change)
            string sourceTextAfterDrop = sourceElement.Text;
            Assert.Equal("B", sourceTextAfterDrop);
        }

        [Fact]
        public void TestCopyAndPasteInSameField()
        {
            // Set up WebDriver and navigate to a test page with an input field
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com/key_presses");

            // Locate the input field where we will simulate typing, copying, and pasting
            IWebElement inputField = setup._browser.WEBDRIVER.FindElement(By.Id("target"));

            // Create an instance of the Actions class
            Actions action = new Actions(setup._browser.WEBDRIVER);

            // Step 1: Type 'Hello' in the input field using SendKeys
            inputField.SendKeys("Hello");

            // Step 2: Perform Ctrl + A to select all text
            action.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();

            // Step 3: Perform Ctrl + C to copy the selected text
            action.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control).Perform();

            // Step 4: Move the cursor to the end of the text before pasting (use End key)
            action.SendKeys(Keys.End).Perform();

            // Step 5: Perform Ctrl + V to paste the copied text
            action.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control).Perform();

            // At this point, the input field should contain "HelloHello" (original + pasted text)

            // Verify that the input field contains the expected text
            string inputText = inputField.GetAttribute("value");
            Assert.Equal("HelloHello", inputText);
        }

        [Fact]
        public void TestSelectDropdownOption()
        {
            // Set up WebDriver and navigate to a test page with a dropdown
            setup._browser.SETUP("chrome");
            setup._browser.WEBDRIVER.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");

            // Locate the dropdown element
            IWebElement dropdownElement = setup._browser.WEBDRIVER.FindElement(By.Id("dropdown"));

            // Create a SelectElement object to interact with the dropdown
            SelectElement selectDropdown = new SelectElement(dropdownElement);

            // Step 1: Select option by visible text
            selectDropdown.SelectByText("Option 1");

            // Verify the selected option
            Assert.Equal("Option 1", selectDropdown.SelectedOption.Text);

            // Step 2: Select option by value
            selectDropdown.SelectByValue("2");

            // Verify the selected option
            Assert.Equal("Option 2", selectDropdown.SelectedOption.Text);

            // Step 3: Select option by index (0-based index, so index 1 is "Option 1")
            selectDropdown.SelectByIndex(1);

            // Verify the selected option
            Assert.Equal("Option 1", selectDropdown.SelectedOption.Text);
        }




    }
}