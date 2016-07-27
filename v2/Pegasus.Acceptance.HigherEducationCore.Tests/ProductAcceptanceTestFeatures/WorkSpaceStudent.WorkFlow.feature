Feature: WorkSpaceStudent
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

#Purpose:To Launch the "RegChildActivity" Activity
Scenario: Launch the RegChildActivity Activity
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the "RegChildActivity" Activity

#Purpose:To close activity window
Scenario:Close activity window
Then I close the Activity window
And I should be on the "Course Materials" page

#Purpose:To Verify Presentation window, when "Display this number of questions per page" option is selected
        #To Verify Presentation window, when "Display one section / narrative per page" option is unselected
#Jira ID|Test Link Id:PEGASUS-40502|peg-8540,peg-8545	
#Pre-requisite: A SAM-Activity containing 3 sections each containing 3 (1 point) fill in the blanks question(Total Number of Questions 9)
               # Verification for "Display this number of questions per page" set to "5"
			   # Verification for "Display one section / narrative per page" been unselected
Scenario: Verify Presentation Window for Questions and Sections Display Preference Setting
Given I am on "RegSAMActivity" window
When I click on "Start" Button
Then I should see '2' questions listed in Page "1" of "RegSAMActivity" Activity Presentation Window
When I navigate to next page
Then I should see '1' questions listed in Page "2" of "RegSAMActivity" Activity Presentation Window


#Purpose:To Verify Presentation window, when "Require students to answer all questions" option is selected
#Jira ID|Test Link Id:PEGASUS-40502|peg-8554	
#Pre-requisite: A SAM-Activity containing 3 sections each containing 3 (1 point) fill in the blanks question(Total Number of Questions 9)
Scenario:Verify Presentation Window for Require students to answer all questions Preference settings
When I attempt "2" questions listed in Page "1" of "RegSAMActivity" Activity Presentation Window
Then I should see warning message on submission of activity for grading
When I navigate to next page
And I attempt "1" questions listed in Page "2" of "RegSAMActivity" Activity Presentation Window
Then I should successfully submit activity for grading

#Purpose:To Verify Presentation window, when "Allow student to Save for Later" option is selected
#Jira ID | Test Link ID: PEGASUS-45990|peg-8569,peg-8571
Scenario:To Verify Presentation window when Allow student to Save for Later option is selected
When I click on "Start" Button
Then I should the availibility of Save For Later is "true" in "RegSAMActivity" Activity Presentation Window
When I attempt "2" questions listed in Page "1" of "RegSAMActivity" Activity Presentation Window
And I navigate to next page
Then I Verify Confirmation Message on Save the Activity for later
And I should be on the "Course Materials" page
And I should see "In Progress" status for the activity "RegChildActivity" from "Course Materials" page
When I open the "RegChildActivity" Activity
Then I am on "RegSAMActivity" window
When I click on "Start" Button
Then I should see "2" questions answers saved in Page "1" of "RegSAMActivity" Activity Presentation Window
When I navigate to next page
And I attempt "1" questions listed in Page "2" of "RegSAMActivity" Activity Presentation Window
Then I should successfully submit activity for grading
And I am on "RegSAMActivity" window
When I click on "Close" Button
Then I should see the "Passed" status for the activity "RegChildActivity"

#Purpose:To verify Display of Direction Lines when “Enable activity-level direction lines” enabled
#Purpose:To Verify Display Direction Lines on Each Page option is selected 
#Purpose:To verify Display of Direction Lines when “ Enable activity section-level direction lines ” enabled
#Purpose:To verify section level direction lines
#Test Link ID:peg-8557
Scenario:Verify Activity and Section Direction Lines
Given I am on "RegSAMActivity" window
When I click on "Start" Button
Then I should see the availibility "Direction lines (instructions)" at Page is "True"
And I should see the Section Direction lines for Section "1"
When I navigate to next page
Then I should see the availibility "Direction lines (instructions)" at Page is "True"
And I should see the Section Direction lines for Section "3"


#Purpose:To verify Beginning of activity message
Scenario:To verify Beginning of activity message
Given I am on "RegSAMActivity" window
Then I should see the availability of "Beginning of activity" message is "True"
And I should see see the availability of "Start" Button is "True"
And I should see see the availability of "Close" Button is "True"
When I click on "Start" Button


#Purpose:To verify Beginning of activity message
Scenario:To verify End of activity message
Given I am on "RegSAMActivity" window
Then I should see the availability of "End of activity" message is "True"
And I should see see the availability of "Close" Button is "True"
When I click on "Close" Button


#Purpose:To Verify Presentation window, when "Allow student to Save for Later" option is unselected
#Jira ID | Test Link ID: PEGASUS-45990|peg-8570 
Scenario:To Verify Presentation window when Allow student to Save for Later option is unselected
Then I should the availibility of Save For Later is "false" in "RegSAMActivity" Activity Presentation Window
And I close the Activity window
And I should be on the "Course Materials" page



#Purpose:To Verify Display Direction Lines on Each Page option is not selected
#Test Link ID:peg-8558
Scenario:To Verify Display Direction Lines on Each Page option is not selected
Given I am on "RegSAMActivity" window
Then I should see the availibility "Direction lines (instructions)" at Page is "True"
When I navigate to next page
Then I should see the availibility "Direction lines (instructions)" at Page is "False"

#Purpose:Workspace student launch newly authored activity
Scenario: workspace student launch RegChildActivity from Course Materials page
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I launch the  "RegChildActivity" Activity as "HedWsStudent" from "Course Materials" page

