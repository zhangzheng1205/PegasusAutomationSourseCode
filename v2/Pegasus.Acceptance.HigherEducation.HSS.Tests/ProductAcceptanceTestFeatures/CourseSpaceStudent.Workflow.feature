Feature: CourseSpaceStudent Submission
	                 As a CS Student 
					I want to manage all the coursespace student Submission related usecases 
					so that I would validate all the coursespace student Submission scenarios are working fine.

#Purpose : Student launching eText
#Test case ID : peg-22168
Scenario: Student launching eText
When I Click on eText link
Then I should be on the "Pearson eText Sign In Page" window
And I close eText Window
Then I should be on the "Course Materials" page

#Purpose : Basic/Random activity launch from Course Calendar and student abruptly closes the presentation
#Test case ID : peg-22160
Scenario: Student abruptly closes the Basic/Random activity presentation
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Take the Chapter 1 Exam" in "Course Materials" by "HSSCsSmsStudent"
Then I should be on the "Exam" page displayed with questions
When I forcibly close the Exam window abdruplty
Then I should see the "In Progress" status for the activity "Take the Chapter 1 Exam"
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Basic/Random activity from Course Calendar and student perform Save for later
#Test case ID : peg-22156
#PEGASUS-29429
Scenario: Student answers the Basic/Random activity questions and perform Save for later
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Take the Chapter 1 Exam" in "Course Materials" by "HSSCsSmsStudent"
Then I should be on the "Exam" page displayed with questions
And I answer activity "TakeTheChapter1Exam" with behaviour "BasicRandom" of "Homework" type with "partial" answers
When I click on save for later button
Then I should see the "In Progress" status for the activity "Take the Chapter 1 Exam"
And I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Basic/Random activity from Course Calendar and student scoring 100%
#Test case ID : peg-22151
#PEGASUS-29428
Scenario: Student answers the Basic/Random questions and scores 100%
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Take the Chapter 1 Exam" in "Course Materials" by "HSSCsSmsStudent"
Then I should be on the "Exam" page displayed with questions
And I answer activity "TakeTheChapter1Exam" with behaviour "BasicRandom" of "Homework" type with "correct" answers
When I click on Submit the activity "100%" score should be displayed in the screen
Then I should be on the "Course Materials" page
And I should see the "Passed" status for the activity "Take the Chapter 1 Exam"
When I click on View Submission 
Then I should see the "100 %" score in the left frame
And I should see Student "scoring 100" as "HSSCsSmsStudent" and displayed like "Gradebook Grade : 100.00%" in the right frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Basic/Random activity from Course Calendar and student scoring 0%
#Test case ID : peg-22146
#PEGASUS-29427
Scenario: Student answers the Basic/Random questions and scores 0%
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Take the Chapter 1 Exam" in "Course Materials" by "HSSCsSmsStudent"
Then I should be on the "Exam" page displayed with questions
And I answer activity "TakeTheChapter1Exam" with behaviour "BasicRandom" of "Homework" type with "incorrect" answers
When I click on Submit the activity "0%" score should be displayed in the screen
Then I should be on the "Course Materials" page
And I should see the "Not passed" status for the activity "Take the Chapter 1 Exam"
When I click on View Submission 
Then I should see the "0 %" score in the left frame
And I should see Student "scoring 0" as "HSSCsSmsStudent" and displayed like "Gradebook Grade : 0.00%" in the right frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Student submits the Non gradable assets from the TO DO tab
#Test case ID : peg-22150
#PEGASUS-29432
#Products : HSS
Scenario: Student submits the Non gradable assets from the TO DO tab
When I navigate to "Assignments" tab and selected "To Do" subtab
Then I should be on the "Assignments - To Do" page
When I launch "Review the Chapter 1 Learning Objectives" asset
Then I should be on the "Learning Objectives - Chapter 1" page
When I close the "Learning Objectives - Chapter 1" window
Then I should see "Viewed" status for the asset
Then I should see "Review the Chapter 1 Learning Objectives" in the 'Completed' tab

#Purpose : Study plan submission from To Do and student scoring 0% in pretest
#Test case ID : peg-22152
#PEGASUS-29433
Scenario: Student answers the Study plan pretest questions and scores 0%
When I navigate to "Assignments" tab and selected "To Do" subtab
Then I should be on the "Assignments - To Do" page
When I launch "Complete the Chapter 1 Study Plan" asset
Then I should be on the "Open Study Plan" page
When I Click open under "PreTest" frame to launch the Questions
Then I should be on the "PreTest" page displayed with questions
And I answer activity "CompleteTheChapter1StudyPlan" with behaviour "StudyPlan" of "Homework" type with "incorrect" answers
When I click on Submit the activity "0%" score should be displayed in the screen
And I click on return to course
Then I should be on the "Assignments - To Do" page
And I should see the "In Progress" status for the activity "Complete the Chapter 1 Study Plan" in Assignments Page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Study plan submission from To Do and student scoring 0% in postest
#Test case ID : peg-22155
#PEGASUS-29436
Scenario: Student answers the Study plan posttest questions and scores 0%
Given I browsed the login url for "HSSCsSmsStudent"
When I logged into the Pegasus as "HSSCsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsStudent"
When I navigate to "Assignments" tab and selected "To Do" subtab
Then I should be on the "Assignments - To Do" page
When I launch "Complete the Chapter 1 Study Plan" asset
Then I should be on the "Open Study Plan" page
When I Click open under "PostTest" frame to launch the Questions
Then I should be on the "PostTest" page displayed with questions
And I answer activity "CompleteTheChapter1StudyPlan" with behaviour "StudyPlan" of "Homework" type with "incorrect" answers
When I click on Submit the activity "0%" score should be displayed in the screen
And I click on return to course
Then I should be on the "Assignments - To Do" page
And I should see the "In Progress" status for the activity "Complete the Chapter 1 Study Plan" in Assignments Page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Study plan submission from To Do and student scoring 70% in pretest
#Test case ID : peg-22155
#PEGASUS-29436
Scenario: Student answers the Study plan pretest questions and scores 70%
When I navigate to "Assignments" tab and selected "To Do" subtab
Then I should be on the "Assignments - To Do" page
When I launch "Complete the Chapter 1 Study Plan" asset
Then I should be on the "Open Study Plan" page
When I Click open under "PreTest" frame to launch the Questions
Then I should be on the "PreTest" page displayed with questions
And I answer activity "CompleteTheChapter1StudyPlan" with behaviour "StudyPlan" of "Homework" type with "partial" answers of "pretest"
When I click on Submit the activity "72%" score should be displayed in the screen
And I click on return to course
Then I should be on the "Assignments - To Do" page
And I should see the "In Progress" status for the activity "Complete the Chapter 1 Study Plan" in Assignments Page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Study plan submission from To Do and student scoring 70% in posttest
#Test case ID : peg-22154
#PEGASUS-29435
Scenario: Student answers the Study plan posttest questions and scores 70%
When I navigate to "Assignments" tab and selected "To Do" subtab
Then I should be on the "Assignments - To Do" page
When I launch "Complete the Chapter 1 Study Plan" asset
Then I should be on the "Open Study Plan" page
When I Click open under "PosTest" frame to launch the Questions
Then I should be on the "PosTest" page displayed with questions
And I answer activity "CompleteTheChapter1StudyPlan" with behaviour "StudyPlan" of "Homework" type with "partial" answers of "postest"
When I click on Submit the activity "72%" score should be displayed in the screen
And I click on return to course
Then I should be on the "Assignments - To Do" page
And I should see the "In Progress" status for the activity "Complete the Chapter 1 Study Plan" in Assignments Page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page