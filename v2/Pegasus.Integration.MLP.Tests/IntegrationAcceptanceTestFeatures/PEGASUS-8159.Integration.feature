Feature: PEGASUS-8159: ECollege Enroll Student in Course
	As a ECollege Admin 
	I want to Login On ECollge Portal 
	So that I would enroll Student into ECollege Course. 

#Purpose: Login on ECollege Portal as ECollege Admin.
Background: Login as ECollege Admin on ECollge Portal URL
Given I browsed the ECollege URL as "ECollegeAdmin"
When I login to Pearson TPI Cert as "ECollegeAdmin"
Then I should logged in successfully on ECollege
Given I am on the "Home PSH" page
When I select "AdministrationPages" link
Then I should be on the "Administration Pages" page

#Purpose: Enroll ECollege Student into Course.
Scenario: Enroll ECollege Student into Course
When I select the "Manage Users" tab on global navigation frame
And I select "Enroll User(s)" link on Administration Pages 
When I enroll "ECollegeStudent" to "ECollege" course of term
Then I should see the " Enroll User(s) Confirmation" message
When I click on the Exit button
And I "Signoff" from the "ECollegeAdmin"
Then I should be on the "Pearson TPI Cert| WELCOME" page