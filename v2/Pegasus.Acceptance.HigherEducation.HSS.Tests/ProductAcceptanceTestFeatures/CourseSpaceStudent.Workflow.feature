Feature: CourseSpaceStudent Submission
	                 As a CS Student 
					I want to manage all the coursespace student Submission related usecases 
					so that I would validate all the coursespace student Submission scenarios are working fine.

#Purpose : Student launching eText
#Test case ID : peg-22168
Scenario: Student launching eText
When I Click on eText link
Then I should be on the "Pearson eText Sign In Page" page
And I close eText Window

#Purpose : Basic/Random activity launch from Course Calendar and student abruptly closes the presentation
#Test case ID : peg-22160
Scenario: Student abruptly closes the presentation
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Take the Chapter 1 Exam" in "Course Materials" by "HSSCsSmsStudent"
Then I should be on the "Exam" page displayed with questions
When I forcibly close the "Exam" window abdruplty
Then I should see the "In Progress" status for the activity "Take the Chapter 1 Exam"