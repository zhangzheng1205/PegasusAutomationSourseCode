Feature: WorkSpaceStudent
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

#Purpose:To Verify Presentation window, when "Display this number of questions per page" option is selected
        #To Verify Presentation window, when "Display one section / narrative per page" option is unselected
#Jira ID|Test Link Id:PEGASUS-40502|peg-8540,peg-8545	
#Pre-requisite: A SAM-Activity containing 3 sections each containing 3 (1 point) fill in the blanks question(Total Number of Questions 9)
               # Verification for "Display this number of questions per page" set to "5"
			   # Verification for "Display one section / narrative per page" been unselected
Scenario: Verify Presentation Window for Questions and Sections Display Preference Setting
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the "RegSavedSAMActivity" Activity
Then I should see '5' questions listed in Page "1" of "RegSAMActivity" Activity Presentation Window
When I navigate to next page
Then I should see '4' questions listed in Page "2" of "RegSAMActivity" Activity Presentation Window
Then I close the Activity window
Then I should be on the "Course Materials" page


#Purpose:To Verify Presentation window, when "Require students to answer all questions" option is selected
#Jira ID|Test Link Id:PEGASUS-40502|peg-8554	
#Pre-requisite: A SAM-Activity containing 3 sections each containing 3 (1 point) fill in the blanks question(Total Number of Questions 9)
Scenario:Verify Presentation Window for Require students to answer all questions Preference settings
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the "RegSavedSAMActivity" Activity
And I attempt "5" questions listed in Page "1" of "RegSAMActivity" Activity Presentation Window
Then I should see warning message on submission of activity for grading
When I navigate to next page
And I attempt "4" questions listed in Page "2" of "RegSAMActivity" Activity Presentation Window
Then I should successfully submit activity for grading