Feature: ContineStudent
				As a Contineo Student
				I want to manage all the Contineo Student related usecases 
				so that I would validate all the Contineo Student scenarios are working fine.

#Purpose: To Verify Contineo Student SSO to PSN+
Scenario: SSO to PSNPlus as Contineo Student
When I click on the Pearson Courses link
Then I should be on the "Pearson EasyBridge" Page
When I click on 'SuccessNet Plus' link under Learning systems
Then I should be on the "Overview" page