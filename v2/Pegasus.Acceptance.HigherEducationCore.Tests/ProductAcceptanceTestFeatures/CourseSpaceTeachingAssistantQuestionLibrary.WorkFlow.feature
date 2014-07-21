Feature: CourseSpaceTeachingAssistantQuestionLibrary
					As a CS Teacher Assistant
					I want to manage all the coursespace Teacher Assistant Question Library related usecases 
					so that I would validate all the coursespace Teacher Assistant  Question Libraryscenarios are working fine.


#Used Instructor Course
#Purpose: Creation of question folder and its accessibility
#TestCase Id: HSS_Core_PWF_190
Scenario: Creation of question folder and its accessibility By Teaching Assistant
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select "Add Course Materials" option
And I select "Add Folder" option
Then I should be on the "Create New Folder" page
When I create "QuestionFolder" type Folder
Then I should see the created question "Folder"

