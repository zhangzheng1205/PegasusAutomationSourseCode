Feature: CourseSpaceStudent
	                As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.


#Purpose : To Lauch Activity by the Student in CourseSpace
Scenario: Lauch Activity by CS Student
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I open the activity named as "Test" in "ViewAllContent" tab
Then I should see the activity launched successfully

#Purpose : To Activity Submission by the Student in CourseSpace
Scenario: Activity Submission by CS Student
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I open the activity named as "Test" in "ViewAllContent" tab
And I submit the activity
Then I should see the status of "Test" assets as "Passed"

#Purpose : To View Activity Score by the Student in CourseSpace
Scenario: View Activity Score by CS Student
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I navigate to the "Grades" tab
And I select 'Grades' subtab
Then I should see the grade "100" of the submitted activity named as "Test"

#Purpose : Student views the View submission from Gradebook
#Usecase ID : NN_PWF_538
Scenario: Student views the View submission from Gradebook by CS Student
When I navigate to the "Grades" tab
And I select 'Grades' subtab
And I click the "Test" activity of cmneu "View Submission" 
Then I should see the grade "100" in view submission page
When I close the "View Submission" window