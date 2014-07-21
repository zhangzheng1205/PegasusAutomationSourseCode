Feature: CourseSpaceInstructorAssignmentCalendar
	                As a CS Instructor 
					I want to manage all the coursespace instructor assignment calendar related usecases 
					so that I would validate all the coursespace instructor assignment calendar related scenarios are working fine.

#Verify the usecase in InstructorCourse
#Purpose: To check the Course Content order in the assigned date - Assignment calendar
# TestCase Id: HSS_PWF_270_02
Scenario: :To check the Course Content order in the assigned date Assignment calendar by CS Instructor
When I navigate to "Assignment Calendar" tab of the "Calendar" page
Then I should be on the "Calendar" page
When I enter day view for assigned content in calendar
Then I should see the order of assigned contents in calendar same as in course content

