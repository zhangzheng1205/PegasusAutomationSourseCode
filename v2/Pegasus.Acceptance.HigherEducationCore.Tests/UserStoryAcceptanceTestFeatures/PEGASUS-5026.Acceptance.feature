#Purpose : Feature Description
Feature: PEGASUS-5026 - Include Unread Comments channel in Customize Notification
	                    As a Master Course Author
	                    I want to enable the checkbox 'Notify me when students have unread instructor comments' in Customize Notification popup
						So that I can validate Unread Comments channel option present in Today's view page


#Purpose: Open the HEDWSInstructor Url
Background: 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully

#Purpose: Remove Unread Comments channel in Customize Notification 
Scenario: Remove Unread Comments channel in Today's view page for HedWsInstructor 
Given I am on the "Global Home" page
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I click on the CUSTOMIZE button 
Then I should be on "Customize Notifications" popup Window
When I select the "About This Course" channel as default in Default View drop down
And I uncheck the 'Notify me when student have unread instructor comments' checkbox option
When I click on Save and Close button
Then I should not see "Unread Comments" Channel in Today's view page
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."


#Purpose: Include Unread Comments channel in Customize Notification 
Scenario: Include Unread Comments channel in Today's view page for HedWsInstructor 
Given I am on the "Global Home" page
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I click on the CUSTOMIZE button 
Then I should be on "Customize Notifications" popup Window
When I select the "Unread Comments" channel as default in Default View drop down
And I check the 'Notify me when student have unread instructor comments' checkbox option
When I click on Save and Close button
Then I should see "Unread Comments" Channel in Today's view page
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."



