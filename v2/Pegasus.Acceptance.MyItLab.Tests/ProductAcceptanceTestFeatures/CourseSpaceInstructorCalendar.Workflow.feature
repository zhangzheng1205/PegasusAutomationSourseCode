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
When I select "PowerPoint Chapter 1 Skill-Based Training" in "Calendar" by "CsSmsInstructor"
And I select the check box of any 2 activities in "PowerPoint Chapter 1: Simulation Activities"
Then I should see Assign/Unassign link in active state on the content frame header
When I click on assign/Unassign link displayed in content frame header
Then I should see the check mark in assigned status column next to the assets

#Purpose: To validate the current date assigned content in calendar frame by Coursespace Instructor
#Test Case Id: peg-21985
Scenario: To check the current date assigned content in the calendar by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "GO! with Microsoft Office 2013, Volume 1" asset
And I should see the current date highlighted in the calendar frame
When I select the current date 
Then I should see the assigned content "Excel Chapter 1 Skill-Based Training" in the day view

#PEGASUS-21987
#Purpose : As Instructor for HED Product,I need to validate the display of start date icon in calendar frame
#Test Case Id :peg-21987
Scenario: To validate the display of start date icon in calendar frame by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "GO! with Microsoft Office 2013, Volume 1" asset
And I should see the current date highlighted in the calendar frame
And I should see the startdate Icon in calendar frame

#Purpose: To change the assigned content from due date to currentdate
#Test Case Id: peg-21978
#MyITLabOffice2013Program
Scenario: Assign the content with due date to current date by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in "Calendar" by "CsSmsInstructor"
And I select cmenu "Set Scheduling option" of activity "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" 
Then I should see the "Properties" popup
When I assign the asset for current date in the properties popup
Then I should see the duedate icon along with the checkmark in the calendar


#PEGASUS-21971
#Purpose : To validate Assign one content using Assign/Unassign link
#Test Case Id :peg-21971 -Assign one content using Assign/Unassign link
Scenario: Assign one content using Assign Unassign link by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "Access Chapter 1 Skill-Based Training" in "Calendar" by "CsSmsInstructor"
And I select the check box of any 1 activities in "Access Chapter 1: Simulation Activities"
Then I should see Assign/Unassign link in active state on the content frame header
When I click on assign/Unassign link displayed in content frame header
Then I should see the check mark in assigned status column next to the assets


