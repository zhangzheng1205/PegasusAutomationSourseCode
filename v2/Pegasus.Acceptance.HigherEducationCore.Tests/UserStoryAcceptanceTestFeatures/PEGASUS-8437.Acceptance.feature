#Purpose: Feature Description
Feature: PEGASUS-8437 - Add new badging preference to master course
	                    As a Master Course Author
	                    I want to enable the checkbox 'Enable Badge'
						So that I can validate other fields and save the preference option
						
#Purpose: Open the HEDWSInstructor Url
Background: 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully

#Purpose: Enable Badge Preference option and validate for Single Activity
Scenario: Enable Badge Preference Option for Single Activity for HedWsInstructor 
Given I am on the "Global Home" page
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I click on the "Home" tab
Then I should see the "Course Listing Options" in the page
When I select the Enable Badge checkbox
Then I should see the Select Content button enabled
When I enter the TemplateID and Badge Threshold textbox fields
And I click on Select Content button
Then I should be on the "Badge Assignment Selection" page
When I select the checkbox of activity "Test1"
And I should click on Add and Close button
Then I should see the 'Test1' in the select content textbox field       
When I save the Preferences
Then I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Enable Badge Preference option and validate for Single Activity
Scenario:  Enable Badge Preference Option for Multiple Activity for HedWsInstructor
Given I am on the "Global Home" page
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I click on the "Home" tab
Then I should see the "Course Listing Options" in the page
When I click on Select Content button
Then I should be on the "Badge Assignment Selection" page
When I select the checkbox of activities "Test Sco" and "Test_mac1"
And I should click on Add and Close button
Then I should see the 'Multiple Selected (2)' in the select content textbox field
When I save the Preferences
Then I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

