Feature: 27616
			As a program admin
			I want to copy template/section for parent PMC set with stop copy option
			so that Program admin will displyed with error message "You cannot copy this course due to publisher restrictions." and course should not copied.
	

# Used ProgramCourse course
#Purpose: Copying Template as Template
Scenario: Copying Templates as Tempalate inside Program when its parent PMC is set with Stop Copy
When I navigate to "Templates" tab of the "Program Administration" page as PAdmin
Then I should be on the "Program Administration" page
When I click the "Copy as Template" option
Then I should be on the "Copy as Template" page
When I click "Copy" button "Copy as Template"
Then I should see successfull message "You cannot copy this course due to publisher restrictions."

# Used ProgramCourse course
#Purpose: Copying Template as Shared Library
Scenario: Copy Template as Shared Library inside Program when its parent PMC is set with Stop Copy
When I navigate to "Templates" tab of the "Program Administration" page as PAdmin
Then I should be on the "Program Administration" page
When I click the "Copy as Shared Library" option
Then I should be on the "Copy as Shared Library" page
When I click "Save" button to "Copy as Shared Library"
Then I should see successfull message "You cannot copy this course due to publisher restrictions."

# Used ProgramCourse course
#Purpose: Copying Section as Section
Scenario: Copy Section as Section inside Program when its parent PMC is set with Stop Copy
When I navigate to "Sections" tab of the "Program Administration" page as PAdmin
Then I should be on the "Program Administration" page
When I click the "Copy as Section" option
Then I should be on the "Copy as Section" page
When I click "Copy" button to copy "Copy as Section"
Then I should see successfull message "You cannot copy this course due to publisher restrictions."

# Used ProgramCourse course
#Purpose: Copying Section as Template
Scenario: Copy Section as Template inside Program when its parent PMC is set with Stop Copy
When I navigate to "Sections" tab of the "Program Administration" page as PAdmin
Then I should be on the "Program Administration" page
When I click the "Copy as Template" option
Then I should be on the "Copy as Template" page
When I click "Copy" button "Copy as Template"
Then I should see successfull message "You cannot copy this course due to publisher restrictions."

