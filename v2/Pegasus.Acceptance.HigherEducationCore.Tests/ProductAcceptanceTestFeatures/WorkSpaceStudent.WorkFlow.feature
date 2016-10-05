Feature: WorkSpaceStudent
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

#Purpose:To Launch the "RegChildActivity" Activity
Scenario: Launch the RegChildActivity Activity
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on "Open" of  "RegChildActivity" Activity in "Course Materials" page

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
Given I am on "RegSAMActivity" window
When I click on "Start" Button
Then I should the availibility of Save For Later is "true" in "RegSAMActivity" Activity Presentation Window
When I attempt "2" questions listed in Page "1" of "RegSAMActivity" Activity Presentation Window with "In Valid" answer
And I navigate to next page
Then I Verify Confirmation Message on Save the Activity for later


Scenario:To Verify activity status as In Progress when Allow student to Save for Later option is selected
Then I should be on the "Course Materials" page
And I should see "In Progress" status for the activity "RegChildActivity" from "Course Materials" page


#Purpose:To verify Display of Direction Lines when “Enable activity-level direction lines” enabled
#Purpose:To Verify Display Direction Lines on Each Page option is selected 
#Purpose:To verify Display of Direction Lines when “ Enable activity section-level direction lines ” enabled
#Purpose:To verify section level direction lines
#Test Link ID:peg-8557
Scenario:Verify Activity and Section Direction Lines
When I open the "RegChildActivity" Activity
Then I am on "RegSAMActivity" window
When I click on "Start" Button
Then I should see the availibility "Direction lines (instructions)" at Page is "True"
And I should see the Section Direction lines for Section "1"

Scenario:Student submit the activity with incorrect answer and fails
Then I should see "2" questions answers saved in Page "1" of "RegSAMActivity" Activity Presentation Window
When I navigate to next page
And I attempt "1" questions listed in Page "2" of "RegSAMActivity" Activity Presentation Window with "In Valid" answer
When I navigate to next page
And I attempt "1" questions listed in Page "3" of "RegSAMActivity" Activity Presentation Window with "Valid" answer
When I submit the answered activity "RegSAMActivity" 

Scenario:Student verify feedback status in presenation window
Then I should be displayed with Feedback Icon in "RegSAMActivity" window
When I click on the Feedback Icon in "RegSAMActivity" window
Then I should displayed with "Correct Feedback" text in "RegSAMActivity" window


Scenario:Student verify activity status as pass for correct submission
When I click on "Return to Course" button in "RegSAMActivity" window
Then I should be on the "Course Materials" page
And I should see "Passed" status for the activity "RegChildActivity" from "Course Materials" page


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
When I click on "Open" of  "RegChildActivity" Activity in "Course Materials" page

#Purpose:To verify Beginning of activity message
Scenario:To verify Beginning of activity message
Given I am on "RegSAMActivity" window
Then I should see the availability of "Instructor Begin Message" message is "True"
And I should see see the availability of "Start" Button is "True"
And I should see see the availability of "Close" Button is "True"

Scenario: Student abruptly closes the presenation window and validate
When I click on "Start" Button
And I close activity presenation window Abruptly
Then I should be on the "Course Materials" page
And I should see "Not started" status for the activity "RegChildAbruptActivity" from "Course Materials" page

Scenario: Student Validate abruptly closed activity status in view submission page
When I click on "View Submissions" of  "RegChildAbruptActivity" Activity in "Course Materials" page
Then I should be on the "View Submission" page
And I should see the message "Activity has been started but not yet submitted." in view submission page
When I close the "View Submission" window
Then I should be on the "Course Materials" page

Scenario: Student resubmit the assessment by chick on try again and secure 100 percent
Given I am on "RegSAMActivity" window
When I click on "Try Again" button of "RegSAMActivity" 
When I attempt "2" questions listed in Page "1" of "RegSAMActivity" Activity Presentation Window with "Valid" answer
When I navigate to next page
And I attempt "1" questions listed in Page "2" of "RegSAMActivity" Activity Presentation Window with "Valid" answer
When I navigate to next page
And I attempt "1" questions listed in Page "3" of "RegSAMActivity" Activity Presentation Window with "Valid" answer
When I submit the answered activity "RegSAMActivity" 

Scenario: Workspace student launch RegChildAbruptActivity from Course Materials page
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on "Open" of  "RegChildAbruptActivity" Activity in "Course Materials" page

Scenario: Student Validate 100 percent score in view submission page
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on "View Submissions" of  "RegChildActivity" Activity in "Course Materials" page
Then I should be on the "View Submission" page
And  I should be displayed with "100" score page
When I close the "View Submission" window
Then I should be on the "Course Materials" page

#Pupose: Student submits activity with correct answers
Scenario: Student submits activity with correct answers
When I select "correct" answer for True/False question
And I should successfully submit activity for grading

#Purpose: Student submits activity with incorrect answers
Scenario: Student answers activity with incorrect answers
When I select "incorrect" answer for True/False question
And I should successfully submit activity for grading

#Purpose: Student opens Activity for Highest score
Scenario: Launch Activity for Highest score
When I click on "Open" of  "RegHighestScoreActivity" Activity in "Course Materials" page
And I click on "Start" button in "RegSAMActivity" presentation window 

#Purpose: Student opens Activity for Lowest score
Scenario: Launch Activity for Lowest score
When I click on "Open" of  "RegLowestScoreActivity" Activity in "Course Materials" page
And I click on "Start" button in "RegSAMActivity" presentation window 

#Purpose: Student opens Activity for First score
Scenario: Launch Activity for First score
When I click on "Open" of  "RegFirstScoreActivity" Activity in "Course Materials" page
And I click on "Start" button in "RegSAMActivity" presentation window 

#Purpose: Student opens Activity for Last score
Scenario: Launch Activity for Last score
When I click on "Open" of  "RegLastScoreActivity" Activity in "Course Materials" page
And I click on "Start" button in "RegSAMActivity" presentation window 

#Purpose: Student opens Activity for Average score
Scenario: Launch Activity for Average score
When I click on "Open" of  "RegAverageScoreActivity" Activity in "Course Materials" page
And I click on "Start" button in "RegSAMActivity" presentation window 

#Purpose: Verify score recorded in Gradebook is as per the score Preference
Scenario: Verify Average Score is Recorded
When I click on "View Submissions" of  "RegAverageScoreActivity" Activity in "Course Materials" page
Then I should be on the "View Submission" page
And as "HedWsStudent" I should see the "Average" score recorded
When I close the "View Submission" window
Then I should be on the "Course Materials" page

Scenario: Verify Highest Score is Recorded
When I click on "View Submissions" of  "RegHighestScoreActivity" Activity in "Course Materials" page
Then I should be on the "View Submission" page
And as "HedWsStudent" I should see the "Highest" score recorded
When I close the "View Submission" window
Then I should be on the "Course Materials" page

Scenario: Verify Lowest Score is Recorded
When I click on "View Submissions" of  "RegLowestScoreActivity" Activity in "Course Materials" page
Then I should be on the "View Submission" page
And as "HedWsStudent" I should see the "Lowest" score recorded
When I close the "View Submission" window
Then I should be on the "Course Materials" page

Scenario: Verify First Score is Recorded
When I click on "View Submissions" of  "RegFirstScoreActivity" Activity in "Course Materials" page
Then I should be on the "View Submission" page
And as "HedWsStudent" I should see the "First" score recorded
When I close the "View Submission" window
Then I should be on the "Course Materials" page

Scenario: Verify Last Score is Recorded
When I click on "View Submissions" of  "RegLastScoreActivity" Activity in "Course Materials" page
Then I should be on the "View Submission" page
And as "HedWsStudent" I should see the "Last" score recorded
When I close the "View Submission" window
Then I should be on the "Course Materials" page

#Purpose: Student opens Folder
Scenario: Student Opens folder in Course Materials page
When I click on "Open" of  "RegFolderGBPreference" Folder in "Course Materials" page