Feature: PEGASUS-3789- Make Rest Post Call to initiate create class event
						As a PSN+
						I want to Make REST POST call
						so that I can see a new class created in domain organization.

Background: 
#Purpose : Open Rumba url
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully

#Purpose: Perform REST POST call to initiate create class event
Scenario: Make REST POST call to raise create class event
Given I send the raw CMS message data from the CAT reaches to PSN
Then I should be able to receive the status "OK" on posting the "Create" class event and acknowledge CMS call messages through its REST endpoints
	