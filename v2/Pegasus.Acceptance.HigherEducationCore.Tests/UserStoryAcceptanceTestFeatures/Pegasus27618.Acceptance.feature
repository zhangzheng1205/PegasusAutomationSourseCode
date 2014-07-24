Feature: Pegasus27618
		As a cs Instructor
		 I want to search section and to create copy of section
		 so that copy of section pop-up will be displayed and checkbox will not be checked.

Background:
#Purpose: Open Course Space Url and Navigates To The Program Administration page on ProgramCourse Selection
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should be on the "Global Home" page
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page

#Purpose:  To Check the fuctionality of the Copy as Section By CsSmsInstructor
Scenario: To Check the fuctionality of the Copy as Section By CsSmsInstructor
When I select the "Sections" tab
Then I navigate to the "Sections" tab
When I click the "Copy as Section" option
Then I should see the check box as unchecked
And I should see the message "Copy My Course Content Only." on popup page 
 