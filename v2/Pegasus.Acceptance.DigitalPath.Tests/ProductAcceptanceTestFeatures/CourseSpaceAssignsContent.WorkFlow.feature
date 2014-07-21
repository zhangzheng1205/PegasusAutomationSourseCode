Feature: CourseSpaceAssignsContent
	                 As a CS Teacher 
					I want to manage all the coursespace assign content usecases 
					so that I would validate all the assign content scenarios are working fine.


#This Usecase will not navigate inside the course
#Purpose - Set up calendar and assign the activity
Scenario: Calendar SetUp by CsTeacher
When I navigate to the "Planner" tab
Then I should be on the "Planner" page
When I click on the Calendar set up button
Then I should see the calendar configured successfully
When I set the due date for the "Test" activity in calendar
And I set the due date for the "StudyPlan" activity in calendar

#Purpose: Teacher Enters Curriculum and Performs Actions on Contents 
Scenario: Teacher Enters Curriculum and Performs Actions on Contents
When I navigate to the "Curriculum" tab
And I select "Preview" cmenu option of "Test" in table of contents 
Then I should see the "Start" button in 'Test' page
And I close the "Test" window
When I select "Assign" cmenu option of "Test" in table of contents 
And I set the due date for the "Test" activity in curriculum
When I select "Print" cmenu option of "Test" in table of contents 
Then I should see the "Download" option in print window
And I close the "Print tool" window




