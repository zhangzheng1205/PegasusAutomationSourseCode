Feature: PEGASUS-3784- Create A Domain Organization
						As a CS Admin 
						I want to Create a Domain Organization 
						so that I would create Power School Users in it.

#Purpose: Open CS Url
Background: 
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully

#Purpose: Creation of School Level Domain Organization
Scenario: Ability of Pearson admin to set domain flag in the Create Organization popup at the School level
Given I am on the 'Organization Management' page
When I search the "District" level Organization in "DigitalPath"
Then I should see the "District" level organization name in "DigitalPath"
When I create the "PowerSchool" level organization in "DigitalPath"
Then I should see the successfull message "Organization created successfully."
When I search the "PowerSchool" level Organization in "DigitalPath"
Then I should see the "PowerSchool" level organization name in "DigitalPath"
When I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."
