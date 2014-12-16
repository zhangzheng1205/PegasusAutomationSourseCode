Feature: CourseSpaceInstructorAssignmentCalendar
	                As a CS Instructor 
					I want to manage all the coursespace instructor assignment calendar related usecases 
					so that I would validate all the coursespace instructor assignment calendar related scenarios are working fine.

#Verify the usecase in InstructorCourse
#Purpose: To check the Course Content order in the assigned date - Assignment calendar
# TestCase Id: HSS_PWF_270_02
Scenario: :To check the Course Content order in the assigned date Assignment calendar by CS Instructor
When I navigate to "Assignment Calendar" tab of the "Calendar" page
Then I should be on the "Calendar" page
When I enter day view for assigned content in calendar
Then I should see the order of assigned contents in calendar same as in course content

#Purpose: To drag and drop a folder in assignment calendar.
#Test case ID : peg-21948.
#MySpanishLabProgram
Scenario: Instructor drag and drop a folder in assignment calendar by Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "Capítulo 01: ¿Quiénes somos? (ORGANIZED BY CONTENT TYPE)" asset
And I should see the current date highlighted in the calendar frame
When I drag and drop the "Capítulo 01: ¿Quiénes somos? (ORGANIZED BY CONTENT TYPE)" folder to the current date
Then I should see due date icon displayed in current date
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : To validate Assign more than one content using Assign/Unassign link
#Test Case Id :peg-21979 -Assign more than one content using Assign/Unassign link
#PEGASUS-28905
#MySpanishLabProgram
Scenario: Assign more than one content using Assign Unassign link by Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "SAM 02-02 ¿Qué clases tienen? [Vocabulario 1. Las materias y las especialidades]" in "Calendar" by "HSSCsSmsInstructor"
And I select the check box of any 2 activities in "STUDENT ACTIVITIES MANUAL"
Then I should see Assign/Unassign link in active state on the content frame header
When I click on assign/Unassign link displayed in content frame header
Then I should see the check mark in assigned status column next to the assets
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : To validate Assign one content using Assign/Unassign link
#PEGASUS-28903
#Test case ID :peg-21971 
#MySpanishLabProgram
Scenario: Assign one content using Assign Unassign link by Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "SAM 03-01 ¿Qué hacemos en casa? [Vocabulario 1. La casa]" in "Calendar" by "HSSCsSmsInstructor"
And I select the check box of any 1 activities in "STUDENT ACTIVITIES MANUAL"
Then I should see Assign/Unassign link in active state on the content frame header
When I click on assign/Unassign link displayed in content frame header
Then I should see the check mark in assigned status column next to the assets
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose: To drag and drop multiple assets in assignment calendar.
#Test case ID : peg-21981.
#PEGASUS-28906
#MySpanishLabProgram
Scenario: Drag and drop the more than one assets to current date in Assignment calendar
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see the current date highlighted in the calendar frame
When I select "SAM 06-01 Descripciones. [Review: Capítulos Preliminar A,  1 y 2]" in "Calendar" by "HSSCsSmsInstructor"
And I select the check box of any 2 activities in "STUDENT ACTIVITIES MANUAL"
And I should drag and drop multiple assets along with "SAM 06-01 Descripciones. [Review: Capítulos Preliminar A,  1 y 2]" to the current date
Then I should see due date icon displayed in current date
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose: To validate the current date assigned content in calendar frame by Coursespace Instructor
#Test Case Id: peg-21985
#PEGASUS-28907
#MySpanishLabProgram
Scenario: To check the current date assigned content in the calendar by Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "Capítulo 01: ¿Quiénes somos? (ORGANIZED BY CONTENT TYPE)" asset
And I should see the current date highlighted in the calendar frame
When I select the current date 
Then I should see the assigned content "Readiness Check 01" in the day view
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose: Assign a content to display start date icon
#PEGASUS-29283
#peg-21987
#MySpanishLabProgram
Scenario: To validate the display of start date icon in calendar frame by Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "SAM 05-01 Artistas famosos. [Vocabulario 1. El mundo de la música]" in "Calendar" by "HSSCsSmsInstructor"
And I select cmenu "Assignment Properties" of activity "SAM 05-01 Artistas famosos. [Vocabulario 1. El mundo de la música]" 
Then I should see the "Assign" popup
When I assign the asset for current date in the properties popup
Then I should be on the "Calendar" page
And I should see the current date highlighted in the calendar frame
And I should see the startdate Icon in calendar frame
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
