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

#Test case id: peg-17031
#Purpose: Teacher assigns Lesson from curriculum tab
Scenario: Teacher performs simple assign in Curriculum tab for Lesson type activity
When I navigate to the "Curriculum" tab
And I expand the folder "Expressions and Equations" in Curriculum tab
And I expand the sub folder "Variables and Expressions" in Curriculum tab
And I select cmenu option "Assign" of "Lesson 1-1: Numerical Expressions" activity in Curriculum tab
Then I should see "Assign" pop up
When I select the class "Class digits 6"
And I select the current date and due date
And I click on Save and Assign button
And I click on Ok button in Assign pop up
Then I should see Assign pop up closed

#Test case id: peg-22528
#Purpose: Teacher assigns LCC from planner tab
Scenario: Teacher performs simple assign in Planner tab for LCC
When I navigate to the "Planner" tab
And I expand the folder "Expressions and Equations" in Planner tab
And I expand the sub folder "Variables and Expressions" in Planner tab
And I expand the leaf folder "1-1 Homework" in Planner tab
And I select cmenu option "Assign" of "1-1 Homework" activity in Planner tab
And I click on Ok button in Alert pop up
Then I should see "Assign" pop up
When I select the class "Class digits 6"
And I select the current date and due date
And I click on Save and Assign button
And I click on Ok button in Assign pop up
Then I should see Assign pop up closed
And I should see the assigned content "1-1 Homework" in Calendar frame