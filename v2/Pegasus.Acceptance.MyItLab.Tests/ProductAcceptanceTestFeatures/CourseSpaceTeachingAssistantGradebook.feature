Feature: CourseSpaceTeachingAssistantGradebook
					As a CS Teacher Assistant
					I want to manage all the coursespace Teacher Assistant Gradebook related usecases 
					so that I would validate all the coursespace Teacher Assistant Gradebook scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "HedTeacherAssistant"
When I logged into the Pegasus as "HedTeacherAssistant" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To Verify Display of Grades in the Gradebook
# TestCase Id: HED_MIL_PWF_861
Scenario: Display of Grades in the Gradebook By By TA Instructor
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "HedTeacherAssistant" 
Then I should be on the "Today's View" page
When I navigate to "Gradebook" tab
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
And I should see the score "100" of "SIM5Activity" activity of behavioral mode "SkillBased" type
When I "Sign out" from the "HedTeacherAssistant"
Then I should see the successfull message "You have been signed out of the application."

