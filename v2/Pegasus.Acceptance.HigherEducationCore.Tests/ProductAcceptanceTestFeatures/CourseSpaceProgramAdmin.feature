Feature: CourseSpaceProgramAdmin
	                As a CS Program Admin
					I want to manage all the coursespace instructor related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.

#Purpose: Create Section by Program Admin in WL
#MySpanishLabProgram
Scenario: Create Section by Program Admin in WL
When I navigate to "Sections" tab of the "Program Administration" page as Admin
Then I should be on the "Program Administration" page
When I click on Add Sections link from the Program Administration page
And I create Section from "MySpanishLabMaster" Template as a Program Admin

#Purpose: Validate Section to get out from the assigned to copy state in WL
#MySpanishLabProgram
Scenario: Validate Section To Get Out From Assigned To Copy State in WL
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I verify the Section created from "MySpanishLabProgram" course Template for AssignedToCopy state
Then I should see the Section created from "MySpanishLabProgram" course Template to be successfully out of AssignedToCopy state