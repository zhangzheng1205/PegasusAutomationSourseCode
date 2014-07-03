Feature: CourseSpaceAssignsContent
	                 As a CS Teacher 
					I want to manage all the coursespace assign content usecases 
					so that I would validate all the assign content scenarios are working fine.

Background: 
#Purpose: Open Url
Given I browsed the login url for "DPCsTeacher"
When I login to Pegasus as "DPCsTeacher" in "CourseSpace"
Then I should be logged in successfully

#Purpose - Set up calendar and assign the activity
Scenario: Calendar SetUp by CsTeacher
Given I am on the "Home" page
When I navigate to the "Planner" tab
And I click on the Calendar set up button
Then I should see the calendar configured successfully
When I set the due date for the "Test" activity in calendar
And I set the due date for the "StudyPlan" activity in calendar


