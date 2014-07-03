Feature: PEGASUS-8525: Create New Course in ECollege Portal.
			As a ECollege Admin 
			I want To Login on ECollege Portal URL 
			So That I would Create class and enroll into Term.

#Purpose: Login on ECollege Portal as ECollege Admin.
Background: Login as ECollege Admin on ECollge Portal URL
Given I browsed the ECollege URL as "ECollegeAdmin"
When I login to Pearson TPI Cert as "ECollegeAdmin"
Then I should logged in successfully on ECollege

#Purpose: Craete New ECollege Course on ECollege Portal.
Scenario: Create ECollege course  
Given I am on the "Home PSH" page
When I select "AdministrationPages" link
Then I should be on the "Administration Pages" page
When I select "Single Course Request" link on Administration Pages 
And I create a new "ECollege" Course
Then I should see the "Single Course Request - Confirmation" message
When I click on the Exit button
And I "Signoff" from the "ECollegeAdmin"
Then I should be on the "Pearson TPI Cert| WELCOME" page