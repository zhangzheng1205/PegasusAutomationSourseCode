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
Scenario: Instructor Previews the Grader IT Activity
When I enter in the "MyItLabSIMMasterCourse" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I search "SIMGraderActivity" activity of behavioral mode "Assignment" type
And I select the Cmenu option "Preview"
Then I should be on the "Test Presentation" page
When I close the "Test Presentation" window
And I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."