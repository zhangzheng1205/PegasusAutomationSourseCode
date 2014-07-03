Feature: CourseSpaceInstructorAssignmentCalendar
	                As a CS Instructor 
					I want to manage all the coursespace instructor assignment calendar related usecases 
					so that I would validate all the coursespace instructor assignment calendar related scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To check the Course Content order in the assigned date - Assignment calendar
# TestCase Id: HSS_PWF_270_02
Scenario: :To check the Course Content order in the assigned date Assignment calendar by CS Instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Calendar" page
When I enter day view for assigned content in calendar
Then I should see the order of assigned contents in calendar same as in course content
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

