Feature: WorkSpaceTeacher
	                 As a WorkSpace Teacher
					I want to manage all the workspace teacher related usecases 
					so that I would validate all the workspace teacher scenarios are working fine.

#Container Course Scenario
#Purpose: UseCase To Set Preferences for container Course
Scenario: Set Preferences for Container Course by Ws Teacher
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I set the preferences for Copy Content
Then I should see the successfull message "Preferences updated successfully."
When I set the preferences for Content in Container course
Then I should see the successfull message "Preferences updated successfully."
When I set the preferences for Shared Library 
Then I should see the successfull message "Shared library courses successfully added to the current course."
When I save the Preferences
Then I should see the successfull message "Preferences updated successfully."

#EmptyClass Course Scenario
#Purpose: UseCase To Set Preferences for Empty Course
Scenario: Set Preferences for Empty Course by Ws Teacher
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I set the preferences for Copy Content
Then I should see the successfull message "Preferences updated successfully."
When I set the preferences for Custom Content
Then I should see the successfull message "Preferences updated successfully."
When I set the preferences for My Course
Then I should see the successfull message "Preferences updated successfully."
When I set the preferences for Content
Then I should see the successfull message "Preferences updated successfully."

#Masterlibrary Course Scenario
#Purpose: UseCase To Set Preferences for Master Course
Scenario: Set Preferences for Master Course by Ws Teacher
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I click on the "Grading" tab
And I enable necessary grades preference settings
Then I should see the successfull message "preferences updated successfully"

#Masterlibrary Course Scenario
#Purpose: To Create Test Activity creation by Workspace Teacher
#TestCase Id: NN_PWF_150
Scenario: Activity creation by Ws Teacher 
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I select on the "Test" from add content link
Then I should be on the "Create activity" page
When I create "Test" type activity of behavioral mode 'BasicRandom'
Then I should see the successfull message "Activity added successfully."
When I associate the "Test" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Masterlibrary Course Scenario
#Purpose: To Create Quiz Activity creation by Workspace Teacher
Scenario: To Create Quiz with Manual Gradable Activity By WS Teacher
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I select on the "Quiz" from add content link
Then I should be on the "Create activity" page
When I create "Quiz" activity of behavioral mode type using Essay question
Then I should see the successfull message "Activity added successfully."
When I associate the "Quiz" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

