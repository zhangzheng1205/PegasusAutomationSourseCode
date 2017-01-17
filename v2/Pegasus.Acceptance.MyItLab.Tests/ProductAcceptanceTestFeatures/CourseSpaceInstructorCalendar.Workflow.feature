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
#MyItLabProgramCourse
Scenario: Drag and drop a single content to a day and display of Assigned content in Day View as SMS Teacher
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
And I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
#When I search the "RegTodayDateAssignment " activity of behavioral mode "SkillBased"
#Then I should see the searched "RegTodayDateAssignment " activity of behavioral mode "SkillBased"
#When I 'Drag and Drop' the "RegTodayDateAssignment " activity of behavioral mode "SkillBased" on "Current date"
#Then I should see the "RegTodayDateAssignment " activity of behavioral mode "SkillBased" assigned by 'Drag and Drop' in day view of "Current date"
#When I click on "Advanced Calendar" option in calender frame of "Calendar" page
#Then I should be displayed with "Assignments" option in "Advanced Calendar" of "Calendar" page
#And I should be displayed with "Calendar Widget" option in "Advanced Calendar" of "Calendar" page
#And I should be displayed with "Calendar Viewby" option in "Advanced Calendar" of "Calendar" page
#And I should be displayed with "Month view" option in "Advanced Calendar" of "Calendar" page
#When I click on "Day" view in Advance calender
#Then I should see the "RegTodayDateAssignment " activity assigned in "Day" view of "Current date" in Advance calender
#When I click on "Assignments" option in calender frame of "Calendar" page
#When I search the "RegFutureDateAssignment " activity of behavioral mode "SkillBased"
#Then I should see the searched "RegFutureDateAssignment " activity of behavioral mode "SkillBased"
#When I 'Drag and Drop' the "RegFutureDateAssignment " activity of behavioral mode "SkillBased" on "Future date"
#Then I should see the "RegFutureDateAssignment " activity of behavioral mode "SkillBased" assigned by 'Drag and Drop' in day view of "Future date"
#When I click on "Future date" in normal calender view
#When I click on "Add Notes" icon in "Future date" date
#Then I should be displayed with "Add Note" wizard
#When I "Create" notes and click on 'Save and Close' button
#Then I should be displayed with the notes in the day view
#When I click on "Back to Month"
Then I should be displayed with 'Due date' icon and 'Notes' icon in "Future date"
#Scenario: Edit notes in day view of calendar
When I click on "Future date" in normal calender view
#And I click on "Edit" icon in "Future date" date
#Then I should be displayed with "Add Note" wizard
#When I "Edit" notes and click on 'Save and Close' button
#Then I should see the successfull message "Note updated successfully." in "Calendar" window
When I click on "Delete" icon in "Future date" date
And I click Ok button in confirmation lightbox
#When I select 'Home' option
#Then I should be on the "Program Administration" page

Scenario: Cmenu assign from Assignment Calendar pastdue
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
And I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "RegPastDueAssignment  " activity of behavioral mode "SkillBased"
Then I should see the searched "RegPastDueAssignment  " activity of behavioral mode "SkillBased"
When I click cmenu "Assignment Properties" of activity "RegPastDueAssignment"
Then I should see the "Assign" popup

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

#Purpose: To validate the current date assigned content in calendar frame by Coursespace Instructor
#Test Case Id: peg-21985
Scenario: To check the current date assigned content in the calendar by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "GO! with Microsoft Office 2013, Volume 1" asset
And I should see the current date highlighted in the calendar frame
When I select the current date 
Then I should see the assigned content "Excel Chapter 1 Skill-Based Training" in the day view
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page

#Purpose: To change the assigned content from due date to currentdate
#Test Case Id: peg-21978
#MyITLabOffice2013Program
Scenario: Assign the content with due date to current date by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in "Calendar" by "CsSmsInstructor"
And I select cmenu "Assignment Properties" of activity "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" 
Then I should see the "Assign" popup
When I assign the asset for current date in the properties popup
Then I should see the duedate icon along with the checkmark in the calendar beside activity "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" under "Excel Chapter 1: Simulation Activities"

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


#PEGASUS-21987
#Purpose : As Instructor for HED Product,I need to validate the display of start date icon in calendar frame
#Test Case Id :peg-21987
Scenario: To validate the display of start date icon in calendar frame by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in "Calendar" by "CsSmsInstructor"
And I select cmenu "Assignment Properties" of activity "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" 
Then I should see the "Assign" popup
When I assign the asset for current date in the properties popup
Then I should be on the "Calendar" page
And I should see the startdate Icon in calendar frame
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page

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








