Feature: PEGASUS-8162: Add eText Asset Link
					As a Ws Instructor 
					I want to manage all the workspace Instructor related usecases 
					so that I would validate all the workspace Instructor scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I login to Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should be logged in successfully

#Purpose: To Add eTextLink in course material tab
Scenario: Add the etext link asset by WsInstructor
Given I am on the "Global Home" page
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add eText Link" activity type
And I create "eText" activity 
Then I should see the successfull message "eText link updated successfully."
And I should see "eText" Activity in the MyCourse Frame
When I click on 'ShowHide' option of Activity
And I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."
