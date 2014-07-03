Feature: CourseSpaceTeachingAssistantQuestionLibrary
					As a CS Teacher Assistant
					I want to manage all the coursespace Teacher Assistant Question Library related usecases 
					so that I would validate all the coursespace Teacher Assistant  Question Libraryscenarios are working fine.


#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "HedTeacherAssistant"
When I logged into the Pegasus as "HedTeacherAssistant" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Creation of question folder and its accessibility
#TestCase Id: HSS_Core_PWF_190
Scenario: Creation of question folder and its accessibility By Teaching Assistant
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "HedTeacherAssistant"
And I navigate to the "Course Materials" tab
And I select the "Manage Question Bank" tab
Then I should be on the "Question Bank" page
When I select "Add Course Materials" option
And I select "Add Folder" option
Then I should be on the "Create New Folder" page
When I create question "Folder"
Then I should see the created question "Folder"
When I "Sign out" from the "HedTeacherAssistant"
Then I should see the successfull message "You have been signed out of the application."

