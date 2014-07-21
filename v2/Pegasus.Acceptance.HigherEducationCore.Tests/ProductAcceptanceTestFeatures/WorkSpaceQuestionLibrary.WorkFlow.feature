Feature: WorkSpaceQuestionLibrary
	                As a Ws Instructor 
					I want to manage all the workspace Question Library related usecases 
					so that I would validate all the Question Library scenarios are working fine.

#Used Master Course
#Purpose : To Map Question to Skill
Scenario: To Map Question to Skill By WS Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I navigate to the "Map Questions to Skills" tab
Then I should be on the "AlignContentsToSkill" page
When I map "TrueFalse" question to skill
Then I should see the successfull message "Content item is added to Skill"


