Feature: CourseSpaceStudentContainerAssets
	                As a CS Student 
					I want to manage all the coursespace student Container Assets related usecases 
					so that I would validate all the coursespace student Container Assets related scenarios are working fine.

#Used Instructor Course
#Purpose : Submit the study plan with pretest and post test
# TestCase Id: HSS_PWF_479
Scenario: Submit the study plan with pretest and post test by CSSMSStudent
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open activity in course materials tab
And I submit the pretest of "StudyPlan"
And I submit the posttest of "StudyPlan"
Then I should see the status of "Readiness Check ChPA" asset as "Completed"

#Used Instructor Course
#Purpose : Submit the study plan with pretest and post test
# TestCase Id: HSS_PWF_479
Scenario: Functionality of select activity when the Activity with quote by CSSMSStudent
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on "Test" activity of behavioral mode "BasicRandom"
And I submit the "Test" activity

	
