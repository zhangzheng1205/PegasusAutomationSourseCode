Feature: Pegasus27618
		As a cs Instructor
		 I want to search section and to create copy of section
		 so that copy of section pop-up will be displayed and checkbox will not be checked.

#Purpose:  To Check the fuctionality of the Copy as Section By CsSmsInstructor
Scenario: To Check the fuctionality of the Copy as Section By CsSmsInstructor
When I select the "Sections" tab
Then I navigate to the "Sections" tab
When I search the section of "MyITLabOffice2013Program"
And I click the "Copy as Section" c-menu option
Then I should see the "Copy My Course Content Only." check box as unchecked
And I should see the message "Copy My Course Content Only." on popup page 
 