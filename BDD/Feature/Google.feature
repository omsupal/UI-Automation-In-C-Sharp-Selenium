Feature: Google Search Functionality
  As a user of Google,
  I want to search for information
  So that I can get relevant results.

  Scenario: Perform a search for a keyword on Google
    Given I have opened the browser
    And I navigate to "https://www.google.com"
    When I enter "SpecFlow" in the search bar
    And I press the search button
    Then the search results page should be displayed
    And the results should contain "SpecFlow"