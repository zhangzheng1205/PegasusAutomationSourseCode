Feature: CourseSpaceInstructorCalendar
	                As a CS Instructor 
					I want to manage all the coursespace instructor calendar related usecases 
					so that I would validate all the coursespace instructor calendar related scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To verify the functionality of Searching Contents through simple option
# TestCase Id: HSS_Core_PWF_303
Scenario: To verify the functionality of Searching Contents through simple option by CS instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Calendar" page
When I select "Content Type" option in 'VIEW BY' dropdown and "Items Assigned" option in 'SHOW' dropdown
And I select "Activity" content type
And I search "SkillStudyPlan" content
Then I should see the searched "SkillStudyPlan"
	

#Purpose: Fields available in the Restrict Availability frame of the properties window
# TestCase Id: HSS_Core_PWF_324
Scenario: Fields available in the Restrict Availability frame of the properties window by CS instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Calendar" page
When I search the "PA-05 Span Practice- Grammar: Los pronombres personales"
Then I should see the searched "PA-05 Span Practice- Grammar: Los pronombres personales"
When I select the cmenu option 'Assignment Properties' of activity
And I select the 'Not Assigned' option
And I select the 'Set availability date range' option
Then I should see the 'Set End Date as Due Date' option in disabled state
And I should see all the fields in 'Restrict Availability' frame 
When I click on "Cancel" button in assign window

#Purpose: Assign the content through 'Assign/Unassign' button in content frame
# TestCase Id: HSS_Core_PWF_340
Scenario: Assign the content through 'Assign/Unassign' button in content frame by CS instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Calendar" page
When I select "PA-03 Span Practice- Gramática: El alfabeto" content which is "Not Assigned"
And I click on "Assign/Unassign" button in Calendar
Then I should see "PA-03 Span Practice- Gramática: El alfabeto" content is in "Assigned" state
When I select "PA-03 Span Practice- Gramática: El alfabeto" content which is "Assigned"
And I select "PA-04 Span Practice- Vocabulary: Los cognados" content which is "Not Assigned"
Then I should see the 'Assign/Unassign' button is in disabled state


#Purpose: Fields available in the 'Make item available to…' frame of the properties window
# TestCase Id: HSS_Core_PWF_325
Scenario: Fields available in the 'Make item available to…' frame of the properties window by CS instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Calendar" page
When I navigate to the "Enrollments" tab
Then I should be on the "Roster" page
When I navigate to the "Manage Groups" tab
Then I should be on the "Enrollments" page
When I create group
Then I should see the successfull message "Group added successfully."
When I enroll student to group
Then I should see the successfull message "Students enrolled successfully."
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
