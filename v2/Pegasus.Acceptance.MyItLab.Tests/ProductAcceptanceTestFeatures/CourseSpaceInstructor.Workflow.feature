Feature: CourseSpaceInstructorViewSubmission
	As a CS Instructor 
					I want to manage all the coursespace instructor workflow related usecases 
					so that I would validate all the coursespace instructor workflow related scenarios are working fine.

#Purpose : Set Time limit for SIM Study Plan Pre test as SMS Instructor
#MyItLabInstructorCourse
Scenario: Set Time limit for SIM Study Plan Pre test as SMS Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see "SIM5StudyPlan" activity in the Content Library Frame
When I click on "Edit" cmenu option of activity in "CsSmsInstructor"
And I edit the "PreTest"
Then I should be on the "Create Pre-test:" page
When I Click on "Preferences" Tab of Edit SIM PreTest
And I enter "02" minute in Set time limit for activity preference
Then I should see the successfull message "Myitlab Study Plan updated successfully."

#Purpose : To Set Feedback Preference for Test with Basic Random Activity By SMS Instructor
# TestCase Id: HED_MIL_PWF_492
#MyItLabInstructorCourse
Scenario: To Set Feedback Preference for Test with Basic Random Activity By SMS Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see "Test" activity in the Content Library Frame
When I click on "Edit" cmenu option of activity in "CsSmsInstructor"
And I set the feedback correct answer preference
Then I should see the successfull message "Activity updated successfully."
