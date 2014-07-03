Feature: WorkSpaceInstructorContentLibrary
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "GraderITSIM5Course" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page

#Purpose: To check the Creation of Grader IT Activity with 2007 SIM Questions
Scenario: Creation of Grader IT Activity with 2007 SIM Questions by WS Teacher
When I select 'Add Course Materials' in 'My Course'
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "SIMGraderActivity" of grader activity of behavioral mode "Assignment" type
Then I should see the successfull message "Activity added successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Instructor Previews the Grader IT Activity
Scenario: Instructor Previews the Grader IT Activity
When I search "SIMGraderActivity" activity of behavioral mode "Assignment" type
And I select the Cmenu option "Preview"
Then I should be on the "Test Presentation" page
When I close the "Test Presentation" window
And I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."