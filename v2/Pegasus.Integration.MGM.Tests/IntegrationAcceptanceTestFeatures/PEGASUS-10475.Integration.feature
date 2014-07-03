Feature: Pegasus-10475: To Validate the MGM tool deployment in CSAdmin
	As a CsAdmin 
	I want to varify use caese related to MGM tool
	So that I would validate that MGM tool should be availabe in 'Enable' state. 

#Purpose: Open HEDCsAdmin Url and login with HEDCsAdmin.
Background: 
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully
Given I am on the "Course Enrollment" page

#Purpose: Validate Enabled eText Tool is deployed in LTI Tab. 
Scenario: Validate Enabled MGM TooL Deployed in LTI Tab
When I navigate to the "LTI Tools" tab
Then I should be on the "Course Enrollment" page
And I should see the "MathXL" Tool in enabled state
When I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."