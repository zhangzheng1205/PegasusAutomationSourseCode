Feature: CommonUserLoginLogOut
				As a Pegasus User
				I want to manage all the Pegasus User related usecases 
				so that I would validate all the Pegasus User scenarios are working fine.

#Purpose: Login as HED Program Admin 
Scenario: User Login as CourseSpace Program Admin 
Given I browsed the login url for "HedProgramAdmin"
When I logged into the Pegasus as "HedProgramAdmin" in "CourseSpace"
Then  I should be logged in successfully
Given I am on the "Global Home" page

#Purpose: Login as HED Program Admin and Navigate to  ProgramCourse
#PEGASUS-31805 Automation : HED BVT : peg-22716:Launching Amplifire content link
Scenario: User Login CourseSpace Program Admin and Navigate ProgramCourse Course
Given I browsed the login url for "HedProgramAdmin"
When I logged into the Pegasus as "HedProgramAdmin" in "CourseSpace"
Then  I should be logged in successfully
Given I am on the "Global Home" page
When I enter in the "ProgramCourse" course from the Global Home page as "HedProgramAdmin"
Then I should be on the "Program Administration" page
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "ProgramCourse" first section
And I click the "Enter Section as Instructor"
