Feature: CourseSpaceStudent
	                As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose:Open the CSAdmin url
Background: 
Given I browsed the login url for "NovaNETCsStudent"
When I login to Pegasus as "NovaNETCsStudent" in "CourseSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page 
When I enter in the "NovaNETMasterLibrary" course as "NovaNETCsStudent" from the Global Home page
Then I should be on the "Overview" page

#Purpose : To Lauch Activity by the Student in CourseSpace
Scenario: Lauch Activity by CS Student
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I open the activity named as "Test" in "ViewAllContent" tab
Then I should see the activity launched successfully
When I "Sign out" from the "NovaNETCsStudent"
Then I should see the "Signed Out" message

#Purpose : To Activity Submission by the Student in CourseSpace
Scenario: Activity Submission by CS Student
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I open the activity named as "Test" in "ViewAllContent" tab
And I submit the activity
Then I should see the status of "Test" assets as "Passed"
When I "Sign out" from the "NovaNETCsStudent"
Then I should see the "Signed Out" message

#Purpose : To View Activity Score by the Student in CourseSpace
Scenario: View Activity Score by CS Student
When I navigate to the "Content" tab
Then I should be on the "Content" page
And I navigate to the "Grades" tab
Then I should see the grade "100" of the submitted activity named as "Test"
When I "Sign out" from the "NovaNETCsStudent"
Then I should see the "Signed Out" message

#Purpose : Student views the View submission from Gradebook
#Usecase ID : NN_PWF_538
Scenario: Student views the View submission from Gradebook by CS Student
When I navigate to the "Grades" tab
Then I Should be on the "Gradebook" page
When I click the "Test" activity of cmneu "View Submission" 
Then I should see the grade "100" in view submission page
When I close the "View Submission" window
And I "Sign out" from the "NovaNETCsStudent"
Then I should see the "Signed Out" message