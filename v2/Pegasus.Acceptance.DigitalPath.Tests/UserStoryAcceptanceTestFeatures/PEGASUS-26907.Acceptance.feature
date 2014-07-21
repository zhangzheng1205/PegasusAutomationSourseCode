Feature: PEGASUS-26907
	As a demo account user
	I want to mangae demo user related usecases
	So that I would validate display of welcome message

#Purpose: Dispaly of welcome message to demo account user
Scenario: Display of welcome message to demo User when demo product is licensed with same organization multiple times.
Given One "DigitalPathDemo" Product should be licensed 3 times with same organization
When I browse the login url for "DPDemoUser"
And I login to Pegasus as "DPDemoUser" in "CourseSpace"
Then Only "1" Welcome message should display with "Enter" button instead of Next button.
When I "Sign out" from the "DPDemoUser"
Then I should see the "Signed Out" message
