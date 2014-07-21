Feature: PEGASUS-26909
	As a demo account user
	I want to mangae demo user related usecases
	So that I would validate display of welcome banner and welcome message

#Purpose: Dispaly of welcome banner and welcome message to demo account user
Scenario: Display of Welcome banner uploaded in the Demo product for which the user registered for
Given 3 "DigitalPathDemo" Product created with same access code and licencesed in a organsation
When I browse the login url for "DPDemoUser"
And I login to Pegasus as "DPDemoUser" in "CourseSpace"
Then I can see display of 3 welcome banner image and welcome message one by one
When I "Sign out" from the "DPDemoUser"
Then I should see the "Signed Out" message
