Feature: CourseSpaceTeachingAssistantAssignmentCalendar
	                As a CS Teacher Assistant
					I want to manage all the coursespace Teacher Assistant assignment calendar related usecases 
					so that I would validate all the coursespace Teacher Assistant assignment calendar scenarios are working fine.

#Used TA Instructor Course
#Purpose: To check the Course Content order in the assigned date - Assignment calendar
# TestCase Id: HSS_PWF_270_02
Scenario: :To check the Course Content order in the assigned date Assignment calendar By TA Instructor
When I navigate to "Assignment Calendar" tab of the "Calendar" page
Then I should be on the "Calendar" page
When I enter day view for assigned content in calendar
Then I should see the order of assigned contents in calendar same as in course content

#Used TA Instructor Course
#Purpose: Assign the content through 'Assign/Unassign' button in content frame
# TestCase Id: HSS_Core_PWF_340
Scenario: Assign the content through 'Assign/Unassign' button in content frame by TA Instructor
When I navigate to "Assignment Calendar" tab of the "Calendar" page
Then I should be on the "Calendar" page
When I select "PA-03 Span Practice- Gramática: El alfabeto" content which is "Not Assigned"
And I click on "Assign/Unassign" button in Calendar
Then I should see "PA-03 Span Practice- Gramática: El alfabeto" content is in "Assigned" state
When I select "PA-03 Span Practice- Gramática: El alfabeto" content which is "Assigned"
And I select "PA-04 Span Practice- Vocabulary: Los cognados" content which is "Not Assigned"
Then I should see the 'Assign/Unassign' button is in disabled state

#Used TA Instructor Course
#Purpose: Fields available in the 'Make item available to…' frame of the properties window
# TestCase Id: HSS_Core_PWF_325
Scenario: Fields available in the 'Make item available to' frame of the properties window by TA Instructor
When I navigate to "Enrollments" tab and selected "Manage Groups" subtab
Then I should be on the "Enrollments" page
When I create group
Then I should see the successfull message "Group added successfully."
When I enroll student to group
Then I should see the successfull message "Students enrolled successfully."
When I navigate to the "Preferences" tab
And I navigate to the "Permissions" tab
Then I should be on the "Preferences" page
When I enable 'Schedule Activities' option
Then I should see the successfull message "Preferences updated successfully."
When I navigate to the "Calendar" tab
Then I should be on the "Calendar" page
When I search the "PA-05 Span Practice- Grammar: Los pronombres personales"
Then I should see the searched "PA-05 Span Practice- Grammar: Los pronombres personales"
When I select the cmenu option 'Assignment Properties' of activity
Then I should see 'All Students' and 'Selected Students' options in 'Make item available to' frame
When I select 'Selected Students' option
Then I should see the text "Choose which students will receive this assignment" in 'Make item available to' frame
And I should see the 'View by' and 'Selected Students' frames 
When I click on "Cancel" button in assign window