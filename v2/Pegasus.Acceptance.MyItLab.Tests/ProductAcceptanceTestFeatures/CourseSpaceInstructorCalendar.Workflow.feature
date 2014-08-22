Feature: CourseSpaceInstructorCalendar
	                As a CS Instructor 
					I want to manage all the coursespace instructor calendar related usecases 
					so that I would validate all the coursespace instructor calendar related scenarios are working fine.

#Purpose : Day view in the Expanded calendar
#Test Case Id :HED_MIL_PWF_227
#MyItLabInstructorCourse
Scenario: Day view in the Expanded calendar
When I navigate to "Course Materials" tab and selected "Assignment Calendar" subtab
Then I should be on the "Calendar" page
When I select the current date 
And I select 'View Advanced calendar' option in calendar 
Then I should see the "Assign Course Materials" option with "DayWeekMonth" and "Add Note" button
And I should see the message of calendar "0 Items Due Today" and "No Items are Due Today"

#Purpose : Drag and drop a single content to a day and display of Assigned content in Day View
#Test Case Id :HED_MIL_PWF_280
#MyItLabProgramCourse
Scenario: Drag and drop a single content to a day and display of Assigned content in Day View
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "MyItLabProgramCourse" first section
And I click the "Enter Section as Instructor"
And I navigate to "Course Materials" tab and selected "Assignment Calendar" subtab
Then I should be on the "Calendar" page
When I search the "SIM5Activity" activity of behavioral mode "SkillBased"
Then I should see the searched "SIM5Activity" activity of behavioral mode "SkillBased"
When I 'Drag and Drop' the "SIM5Activity" activity of behavioral mode "SkillBased" on current day
Then I should see the "SIM5Activity" activity of behavioral mode "SkillBased" assigned by 'Drag and Drop' in day view
And I should see the message "1 Item Due Today" in day view
When I select 'Home' option
Then I should be on the "Program Administration" page


#Purpose : Drag and drop a single content to a day and display of Assigned content in Month View
#Test Case Id :HED_MIL_PWF_280
#MyItLabProgramCourse
Scenario: Drag and drop a single content to a day and display of Assigned content in Month View
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "MyItLabProgramCourse" first section
And I click the "Enter Section as Instructor"
And I navigate to "Course Materials" tab and selected "Assignment Calendar" subtab
Then I should be on the "Calendar" page
When I click on the calendar icon
Then I should see the "SIM5Activity" activity of behavioral mode "SkillBased" assigned by 'Drag and Drop' in day view
When I select 'Home' option
Then I should be on the "Program Administration" page

#Purpose : Status of the assigned Content in the Status Column
#Test Case Id :HED_MIL_PWF_282
#MyItLabProgramCourse
Scenario: To check the Status of the assigned Content in the Status Column By SMS Instructor
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "MyItLabProgramCourse" first section
And I click the "Enter Section as Instructor"
And I navigate to "Course Materials" tab and selected "Assignment Calendar" subtab
Then I should be on the "Calendar" page
When I search the "SIM5Activity" activity of behavioral mode "SkillBased"
Then I should see the searched "SIM5Activity" activity of behavioral mode "SkillBased"
And I should see the Status of the assigned content in status column
When I select 'Home' option
Then I should be on the "Program Administration" page

#PEGASUS-28905
#Purpose : To validate Assign more than one content using Assign/Unassign link
#Test Case Id :peg-21979 -Assign more than one content using Assign/Unassign link
Scenario: Assign more than one content using Assign Unassign link by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I expands the Asset Path on Calendar page
Then I should see expanded Folder with activities
When I select the check box of any 2 activities
Then I should see Assign/Unassign link in active state on the content frame header
When I click on assign/Unassign link displayed in content frame header
Then I should see the check mark in assigned status column next to the assets