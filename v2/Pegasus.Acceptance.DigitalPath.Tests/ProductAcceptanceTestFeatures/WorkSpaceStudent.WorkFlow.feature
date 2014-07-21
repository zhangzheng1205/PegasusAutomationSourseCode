Feature: WorkSpaceStudent
	                 As a WorkSpace Student 
					I want to manage all the work space student related usecases 
					so that I would validate all the workspce student scenarios are working fine.

#This Usecase related to "MasterLibrary" course
#Purpose: View Default Home Tabs by WS Student
Scenario: View Default Tabs by WS Student
Then I should see the defaults tabs for "WsStudent"

#This Usecase related to "MasterLibrary" course
#Purpose:Launch activity by WS Student
Scenario: Launch MGM Test Activity by WS Student
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I open the "Test" Activity
Then I should see the Test activity successfully launched

#This Usecase related to "MasterLibrary" course
#Purpose:Launch SSP by WS Student
Scenario: Launch Skill Study Plan Activity by WS Student
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I open the "SkillStudyPlan" Activity
And I launch the Pretest
Then I should see the SSP Pretest successfully launch by "WsStudent"


