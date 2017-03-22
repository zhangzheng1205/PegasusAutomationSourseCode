Feature: CourseSpaceInstructorCalendar
	                As a CS Instructor 
					I want to manage all the coursespace instructor calendar related usecases 
					so that I would validate all the coursespace instructor calendar related scenarios are working fine.

#Purpose : Day view in the Expanded calendar
#Test Case Id :HED_MIL_PWF_227
#MyItLabInstructorCourse
Scenario: Day view in the Expanded calendar
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
And I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select the current date 
And I select 'View Advanced calendar' option in calendar 
#Then I should see the "Assign Course Materials" option with "DayWeekMonth" and "Add Note" button
Then I should see the message of calendar "0 Items Due Today" and "No Items are Due Today"


Scenario: Validate the assignment count in month view of advance calendar 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
And I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I click on "Advanced Calendar" option in calender frame of "Calendar" page
#Then I should be displayed with "Assignments" option in "Advanced Calendar" of "Calendar" page
#When I click on "Month" view in Advance calender
#Then I should be displayed with assigned item count "1" in "Future date"
#When I click on "Future date" in advanced calender view
#Then I should see the "RegFutureDateAssignment " activity assigned in day view of Advance calender
When I move to "Next" month in "Month" view
Then I should be on "Next" month  in "Month" view




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

#Purpose : Drag and drop a single content to a day and display of Assigned content in Day View
#MyItLabProgramCourse
Scenario: Drag and drop a Link asset content to a day and display of Assigned content in Day View as SMS Teacher
When I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "RegLinkAsset" activity
Then I should see the searched "RegLinkAsset" activity in content frame
When I 'Drag and Drop' the "RegLinkAsset" activity on "Current date"
Then I should see the "RegLinkAsset" activity assigned by 'Drag and Drop' in day view of "Current date"
 #______________________________________________________________________________________________________________

#Purpose : Drag and drop a single content to current date and display of Assigned content in Day View
#MyItLabProgramCourse
#Test Case Id :
Scenario: Drag and drop a single content to a day and validate the Assigned content in Day View as SMS Instructor
When I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "RegTodayDateAssignment " activity of behavioral mode "SkillBased"
Then I should see the searched "RegTodayDateAssignment " activity of behavioral mode "SkillBased"
When I 'Drag and Drop' the "RegTodayDateAssignment " activity of behavioral mode "SkillBased" on "Current date"
Then I should see the "RegTodayDateAssignment " activity of behavioral mode "SkillBased" assigned by 'Drag and Drop' in day view of "Current date"
When I click on "Advanced Calendar" option in calender frame of "Calendar" page
Then I should be displayed with "Assignments" option in "Advanced Calendar" of "Calendar" page
And I should be displayed with "Calendar Widget" option in "Advanced Calendar" of "Calendar" page
And I should be displayed with "Calendar Viewby" option in "Advanced Calendar" of "Calendar" page
And I should be displayed with "Month view" option in "Advanced Calendar" of "Calendar" page
When I click on "Day" view in Advance calender
Then I should see the "RegTodayDateAssignment " activity assigned in day view of Advance calender


#---------------------------------------------------------------------------------------------------------------------------------------------------
									# Drag drop asset for current , Future and Past date #
#---------------------------------------------------------------------------------------------------------------------------------------------------
#Purpose : Drag and drop a single content to Curremt date and display of Assigned content in Day View
#MyItLabProgramCourse
#Test Case Id :
Scenario: Drag and drop a single content to Current date and validate the display of assigned content in Day view
When I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "SIM5StudyPlan " activity
Then I should see the searched "SIM5StudyPlan" activity 
When I 'Drag and Drop' the "SIM5StudyPlan " activity on "Current date"
Then I should see "SIM5StudyPlan" activity assigned by 'Drag and Drop' in "Current date" day view 


#Purpose : Drag and drop a single content to future date and display of Assigned content in Day View
#MyItLabProgramCourse
#Test Case Id :
Scenario: Drag and drop a single content to future date and display of Assigned content in Day View as SMS Teacher
When I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "RegFutureDateAssignment " activity of behavioral mode "SkillBased"
Then I should see the searched "RegFutureDateAssignment " activity of behavioral mode "SkillBased"
When I 'Drag and Drop' the "RegFutureDateAssignment " activity of behavioral mode "SkillBased" on "Future date"
Then I should see "RegFutureDateAssignment" activity of behavioral mode "SkillBased" assigned by 'Drag and Drop' in "Future date" day view 

#Purpose : Drag and drop a single content to previous date and display of Assigned content in Day View
#MyItLabProgramCourse
#Test Case Id :
Scenario: Drag and drop a single content to previous date and display of Assigned content in Day View as SMS Teacher
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
And I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "RegPastDueAssignment " activity of behavioral mode "SkillBased"
Then I should see the searched "RegPastDueAssignment " activity of behavioral mode "SkillBased"
When I 'Drag and Drop' the "RegPastDueAssignment " activity of behavioral mode "SkillBased" on "Future date"
Then I should see "RegFutureDateAssignment" activity of behavioral mode "SkillBased" assigned by 'Drag and Drop' in "Future date" day view 

#Purpose : Add Notes functionality for future date in Calendar frame
#MyItLabProgramCourse
#Test Case Id :
Scenario: Add Notes functionality for future date in Calendar frame
When I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I click on "Future date" in normal calender view
When I click on "Add Notes" icon in "Future date" date
Then I should be displayed with "Add Note" wizard
When I "Create" notes and click on 'Save and Close' button
Then I should be displayed with the notes in the day view
#When I click on "Back to Month"
Then I should be displayed with 'Due date' icon and 'Notes' icon in "Future date"

#Purpose : Edit Notes functionality for future date in Calendar frame
#MyItLabProgramCourse
#Test Case Id :
Scenario: Edit Notes functionality for future date in Calendar frame
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
And I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I click on "Future date" in normal calender view
And I click on "Edit" icon in "Future date" date
Then I should be displayed with "Add Note" wizard
When I "Edit" notes and click on 'Save and Close' button
Then I should see the successfull message "Note updated successfully." in "Calendar" window
When I click on "Delete" icon in "Future date" date
And I click Ok button in confirmation lightbox

#Purpose : Cmenu Assign with due date for CurrentDate 
#MyItLabProgramCourse
#Test Case Id :
Scenario: Cmenu Assign with CurrentDate as due date
When I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "RegSimpleCmenuAssignCurrentDate" activity of behavioral mode "SkillBased"
Then I should see the searched "RegSimpleCmenuAssignCurrentDate" activity of behavioral mode "SkillBased"
When I "Assign with due date" for "Current Date" of activity "RegSimpleCmenuAssignCurrentDate"
Then I should see the "RegSimpleCmenuAssignFutureDate" activity of behavioral mode "SkillBased" assigned by 'CMenu' in "Current date" of day view 
Then I should be on the "Calendar" page

#Purpose : Cmenu Simple Assign with due date for CurrentDate 
#MyItLabProgramCourse
#Test Case Id :
Scenario: Cmenu SimpleAssign with due date for CurrentDate 
When I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "RegSimpleCmenuAssign" activity of behavioral mode "SkillBased"
Then I should see the searched "RegSimpleCmenuAssign" activity of behavioral mode "SkillBased"
When I "Simple assign" for "Current Date" of activity "RegSimpleAssign"
Then I should see the "RegSimpleCmenuAssignFutureDate" activity of behavioral mode "SkillBased" assigned by 'CMenu' in "Current date" of day view 
And I should be on the "Calendar" page

#Purpose : Cmenu assign of single content to past due date
#MyItLabProgramCourse
#Test Case Id :
Scenario: Cmenu assign from Assignment Calendar to pastdue date
When I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "RegPastDueCmenuAssignment" activity of behavioral mode "SkillBased"
Then I should see the searched "RegPastDueCmenuAssignment" activity of behavioral mode "SkillBased"
When I click cmenu "Set Scheduling Options" of activity "RegPastDueCmenuAssignment"
Then I should see the "Assign" popup
When I assign the searched activity to past due date
Then I should see the "RegSimpleCmenuAssignFutureDate" activity of behavioral mode "SkillBased" assigned by 'CMenu' in "PastDue date" of day view 
Then I should be on the "Calendar" page
And I should see the pastdue icon

#Purpose : Cmenu assign of single content to past due date
#MyItLabProgramCourse
#Test Case Id :
Scenario: Cmenu Assign with FutureDate as due date
When I navigate to "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "RegSimpleCmenuAssignFutureDate" activity of behavioral mode "SkillBased"
Then I should see the searched "RegSimpleCmenuAssignFutureDate" activity of behavioral mode "SkillBased"
When I "Assign with due date" for "Future Date" of activity "RegSimpleCmenuAssignFutureDate"
Then I should see the "RegSimpleCmenuAssignFutureDate" activity of behavioral mode "SkillBased" assigned by 'CMenu' in "Future date" of day view 
Then I should be on the "Calendar" page

#Purpose : As Instructor for HED Product,I need to validate the display of start date icon in calendar frame
#Test Case Id :peg-21987
Scenario: To validate the display of start date icon in calendar frame by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I search the "RegSimpleStartDateCmenuAssign" activity of behavioral mode "SkillBased"
Then I should see the searched "RegSimpleStartDateCmenuAssign" activity of behavioral mode "SkillBased"
When I click cmenu "Set Scheduling Options" of activity "RegSimpleStartDateCmenuAssign" 
Then I should see the "Properties" popup
When I assign the asset for current date in the properties popup
Then I should be on the "Calendar" page
And I should see the startdate Icon in calendar frame
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page

#Purpose : Status of the assigned Content in the Status Column
#Test Case Id :HED_MIL_PWF_282
#MyItLabProgramCourse
Scenario: To check the Status of the assigned Content in the Status Column By SMS Instructor
When I navigate to the "Assignment Calendar" tab
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
And I should see the current date highlighted in the calendar frame
When I select the current date 
Then I should see the assigned content "RegSimpleCmenuAssignCurrentDate" in the day view
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page