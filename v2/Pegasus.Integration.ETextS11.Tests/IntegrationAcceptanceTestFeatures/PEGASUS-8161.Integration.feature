#Purpose: Feature Description
Feature: PEGASUS-8161: Add eText Preference
	As an Ws Instructor
	I want to enable eText preference in work space
	so that eText can be launched successfully.

Background:
#Purpose: Open Work Space Instructor Url
Given I browsed the login url for "HedWsInstructor"
When I login to Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should be logged in successfully

#Purpose: Set the eText preference in Work Space
Scenario: Set the eText preference in Work Space
Given I am on the "Global Home" page
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'LTI Tools' sub tab
And I set the 'eText' in enable state
Then I should see the successfull message "Preferences updated successfully."
When I select the 'Course Materials' sub tab
And I enter the eText details
Then I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."