Feature: CourseSpaceStudent Submission
	                 As a CS Student 
					I want to manage all the coursespace student Submission related usecases 
					so that I would validate all the coursespace student Submission scenarios are working fine.

#Purpose : Student launching eText
#Test case ID : peg-22168
#PEGASUS-29431
Scenario: Student launching eText
When I Click on eText link
Then I should be on the "Pearson eText Sign In Page" window
And I close eText Window
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Basic/Random activity launch from Course Calendar and student abruptly closes the presentation
#Test case ID : peg-22160
#PEGASUS-29430
Scenario: Student abruptly closes the Basic/Random activity presentation
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Take the Chapter 1 Exam" in "Course Materials" by "HSSCsSmsStudent"
Then I should be on the "Exam" page displayed with questions
When I close the Exam window abruplty
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
And I should see Student "scoring 100" as "HSSCsSmsStudent" and displayed like "Gradebook Grade : 100%" in the right frame
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
And I should see Student "scoring 0" as "HSSCsSmsStudent" and displayed like "Gradebook Grade : 0%" in the right frame
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
When I launch "Review the Chapter 5 Learning Objectives" asset
Then I should be on the "Learning Objectives - Chapter 5" page
When I close the "Learning Objectives - Chapter 5" window
Then I should see "Viewed" status for the asset
When I navigate to "Assignments" tab and selected "Completed" subtab
Then I should be on the "Assignments - Done" page
And I should see the "Viewed" status for the activity "Review the Chapter 5 Learning Objectives" in "Assignments - Done" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

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
And I should see the "In Progress" status for the activity "Complete the Chapter 1 Study Plan" in "Assignments - To Do" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Study plan submission from To Do and student scoring 0% in postest
#Test case ID : peg-22155
#PEGASUS-29436
Scenario: Student answers the Study plan posttest questions and scores 0%
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
And I should see the "In Progress" status for the activity "Complete the Chapter 1 Study Plan" in "Assignments - To Do" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Study plan submission from To Do and student scoring 70% in pretest
#Test case ID : peg-22153
#PEGASUS-29434
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
And I should see the "In Progress" status for the activity "Complete the Chapter 1 Study Plan" in "Assignments - To Do" page
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
When I Click open under "PostTest" frame to launch the Questions
Then I should be on the "PostTest" page displayed with questions
And I answer activity "CompleteTheChapter1StudyPlan" with behaviour "StudyPlan" of "Homework" type with "partial" answers of "postest"
When I click on Submit the activity "72%" score should be displayed in the screen
And I click on return to course
Then I should be on the "Assignments - To Do" page
When I navigate to "Assignments" tab and selected "Completed" subtab
Then I should be on the "Assignments - Done" page
And I should see the "Completed" status for the activity "Complete the Chapter 1 Study Plan" in "Assignments - Done" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#HSSMyPsychLabProgram
#peg-22241/peg-22244
#PEGASUS-29750/ PEGASUS-29748
#Purpose : Student validating score in gradebook for Basic/Random activity or Student validating score in gradebook for saved activity-Forcefull submission
Scenario: Student validating score in gradebook for Basic/Random activity
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I select "Take the Chapter 1 Exam" in "Gradebook" by "HSSCsSmsStudent"
And I click on cmenu option "View Submissions" of asset "Take the Chapter 1 Exam" in grades tab
Then I should be on the "View Submission" page
And I should see the "100 %" score in the left frame
And I should see Student "scoring 100" as "HSSCsSmsStudent" and displayed like "Gradebook Grade : 100%" in the right frame
And I should be on the "Gradebook" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#HSSMyPsychLabProgram
#peg-22242
#PEGASUS-29749
#Purpose : Student validating score in gradebook for study plan activity
Scenario: Student validating score in gradebook for study plan activity
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I select "Complete the Chapter 1 Study Plan" in "Gradebook" by "HSSCsSmsStudent"
And I click on cmenu option " View Submissions" of asset "Chapter 1 PreTest - PreTest" in grades tab
Then I should be on the "View Submission" page
And I should see the "72 %" score in the left frame
And I should see Student "scoring 100" as "HSSCsSmsStudent" and displayed like "Gradebook Grade : 72%" in the right frame
And I should be on the "Gradebook" page
When I click on cmenu option " View Submissions" of asset "Chapter 1 PostTest - PostTest" in grades tab
Then I should be on the "View Submission" page
And I should see the "72 %" score in the left frame
And I should see Student "scoring 100" as "HSSCsSmsStudent" and displayed like "Gradebook Grade : 72%" in the right frame
And I should be on the "Gradebook" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose: Print tool - Student Accessing a HSS course for testing components
Scenario: Student Accessing a HSS course for testing components
When I enter into "HED Components Test Course" from the Global Home page
Then I should be on the "Course Materials" page

#Purpose: Print tool - Student Accessing Assignment Completed items
Scenario: Student Accessing Assignment Completed items
When I click on "Completed" items
Then I should be on the "Assignments - Done" page

#Purpose: Print tool - Student Accessing View Submission
Scenario: Student Accessing View Submission
When I click on View Submissions of Take the Chapter Exam test
Then I should be on the "View Submission" page

#Purpose: Print tool - Student Accessing submission record
Scenario: Student Accessing submitted record
When I click on submission of Take the Chapter Exam test
Then I should see submitted answers

#Purpose: Print tool - Accessing Print tool
Scenario: Student Accessing Print tool for a submitted record
When I click on print tool
Then I should be on the "Print tool" page

#Purpose: Print tool - Accessing download link of print
Scenario: Student Accessing download link of print
When I click on Download link
Then I should be connected Aspose print tool services

#Purpose: Print tool - Clean up
Scenario: Student closing all windows and signoff
When I close Print and View submission page
Then I should see parent page of Pegasus