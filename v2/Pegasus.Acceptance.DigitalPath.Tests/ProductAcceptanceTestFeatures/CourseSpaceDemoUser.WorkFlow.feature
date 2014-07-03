Feature: CourseSpaceDemoUser
	As a Demo User in Pegasus
	I want to explore features of Pegasus

#Purpose: Register as NovaNET Demo User
Scenario: Register as a Demo User 
Given I browsed the url for "RegisterYourDemoAccount" Page
When I register account as "DPDemoUser" using my demo access code 
Then I should see the successful message box "Registration successful."


Scenario: Display of welcome message to demo User when one product is licensed with organization 
Given I browsed the login url for "DPDemoUser"
When I login to Pegasus as "DPDemoUser" in "CourseSpace"
Then I should see display of welcome message for "DigitalPathDemo"
