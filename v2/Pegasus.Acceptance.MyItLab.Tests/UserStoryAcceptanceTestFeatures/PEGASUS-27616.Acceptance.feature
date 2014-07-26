Feature: PEGASUS-27616:Automation: (Admin Modules) Copying Templates/ Sections inside Program when its parent PMC is set with Stop Copy.
			As a program admin
			I want to copy template/section for parent PMC set with stop copy option
			so that Program admin will displyed with error message "You cannot copy this course due to publisher restrictions." and course should not copied.


#Purpose: Copying Template as Template
Scenario: Copying Templates as Tempalate inside Program when its parent PMC is set with Stop Copy
When I search the Template of "MyITLabForOffice2013Master"
And  I click the "Copy as Template" c-menu option
Then I should be on the "Copy as Template" page
When I click Copy/Save button
Then I should see the successfull message "You cannot copy this course due to publisher restrictions."

#Purpose: Copying Template as Shared Library
Scenario: Copy Template as Shared Library inside Program when its parent PMC is set with Stop Copy
When I search the Template of "MyITLabForOffice2013Master"
And  I click the "Copy as Shared Library" c-menu option
Then I should be on the "Copy as Shared Library" page
When I click Copy/Save button to copy
Then I should see the successfull message "You cannot copy this course due to publisher restrictions."

#Purpose: Copying Section as Section
Scenario: Copy Section as Section inside Program when its parent PMC is set with Stop Copy
When I select the "Sections" tab
Then I navigate to the "Sections" tab
When I search the section of "MyITLabOffice2013Program"
And  I click the "Copy as Section" c-menu option
Then I should be on the "Copy as Section" page
When I click Copy/Save button to copy
Then I should see the successfull message "You cannot copy this course due to publisher restrictions."

#Purpose: Copying Section as Template
Scenario: Copy Section as Template inside Program when its parent PMC is set with Stop Copy
When I select the "Sections" tab
Then I navigate to the "Sections" tab
When I search the section of "MyITLabOffice2013Program"
And  I click the "Copy as Template" c-menu option
Then I should be on the "Copy as Template" page
When I click Copy/Save button
Then I should see the successfull message "You cannot copy this course due to publisher restrictions."