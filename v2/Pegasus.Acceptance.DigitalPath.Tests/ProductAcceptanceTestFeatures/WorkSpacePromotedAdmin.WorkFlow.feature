Feature: WorkSpacePromotedAdmin
	                As a WorkSpace Promoted Admin 
					I want to manage all the work space promoted admin related usecases 
					so that I would validate all the promoted admin scenarios are working fine.


#Purpose : Functionality to verify InCorrect password 
Scenario: Functionality to verify password reset
Given I browsed the login url for "DPWorkSpacePramotedAdmin"
When I login to Pegasus as "DPWorkSpacePramotedAdmin" with "Incorrect" password
Then I should see the successfull message "The username or password you entered is incorrect"
When I login to Pegasus as "DPWorkSpacePramotedAdmin" with "Correct" password
Then I should be on the "Update My Pearson account" page
