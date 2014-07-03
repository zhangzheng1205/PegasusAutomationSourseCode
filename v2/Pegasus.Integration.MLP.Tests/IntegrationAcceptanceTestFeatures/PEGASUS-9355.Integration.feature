Feature: PEGASUS-9355: Submit Activity in Pegasus by ECollege Student	
					As a ECollege Student 
					I want to launch the activity related usecases 
					so that I would validate all the activity launch student scenarios are working fine.

#Purpose: Login on ECollege Portal as ECollege Teacher and click on Course.
Background: Login as ECollege Teacher on ECollge Portal URL
Given I browsed the ECollege URL as "ECollegeStudent"
When I login to Pearson TPI Cert as "ECollegeStudent"
Then I should logged in successfully on ECollege
Given I am on the "Home PSH" page
When I click on "Academics PSH" Option on Home PSH page
Then I should be on the "Academics PSH" page
When I enter inside "ECollege" course
And I click on Enter Course Link option
Then I should be on the "Today's View" launched Pegasus popup window
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page

#Purpose: Activity Submission by ECollege Student
Scenario: Activity Submission by ECollege Student
When  I open the Activity 
When I submit the activity
Then I should see the activity submitted successfully for grading
When I close "Course Materials" presentation window
And I click on "Exit Course" button from bottom left frame
And I "Signoff" from the "ECollegeStudent"
Then I should be on the "Pearson TPI Cert| WELCOME" page