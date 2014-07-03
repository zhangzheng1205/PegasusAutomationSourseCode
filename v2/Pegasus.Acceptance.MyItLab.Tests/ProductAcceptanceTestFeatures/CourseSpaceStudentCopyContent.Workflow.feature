Feature: CourseSpaceStudent
	                 As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: Open Student Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page


#Purpose: Verify the Copied Asset in Student
# TestCase Id: HED_MIL_PWF_161
Scenario: Verify the Copied Asset in Student
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see the activity "SIM5Activity" in 'Course Materials'
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To check the functionality that ensures the availability and not availability of assets between the date range By SMSStudent
# TestCase Id: HED_MIL_PWF_1013
Scenario: To check the functionality that ensures the availability and not availability of assets between the date range By SMSStudent
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the activity named as "StudyPlan"
Then I should see the 'Start Pre-Test' button
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."