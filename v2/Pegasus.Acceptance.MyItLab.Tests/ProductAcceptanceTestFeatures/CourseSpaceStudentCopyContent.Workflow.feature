Feature: CourseSpaceStudent
	                 As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: Verify the Copied Asset in Student
# TestCase Id: HED_MIL_PWF_161
#MyItLabProgramCourse
Scenario: Verify the Copied Asset in Student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see the activity "SIM5Activity" in 'Course Materials'

#Purpose: To check the functionality that ensures the availability and not availability of assets between the date range By SMSStudent
# TestCase Id: HED_MIL_PWF_1013
#MyItLabInstructorCourse
Scenario: To check the functionality that ensures the availability and not availability of assets between the date range By SMSStudent
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the activity named as "StudyPlan"
Then I should see the 'Start Pre-Test' button