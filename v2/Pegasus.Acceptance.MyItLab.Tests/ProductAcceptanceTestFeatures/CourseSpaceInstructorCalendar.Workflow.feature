Feature: CourseSpaceInstructorCalendar
	                As a CS Instructor 
					I want to manage all the coursespace instructor calendar related usecases 
					so that I would validate all the coursespace instructor calendar related scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page


#Purpose : Day view in the Expanded calendar
#Test Case Id :HED_MIL_PWF_227
Scenario: Day view in the Expanded calendar
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select the current date 
And I select 'View Advanced calendar' option in calendar 
Then I should see the "Assign Course Materials" option with "DayWeekMonth" and "Add Note" button
And I should see the message of calendar "0 Items Due Today" and "No Items are Due Today"
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Drag and drop a single content to a day and display of Assigned content in Day View
#Test Case Id :HED_MIL_PWF_280
Scenario: Drag and drop a single content to a day and display of Assigned content in Day View
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Program Administration" page
When I select the "Sections" tab
And I click the "Enter Section as Instructor" option
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "SIM5Activity" activity of behavioral mode "SkillBased"
Then I should see the searched "SIM5Activity" activity of behavioral mode "SkillBased"
When I 'Drag and Drop' the "SIM5Activity" activity of behavioral mode "SkillBased" on current day
Then I should see the "SIM5Activity" activity of behavioral mode "SkillBased" assigned by 'Drag and Drop' in day view
And I should see the message "1 Item Due Today" in day view
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."


#Purpose : Drag and drop a single content to a day and display of Assigned content in Month View
#Test Case Id :HED_MIL_PWF_280
Scenario: Drag and drop a single content to a day and display of Assigned content in Month View
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Program Administration" page
When I select the "Sections" tab
And I click the "Enter Section as Instructor" option
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I click on the calendar icon
Then I should see the "SIM5Activity" activity of behavioral mode "SkillBased" assigned by 'Drag and Drop' in day view
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."


#Purpose : Status of the assigned Content in the Status Column
#Test Case Id :HED_MIL_PWF_282
Scenario: To check the Status of the assigned Content in the Status Column By SMS Instructor
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Program Administration" page
When I select the "Sections" tab
And I click the "Enter Section as Instructor" option
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "SIM5Activity" activity of behavioral mode "SkillBased"
Then I should see the searched "SIM5Activity" activity of behavioral mode "SkillBased"
And I should see the Status of the assigned content in status column
When I select the cmenu option 'Set Scheduling Options' of the content
Then I should see the due date to which content is assigned in 'Assign' frame
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."