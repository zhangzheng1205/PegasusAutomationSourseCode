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

#Purpose : Basic/Random activity launch from Course Calendar and student abruptly closes the presentation
#Test case ID : peg-22160
Scenario: Student abruptly closes the presentation
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Take the Chapter 1 Exam" in "Course Materials" by "HSSCsSmsStudent"
Then I should be on the "Exam" page displayed with questions
When I forcibly close the Exam window abdruplty
Then I should see the "In Progress" status for the activity "Take the Chapter 1 Exam"

#Purpose : Basic/Random activity from Course Calendar and student perform Save for later
#Test case ID : peg-22156
#PEGASUS-29429
Scenario: Student answers the questions and perform Save for later
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Take the Chapter 1 Exam" in "Course Materials" by "HSSCsSmsStudent"
Then I should be on the "Exam" page displayed with questions
And I answer activity "TakeTheChapter1Exam" with behaviour "BasicRandom" of "Homework" type with "partial" answers
When I click on save for later button
Then I should see the "In Progress" status for the activity "Take the Chapter 1 Exam"

#Purpose : Basic/Random activity from Course Calendar and student scoring 100%
#Test case ID : peg-22151
#PEGASUS-29428
Scenario: Student answers the questions and scores 100%
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

#Purpose : Basic/Random activity from Course Calendar and student scoring 0%
#Test case ID : peg-22146
#PEGASUS-29427
Scenario: Student answers the questions and scores 0%
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

#Purpose : Student submits the Non gradable assets from the TO DO tab
#Test case ID : peg-22150
#Products : HSS
Scenario: Student submits the Non gradable assets from the TO DO tab
When I navigate to "Assignments" tab and selected "To Do" subtab
Then I should be on the "Assignments - To Do" page
When I launch "Review the Chapter 1 Learning Objectives" asset
Then I should be on the "Learning Objectives - Chapter 1" page
When I close the "Learning Objectives - Chapter 1" window
Then I should see "Viewed" status for the asset
Then I should see "Review the Chapter 1 Learning Objectives" in the 'Completed' tab
