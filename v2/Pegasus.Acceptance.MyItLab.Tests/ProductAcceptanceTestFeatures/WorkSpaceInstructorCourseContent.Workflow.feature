Feature: WorkSpaceInstructorCourseContent
	     As a Ws Instructor 
		I want to manage all the workspace Instructor related usecases 
		so that I would validate all the workspace Instructor scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page


#Purpose: Instructor Previews the Grader IT Activity
#TestCase Id: HED_MIL_PWF_094
#MyItLabSIMMasterCourse
Scenario: Instructor Previews the Grader IT Activity
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I search "SIMGraderActivity" activity of behavioral mode "Assignment" type
And I select the Cmenu option "Preview"
Then I should be on the "Test Presentation" page
And I close the "Test Presentation" window