Feature: PEGASUS-8526: Creation of New Student in ECollege Portal
	As a ECollege Admin
	I want to login in ECollege portal
	so that I would create Student user type.

#Purpose: Open ECollege Admin Url.
Background: Login as ECollege Admin on ECollge Portal URL
Given I browsed the ECollege URL as "ECollegeAdmin"
When I login to Pearson TPI Cert as "ECollegeAdmin"
Then I should logged in successfully on ECollege
		
#Purpose: Creation of ECollege Student.
Scenario: Create Student by ECollege admin
Given I am on the "Home PSH" page
When I select "AdministrationPages" link
Then I should be on the "Administration Pages" page
When I select the "Manage Users" tab on global navigation frame
And I select "Create New User" link on Administration Pages 
And I create a new "ECollegeStudent" user
Then I should see the "Your new user has been created." message
When I click on the Exit button
And I "Signoff" from the "ECollegeAdmin"
Then I should be on the "Pearson TPI Cert| WELCOME" page


