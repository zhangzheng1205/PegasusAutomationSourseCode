Feature: WorkSpaceQuestionLibrary
	                As a Ws Instructor 
					I want to manage all the workspace Question Library related usecases 
					so that I would validate all the Question Library scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully

#Purpose : To Map Question to Skill
Scenario: To Map Question to Skill By WS Instructor
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to the "Map Questions to Skills" tab
Then I should be on the "AlignContentsToSkill" page
When I map "TrueFalse" question to skill
Then I should see the successfull message "Content item is added to Skill"

#Purpose : Audio Essay Question Creation in Question Bank By WS Instructor
#PEGASUS-26118 Learnosity Automation : Record audio in Essay question type authoring
Scenario: Learnosity Audio Essay Question Creation in Question Bank By WS Instructor
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select the "Manage Question Bank" tab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Essay" question type
Then I should be on the "Create Essay" page
When I create 'Essay audio' question type
Then I should see the successfull message "Question added successfully."







