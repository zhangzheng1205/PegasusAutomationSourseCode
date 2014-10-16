Feature: CourseSpaceStudent
	                As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

# NovaNETMasterLibrary Course
#Purpose : To Lauch Activity by the Student in CourseSpace
Scenario: Lauch Activity by CS Student
When I navigate to "Content" tab
Then I should be on the "Content" page
When I open the activity named as "NNTest" in "ViewAllContent" tab
Then I should see the activity launched successfully

# NovaNETMasterLibrary Course
#Purpose : To Activity Submission by the Student in CourseSpace
Scenario: Activity Submission by CS Student
When I navigate to "Content" tab
Then I should be on the "Content" page
When I open the activity named as "NNTest" in "ViewAllContent" tab
And I submit the activity
Then I should see the status of "NNTest" assets as "Passed"

# NovaNETMasterLibrary Course
#Purpose : To View Activity Score by the Student in CourseSpace
Scenario: View Activity Score by CS Student
When I navigate to "Grades" tab
And I select 'Grades' subtab
Then I should be on the "Gradebook" page
Then I should see the grade "100" of the submitted activity named as "NNTest"

# NovaNETMasterLibrary Course
#Purpose : Student views the View submission from Gradebook
#Usecase ID : NN_PWF_538
Scenario: Student views the View submission from Gradebook by CS Student
When I navigate to "Grades" tab
And I select 'Grades' subtab
Then I should be on the "Gradebook" page
When I click the "NNTest" activity of cmneu "View Submission" 
Then I should see the grade "100" in view submission page
When I close the "View Submission" window