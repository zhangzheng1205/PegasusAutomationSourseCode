Feature: CourseSpaceStudentContainerAssets
	                As a CS Student 
					I want to manage all the coursespace student Container Assets related usecases 
					so that I would validate all the coursespace student Container Assets related scenarios are working fine.

#Purpose: Open Student Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose : Submit the study plan with pretest and post test
# TestCase Id: HSS_PWF_479
Scenario: Submit the study plan with pretest and post test by CSSMSStudent
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I open activity in course materials tab
And I submit the pretest of "StudyPlan"
And I submit the posttest of "StudyPlan"
Then I should see the status of "Readiness Check ChPA" asset as "Completed"
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

	
