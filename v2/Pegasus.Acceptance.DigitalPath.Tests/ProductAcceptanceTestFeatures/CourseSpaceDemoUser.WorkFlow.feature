Feature: CourseSpaceDemoUser
	As a Demo User in Pegasus
	I want to explore features of Pegasus

#Purpose: Register as Digital path Demo User
Scenario: Register as a Demo User 
Given I browsed the url for "RegisterYourDemoAccount" Page
When I register account as "DPDemoUser" using my demo access code 
Then I should see the successful message box "Registration successful."









