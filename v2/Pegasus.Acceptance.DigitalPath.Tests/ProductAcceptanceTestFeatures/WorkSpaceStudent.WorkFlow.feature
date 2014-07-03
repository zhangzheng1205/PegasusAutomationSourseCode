Feature: WorkSpaceStudent
	                 As a WorkSpace Student 
					I want to manage all the work space student related usecases 
					so that I would validate all the workspce student scenarios are working fine.

Background:
#Purpose: Open Ws Url
Given I browsed the login url for "WsStudent"
When I login to Pegasus as "WsStudent" in "WorkSpace"
Then I should be logged in successfully

#Purpose: View Default Home Tabs by WS Student
Scenario: View Default Tabs by WS Student
Given I am on the "Global Home" page 
When I enter in the "MasterLibrary" as "WsStudent" from the Global Home page
Then I should see the defaults tabs for "WsStudent"
When I "Sign out" from the "WsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Launch activity by WS Student
Scenario: Launch MGM Test Activity by WS Student
Given I am on the "Global Home" page
When I enter in the "MasterLibrary" as "WsStudent" from the Global Home page
And I navigate to the "Content" tab
Then I should be on the "Content" page
When I open the "Test" Activity
Then I should see the Test activity successfully launched
When I "Sign out" from the "WsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Launch SSP by WS Student
Scenario: Launch Skill Study Plan Activity by WS Student
Given I am on the "Global Home" page
When I enter in the "MasterLibrary" as "WsStudent" from the Global Home page
And I navigate to the "Content" tab
Then I should be on the "Content" page
When I open the "SkillStudyPlan" Activity
And I launch the Pretest
Then I should see the SSP Pretest successfully launch by "WsStudent"
When I "Sign out" from the "WsStudent"
Then I should see the successfull message "You have been signed out of the application."


