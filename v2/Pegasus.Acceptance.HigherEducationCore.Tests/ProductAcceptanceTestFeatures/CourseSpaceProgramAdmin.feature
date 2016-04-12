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


#Purpose:To Enroll  instructor and student user to a section at Enrollments Tab 
#Product:WL
#Author: Rashmi
#Pre-requisites: Users should be available for enrollment
Scenario:Enroll  instructor and student user to a section at Enrollments Tab 
When I navigate to "Enrollments" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the section of "MySpanishLabProgram" at Enrollments Tab
And I select "scoring 0" and "WLCsSmsStudent"student user for enrollment
And I select "scoring 100" and "WLCsSmsStudent"student user for enrollment
And I select "WLCsSmsInstructor" teacher user for enrollment