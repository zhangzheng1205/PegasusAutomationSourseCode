Feature: PEGASUS-26905
	As a demo account user
	I want to mangae demo user related usecases
	So that I would validate display of welcome message

#Purpose: Dispaly of welcome message to demo account user
Scenario: Display of welcome message to demo User when one product is licensed with organization 
Given One "DigitalPathDemo" Product should be licensed 1 times with same organization
When I browse the login url for "DPDemoUser"
And I login to Pegasus as "DPDemoUser" in "CourseSpace"
Then I should see display of welcome message for "DigitalPathDemo"
When I "Sign out" from the "DPDemoUser"
Then I should see the "Signed Out" message
