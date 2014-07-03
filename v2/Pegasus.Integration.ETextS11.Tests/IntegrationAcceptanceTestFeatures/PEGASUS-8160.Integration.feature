Feature: Pegasus-8160: To Validate the Tool Deployment
	As a HEDCSAdmin 
	I want to varify use caese related to e text tool
	So that I would validate that eTetx tool should be availabe in 'Enable' state. 

#Purpose: Open HEDCsAdmin Url and login with HEDCsAdmin.
Background: 
Given I browsed the login url for "HedCsAdmin"
When I login to Pegasus as "HedCsAdmin" in "CourseSpace"
Then I should be logged in successfully
Given I am on the "Course Enrollment" page

#Purpose: Validate Enabled eText Tool is deployed in LTI Tab. 
Scenario: Validate Enabled ETextTooL Deployed in LTI Tab
When I navigate to the "LTI Tools" tab
Then I should be on the "Course Enrollment" page
And I should see the "eText" Tool in enabled state
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."


