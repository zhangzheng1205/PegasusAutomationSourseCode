Feature: PEGASUS-21120 Learnosity Integrations
	     As a Ws Instructor
		 I want to manage all usercases related to Learnosity Integrations
		 so that I would validate Audio Recording scenarios are working fine.


# Used MySpanishLabMaster course
#Purpose: UseCase To Enable Blackboard Collaborate Voice Authoring in course preference To Use Learnosity
#PEGASUS-26115 : Learnosity Automation - Enable Blackboard IM in course preference to enable voice tool in a course
Scenario: Learnosity Enable Blackboard Collaborate Voice Authoring by Ws Teacher  
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I 'Enable Blackboard Collaborate Voice Authoring' preference option
Then I should see the successfull message "Preferences updated successfully."

# Used MySpanishLabMaster course
#Purpose : Audio Essay Question Creation in Question Bank By WS Instructor
#PEGASUS-26118 Learnosity Automation : Record audio in Essay question type authoring
Scenario: Learnosity Audio Essay Question Creation in Question Bank By WS Instructor
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Essay" question type
Then I should be on the "Create Essay" page
When I create 'Essay audio' question type
Then I should see the successfull message "Question added successfully."

# Used MySpanishLabMaster course
#Purpose : Record Audio from HTML Page By WS Instructor
#PEGASUS-26116 Learnosity Automation : Record audio from HTML page
Scenario: Learnosity Record Audio from HTML Page By WS Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
When I click on the "Add Page" activity type
Then I should be on the "Create page" page
When I create the Audio "Page" AssetType in Content Library
Then I should see the successfull message "Page saved successfully."




