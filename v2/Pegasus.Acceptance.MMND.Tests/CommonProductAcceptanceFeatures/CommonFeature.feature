Feature: CommonUserScenarios
	            As a User
				I want to manage all the MMND User related usecases 
				so that I would validate all the MMND scenarios are working fine.

#Purpose: Open URL for Admin tool page
Scenario: User sign in as Admin in Ecollege admin pages
Given I browsed the URL of "MMNDAdmin" 
When I login to MMND Cert as "MMNDAdmin"
Then I should be logged in successfully as "MMNDAdmin"
And I should be on the "Administrative Pages" page

Scenario: User Sign off as Admin in Ecollege admin pages
When I log out from the application as "MMNDAdmin"
Then I should be on the "Academics PSH" page

Scenario: User Sign in as MMND Instructor
Given I browsed the URL of "MMNDInstructor"
When I login to MMND Cert as "MMNDInstructor"
Then I should be logged in successfully as "MMNDInstructor"

Scenario: User Sign out as MMND Instructor
When I log out from the application as "MMNDInstructor"
Then I should see the application logout successfully