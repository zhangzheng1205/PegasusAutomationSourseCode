Feature: PEGASUS-9356: Validate Grades In ECollege Gradebook
					As a ECollege Teacher
					I want to manage gradebook related usecases 
					so that I would validate all the gradebook scenarios are working fine.

#Purpose: Login on ECollege Portal as ECollege Teacher and verify course.
Background: Login as ECollege Teacher on ECollge Portal URL
Given I browsed the ECollege URL as "ECollegeTeacher"
When I login to Pearson TPI Cert as "ECollegeTeacher"
Then I should logged in successfully on ECollege
Given I am on the "Home PSH" page
When I click on "Academics PSH" Option on Home PSH page
Then I should be on the "Academics PSH" page

#Purpose: Validate Grades In ECollege Gradebook.
Scenario: Validate Grades In ECollege Gradebook
When I enter inside "ECollege" course
And I select "GRADEBOOK" option on ECollege Portal
And I select "Item Summary" from dropdown
Then I should verify the grades from Item Summary
When I click on "Exit Course" button from bottom left frame
And I "Signoff" from the "ECollegeTeacher"
Then I should be on the "Pearson TPI Cert| WELCOME" page
  
	
