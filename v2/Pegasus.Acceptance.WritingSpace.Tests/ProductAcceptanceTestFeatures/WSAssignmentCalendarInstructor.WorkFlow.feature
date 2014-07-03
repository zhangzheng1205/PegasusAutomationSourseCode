Feature: WSAssignmentCalendarInstructor
	            As a MMND Instructor 
				I want to manage all the MMND Instructor Assignment Calendar related usecases 
				so that I would validate all the MMND Instructor Assignment Calendar scenarios are working fine.

#Purpose: Verify The Writingspace Activity Displayed In Assignment Calendar
Scenario: Verify The Display of Writingspace Activity In Assignment Calendar by MMND Instructor
When I click on "Course Home" subtab
And I click the "Assign_Content" link
And I search "WritingSpace" activity in calendar
Then I should see the "There are no matches for your search criteria. Please try again." in 'Assignment Calendar'

