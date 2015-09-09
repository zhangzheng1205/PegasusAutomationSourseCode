Feature: CommonSSRSUserReportingFeature
	As a SSRS Admin User
				I want to manage all the SSRS User related usecases 
				so that I would validate all the SSRS User scenarios are working fine.

#Purpose: Verify Functionality of MyLabs Folder
Scenario: SSRSReportAdmin verifies functionality of MyLabs Reports folder 
When I am on the 'Home' Page
Then I should see the 'MyLabs' link
When I click the 'MyLabs' link
Then I should be on the 'MyLabs' Page

#Purpose: Generate the MIL3xUsersReport
Scenario: SSRSReportAdmin generates the MIL3xUsersReport
When I click the 'MIL3xUsersReport' link
Then I should be on the 'MIL3xUsersReport' Page
When I generate the 'MIL3xUsersReport' report
Then I should see 'MIL3xUsersReport' report generated successfully

#Purpose: Generate the HED5xPMCUserDetails Report
Scenario: SSRSReportAdmin generates the HED5xPMCUserDetails Report
When I click the 'HED5xPMCUserDetails' link
Then I should be on the 'HED5xPMCUserDetails' Page
And I generate the 'HED5xPMCUserDetails' report successfully

#Purpose: Generate the WVU Report
Scenario: SSRSReportAdmin generates the WVU Report
When I click the 'WVU Report' link
Then I should be on the 'WVU Report' Page
When I generate the 'WVU Report' report
Then I should see 'WVU Report' report generated successfully

#Purpose: Navigate back to MyLabs Page to generate a different report
Scenario: SSRSReportsAdmin navigates back to MyLabs page
When I click the 'MyLabs' link
Then I should be on the 'MyLabs' Page
