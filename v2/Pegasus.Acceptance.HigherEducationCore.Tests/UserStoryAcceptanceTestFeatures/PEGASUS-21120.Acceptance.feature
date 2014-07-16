Feature: PEGASUS-21120 Learnosity Integrations
	     As a Ws Instructor
		 I want to manage all usercases related to Learnosity Integrations
		 so that I would validate Audio Recording scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page

#Purpose: UseCase To Enable Blackboard Collaborate Voice Authoring in course preference To Use Learnosity
#PEGASUS-26115 : Learnosity Automation - Enable Blackboard IM in course preference to enable voice tool in a course
Scenario: Learnosity Enable Blackboard Collaborate Voice Authoring by Ws Teacher  
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I 'Enable Blackboard Collaborate Voice Authoring' preference option
Then I should see the successfull message "Preferences updated successfully."

#Purpose : Audio Essay Question Creation in Question Bank By WS Instructor
#PEGASUS-26118 Learnosity Automation : Record audio in Essay question type authoring
Scenario: Learnosity Audio Essay Question Creation in Question Bank By WS Instructor
When I navigate to the "Course Materials" tab
And I select the "Manage Question Bank" tab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Essay" question type
Then I should be on the "Create Essay" page
When I create 'Essay audio' question type
Then I should see the successfull message "Question added successfully."

