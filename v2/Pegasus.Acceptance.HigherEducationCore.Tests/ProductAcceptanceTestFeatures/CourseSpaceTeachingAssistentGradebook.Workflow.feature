Feature: CourseSpaceTeachingAssistentGradebook
	                As a CS Teacher Assistant
					I want to manage all the coursespace Teacher Assistant gradebook related usecases 
					so that I would validate all the coursespace Teacher Assistant gradebook scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "HedTeacherAssistant"
When I logged into the Pegasus as "HedTeacherAssistant" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To check the display of Activities in Gradebook
# TestCase Id: HSS_Core_PWF_069 
Scenario: To check the display of Activities in Gradebook By TA Instructor 
When I enter in the "InstructorCourse" from the Global Home page as "HedTeacherAssistant"
And I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I associate the "Test" activity of behavioral mode "BasicRandom" to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I navigate to the "Gradebook" tab
Then I should see the "Test" asset of behaviorla mode "BasicRandom" in Gradebook
When I "Sign out" from the "HedTeacherAssistant"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To check the display of skill StudyPlan in Gradebook
# TestCase Id: HSS_Core_PWF_072
Scenario: To check the display of SkillStudyPlan in Gradebook by TA Instructor
When I enter in the "InstructorCourse" from the Global Home page as "HedTeacherAssistant"
And I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
And I should see the "SkillStudyPlan" asset in Gradebook 
When I "Sign out" from the "HedTeacherAssistant"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Verify the functionality of "Remove from custom view" option
# TestCase Id: HSS_Core_PWF_085
Scenario: Verify the functionality of Remove from custom view option By TA Instructor
When I enter in the "InstructorCourse" from the Global Home page as "HedTeacherAssistant"
Then I should be on the "Calendar" page
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate to the subfolder "ADDITIONALPRACTICE" of asset in gradebook
And I click on cmenu "SavetoCustomView" of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones" in TA
Then I should see the successfull message "Column successfully saved to Custom View."
And I should see cmenu "Remove from Custom View" of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones" in TA
When I navigate to CustomView sub tab in a Page
Then I should be on the "Custom View" page
When I click on cmenu "RemovefromCustomView" of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones" in Custom View for TA
Then I should see the successfull message "Column successfully removed from Custom View."
When I "Sign out" from the "HedTeacherAssistant"
Then I should see the successfull message "You have been signed out of the application."

