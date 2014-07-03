Feature: PEGASUS-8163: Launch the eText Asset
	       As a Ws Instructor 
		   I want to lanuch etext 
		   so that I would validate launching of eText is working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I login to Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should be logged in successfully

#Purpose: Lanuch etext by HEDWSInstructor
Scenario: Launch etext by HedWsInstructor
Given I am on the "Global Home" page
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should see "eText" Activity in the MyCourse Frame
When I click on "Open" cmenu option of Activity in "HedWsInstructor"
And I 'Accept Agreement' as 'HedWsInstructor'
Then I should be on the "Pearson eText Sign In Page" page 
And I should see the message "Either you have entered an incorrect username/password, or you do not have a subscription to this site." for etext
When I close etext "Pearson eText Sign In Page" presentation window
And I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."
