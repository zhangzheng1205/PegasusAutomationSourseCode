Feature: CourseSpaceInstructor
	                As a CS Instructor 
					I want to manage all the coursespace instructor related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Create Instructor course through catalog by CS instructor
#HED_MIL_PWF_156
Scenario: Add Instructor Course From Catalog by SMS Instructor
When I add Product Course type "MyItLabSIM5MasterCourse" course from Search Catalog
Then I should see "MyItLabInstructorCourse" on the Global Home page
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

Scenario: Validate Instructor Course To Get Out From Assigned To Copy State
When I select course to validate Inactive State to Active State on Global Home page
Then I should see "MyItLabInstructorCourse" on the Global Home page in Active State
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Create Program type course through catalog by CS instructor
@ProgramCreation
Scenario: Add Program Course From Catalog by SMS Instructor
When I add Product type "HedMilProgram" from Search Catalog
Then I should see "MyItLabProgramCourse" on the Global Home page
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Create Template
Scenario: Create Template by Program Admin
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I create Template using "MyItLabSIM5MasterCourse" course as a program admin
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Validate Template to get out from the assigned to copy state
Scenario: Validate Template To Get Out From Assigned To Copy State
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I verify the "MyItLabSIM5MasterCourse" course Template for AssignedToCopy state
Then I should see the "MyItLabSIM5MasterCourse" course Template to be successfully out of AssignedToCopy state
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Create Section
Scenario: Create Section by Program Admin
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
And I click on Add Sections link from the Program Administration page
And I create Section from "MyItLabSIM5MasterCourse" Template as a Program Admin
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Validate Section to get out from the assigned to copy state
Scenario: Validate Section To Get Out From Assigned To Copy State
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
And I verify the Section created from "MyItLabProgramCourse" course Template for AssignedToCopy state
Then I should see the Section created from "MyItLabProgramCourse" course Template to be successfully out of AssignedToCopy state
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

