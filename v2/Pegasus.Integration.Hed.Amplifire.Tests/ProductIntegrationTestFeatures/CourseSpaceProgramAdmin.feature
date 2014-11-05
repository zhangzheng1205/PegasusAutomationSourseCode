Feature: CourseSpaceProgramAdmin
	                As a CS Program Admin
					I want to manage all the coursespace instructor related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.

Background: 
#Purpose: Login as HED Program Admin 
Scenario: User Login as CourseSpace Program Admin 
Given I browsed the login url for "HedProgramAdmin"
When I logged into the Pegasus as "HedProgramAdmin" in "CourseSpace"
Then  I should be logged in successfully
Given I am on the "Global Home" page

#Purpose: Login as HED Program Admin and Navigate to  ProgramCourse
#PEGASUS-31805 Automation : HED BVT : peg-22716:Launching Amplifire content link
Scenario: User Login CourseSpace Program Admin and Navigate ProgramCourse Course
When I enter in the "ProgramCourse" course from the Global Home page as "HedProgramAdmin"
Then I should be on the "Program Administration" page
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "ProgramCourse" first section
And I click the "Enter Section as Instructor"


#PEGASUS-31805 Automation : HED BVT : peg-22716:Launching Amplifire content link copied using Add to multiple sections feature
#Purpose: Launch the Amplifire Asset using section course
Scenario: Launch the Amplifire Asset using section course 
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to "Amplifier" asset in "Course Materials" tab as "HedProgramAdmin"
And I open the "Amplifier link 1 (Content)" Activity
Then I should be on the "Pegasus" page
