
using UIAutomationTemplate;

[Binding]
public class GoogleSearchSteps : IClassFixture<Helper>
{
    private IWebDriver _driver;
    private readonly Helper _helper;

    public GoogleSearchSteps(Helper helper)
    {
        _helper = helper;
        _driver = _helper.WEBDRIVER; // Get the shared WebDriver from Helper class
    }

    [Given(@"I have opened the browser")]
    public void GivenIHaveOpenedTheBrowser()
    {
        // Initialize ChromeDriver and maximize the window
        _helper._browser.SETUP("chrome");
    }

    [Given(@"I navigate to ""(.*)""")]
    public void GivenINavigateTo(string url)
    {
        // Navigate to the specified URL
        _helper._browser.WEBDRIVER.Navigate().GoToUrl(url);
    }

    [When(@"I enter ""(.*)"" in the search bar")]
    public void WhenIEnterInTheSearchBar(string searchTerm)
    {
        // Find the Google search bar and enter the search term
        IWebElement searchBar = _helper._browser.WEBDRIVER.FindElement(By.Name("q"));
        searchBar.SendKeys(searchTerm);
    }

    [When(@"I press the search button")]
    public void WhenIPressTheSearchButton()
    {
        // Simulate pressing the Enter key to submit the search
        IWebElement searchBar = _helper._browser.WEBDRIVER.FindElement(By.Name("q"));
        searchBar.SendKeys(Keys.Enter);
    }

    [Then(@"the search results page should be displayed")]
    public void ThenTheSearchResultsPageShouldBeDisplayed()
    {
        // Wait for the results page to load and check if results are displayed
        WebDriverWait wait = new WebDriverWait(_helper._browser.WEBDRIVER, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("search")));

        // Verify that the search results are displayed
        Assert.True(_helper._browser.WEBDRIVER.Url.Contains("search"), "Search results page not displayed.");
    }

    [Then(@"the results should contain ""(.*)""")]
    public void ThenTheResultsShouldContain(string searchTerm)
    {
        // Verify that the search term is found in the search results
        IWebElement body = _helper._browser.WEBDRIVER.FindElement(By.TagName("body"));
        Assert.Contains(searchTerm, body.Text);
    }

    [AfterScenario]
    public void TearDown()
    {
        // Quit the browser after the test
        _helper._browser.WEBDRIVER.Quit();
    }
}