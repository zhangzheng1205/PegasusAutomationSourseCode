﻿Feature: ContineTeacher
				As a Contineo Teacher
				I want to manage all the Contineo Teacher related usecases 
				so that I would validate all the Contineo Teacher scenarios are working fine.

#Purpose: To Verify Contineo Teacher SSO to PSN+
Scenario: SSO to PSNPlus as Contineo Teacher
When I click on Applications icon as "ContineoTeacher"
Then I should see the Pearson Courses link displayed in the Applications Drawer Panel
When I click on Pearson Courses link
Then I should be on the "Central Admin" Page
When I click on 'SuccessNet Plus' link under Learning systems
Then I should be on the "Home" page