Feature: PEGASUS-5121- Write a Schedular Service to process User Details
						As a PSN+
						I want to Make REST POST call
						so that I can see a new user created in domain organization

#Purpose: Create Another Teacher By Radmin
Scenario: Create Another Teacher in Radmin to perform Schedular Service
Given I browsed the login url for "RUMBAAdmin"
When I login to rumba as "RUMBAAdmin"
Then I should be logged in successfully
And I should be on the "Welcome to RADmin" page
When I select the "Create a User Account" tab
Then I should be on the "Create a User Account" page
When I create a "RumbaNonPSNTeacher" user as radmin in "PowerSchool" organization in "DigitalPath"
Then I should see the created "RumbaNonPSNTeacher" in manage frame
When I select the "Search" tab
And I search the "RumbaNonPSNTeacher" user 
Then I should see the created "RumbaNonPSNTeacher" user
When I save the Owner ID of "RumbaNonPSNTeacher" user
And I "Sign Out" from Rumba
Then I should see the "Signed Out" message

#Purpose: Perform Schedular service to process user details
Scenario: Schedular Service to Process User details
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully
And I should be able to receive the status "OK" on posting the "Update" event and acknowledge CMS call messages through its REST endpoints






