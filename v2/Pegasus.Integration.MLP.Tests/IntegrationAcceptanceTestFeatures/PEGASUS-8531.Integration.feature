Feature: PEGASUS-8531: Launching ECollege Course Through ECollege Student
	As ECollege Student 
	I want to login on ECollege Portal
	So that I would launch ECollege integrated course.

#Purpose: Login on ECollege Portal as ECollege Student.
Background: Login as ECollege Student on ECollege Portal URL
Given I browsed the ECollege URL as "ECollegeStudent"
When I login to Pearson TPI Cert as "ECollegeStudent"
Then I should logged in successfully on ECollege

#Purpose: Launching ECollege Course through ECollege Student.  
Scenario: Launching ECollege Course through ECollege Student
Given I am on the "Home PSH" page
When I click on "Academics PSH" Option on Home PSH page
Then I should be on the "Academics PSH" page
When I enter inside "ECollege" course
And I click on Enter Course Link option
And I Accept License Agreement on End-User License Agreement page
Then I should be on the "Today's View" launched Pegasus popup window
When I close "Today's View" presentation window
And I click on "Exit Course" button from bottom left frame
And I "Signoff" from the "ECollegeStudent"
Then I should be on the "Pearson TPI Cert| WELCOME" page
