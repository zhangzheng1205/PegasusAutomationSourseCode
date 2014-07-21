Feature: CourseSpaceTeachingAssistentGradebook
	                As a CS Teacher Assistant
					I want to manage all the coursespace Teacher Assistant gradebook related usecases 
					so that I would validate all the coursespace Teacher Assistant gradebook scenarios are working fine.


#Used TA Instructor Course
#Purpose: To check the display of Activities in Gradebook
# TestCase Id: HSS_Core_PWF_069 
Scenario: To check the display of Activities in Gradebook By TA Instructor 
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I associate the "Test" activity of behavioral mode "BasicRandom" to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I navigate to the "Gradebook" tab
Then I should see the "Test" asset of behaviorla mode "BasicRandom" in Gradebook

#Used TA Instructor Course
#Purpose: To check the display of skill StudyPlan in Gradebook
# TestCase Id: HSS_Core_PWF_072
Scenario: To check the display of SkillStudyPlan in Gradebook by TA Instructor
When I navigate to "Gradebook" tab and selected "Grades" subtab
Then I should be on the "Gradebook" page
And I should see the "SkillStudyPlan" asset in Gradebook

#Used TA Instructor Course
#Purpose: To Verify the functionality of "Remove from custom view" option
# TestCase Id: HSS_Core_PWF_085
Scenario: Verify the functionality of Remove from custom view option By TA Instructor
When I navigate to "Gradebook" tab and selected "Grades" subtab
Then I should be on the "Gradebook" page
When I navigate to the subfolder "ADDITIONALPRACTICE" of asset in gradebook
And I click on cmenu "SavetoCustomView" of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones" in TA
Then I should see the successfull message "Column successfully saved to Custom View."
And I should see cmenu "Remove from Custom View" of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones" in TA
When I navigate to CustomView sub tab in a Page
Then I should be on the "Custom View" page
When I click on cmenu "RemovefromCustomView" of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones" in Custom View for TA
Then I should see the successfull message "Column successfully removed from Custom View."

