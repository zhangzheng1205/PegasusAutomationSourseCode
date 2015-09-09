Feature: CommonSSRSUserLoginFeature
	As a SSRS Admin User
				I want to manage all the SSRS User related usecases 
				so that I would validate all the SSRS User scenarios are working fine.

#Purpose: Verify User login as SSRSReportsAdmin
Scenario: User Login As SSRSReportAdmin
Given I browse the login URL for "SSRSReportAdmin"
When I log into the SSRS as "SSRSReportAdmin"
Then I should be on the 'Home' Page