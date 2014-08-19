Feature: CourseSpaceInstructor
	                As a CS Program Admin
					I want to manage all the coursespace instructor related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.

#Purpose: Create Instructor course through catalog by CS instructor
Scenario: Add Instructor Course From Catalog by SMS Instructor
When I add Product Course type "MyItLabSIM5MasterCourse" course from Search Catalog
Then I should see "MyItLabInstructorCourse" course on the Global Home page

#Global HomePage Scenario
Scenario: Validate Instructor Course To Get Out From Assigned To Copy State
When I select course to validate Inactive State to Active State on Global Home page
Then I should see "MyItLabInstructorCourse" on the Global Home page in Active State

#Purpose: Create Program type course through catalog by CS instructor
Scenario: Add Program Course From Catalog by SMS Instructor
When I add product type "MyITLabForOffice2013Program" from search catalog
Then I should see "MyITLabOffice2013Program" course on the Global Home page

#Purpose: To Create Template
Scenario: Create Template by Program Admin
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I navigate to "Templates" tab of the "Program Administration" page
And I create Template using "MyITLabForOffice2013Master" course as a program admin

#Purpose: Validate Template to get out from the assigned to copy state
#MyItLabProgramCourse
Scenario: Validate Template To Get Out From Assigned To Copy State
When I navigate to "Templates" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I verify the "MyITLabForOffice2013Master" course Template for AssignedToCopy state
Then I should see the "MyITLabForOffice2013Master" course Template to be successfully out of AssignedToCopy state

#MyItLabProgramCourse
Scenario: Create Section by Program Admin
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I click on Add Sections link from the Program Administration page
And I create Section from "MyITLabForOffice2013Master" Template as a Program Admin

#Purpose: Validate Section to get out from the assigned to copy state
#MyItLabProgramCourse
Scenario: Validate Section To Get Out From Assigned To Copy State
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I verify the Section created from "MyITLabOffice2013Program" course Template for AssignedToCopy state
Then I should see the Section created from "MyITLabOffice2013Program" course Template to be successfully out of AssignedToCopy state

#Purpose: Filter Section using ParentTemplate DropDown
#MyItLabProgramCourse
Scenario: Filter Section by Program Admin
When I filter the template "MyITLabForOffice2013Master" using 'Parent Template' dropdown
Then I should see the new section created usign "MyITLabOffice2013Program" in the section list

#Purpose: Copying Section as Section and validate copied section to get out from the assigned to copy state
Scenario: Copying Section As Section
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the section of "MyITLabOffice2013Program"
And I click the "Copy as Section" c-menu option
Then I should be on the "Copy as Section" page
When I click Copy/Save button to copy
Then I should see the successfull message "Section Copied Successfully."
When I verify the Section copied from "MyITLabOffice2013Program" section for AssignedToCopy state
Then I should see the Section copied from "MyITLabOffice2013Program" section to be successfully out of AssignedToCopy state