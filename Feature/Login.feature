
Feature: Login

    @Sanity
    Scenario Outline: Successful login with valid credentials
        Given User opens URL "https://b2b.umrahme.me/home/en-eu"
        When user enters UserName as <UserEmail> and Password as <Password>
        When user click on Login button
        When Page Title should be Dashboard
        # When Search for Hotel with City "Makkah" child "1", Room count "1", Adult per room "1", Room group applicable "true" and roomGroupCount "1"

 #   @Sanity
 #   Scenario Outline: Unsuccessful login
 #       Given user navigate to the website "https://b2b.umrahme.me/home/en-eu"
 #       When  enters UserName as  <UserEmail> and Password as <Password>
 #       When  click on "Login" button
 #       Then error message Pop up displayed with "Please enter all the required information"
 #And user click on "Ok got it!" button
 #And user returns back on login page

#@source:TestData.xlsx:LoginData
Examples: 
        | UserEmail                   | Password |
        | "swarali.thorat@traveazy.com" | "Swara@27" | 
