Feature: CommonUserLogin
	            As a MMND User
				I want to manage all the MMND User related usecases 
				so that I would validate all the MMND User scenarios are working fine.

#Purpose:Verify The User Login As MMNDInstructor
Scenario: User Login As MMNDInstructor
Given I browsed the URL of "MMNDInstructor"
When I login to MMND Cert as "MMNDInstructor"
Then I should be logged in successfully as "MMNDInstructor"
Given I am on the "MyLab & Mastering | Pearson" page
When I navigate inside "MMNDNonCoOrdinate" course in "MMNDInstructor"
Then I should be on the "Course Home" page

#Purpose:Verify The User Login As MMNDStudent
Scenario: User Login As MMNDStudent
Given I browsed the URL of "MMNDStudent"
When I login to MMND Cert as "MMNDStudent"
Then I should be logged in successfully as "MMNDStudent"
Given I am on the "MyLab & Mastering | Pearson" page
When I navigate inside "MMNDNonCoOrdinate" course in "MMNDStudent"
Then I should be on the "Course Home" page

#Purpose:Verify The User LogOut As MMNDInstructor
Scenario: User LogOut As MMNDInstructor
When I log out from the application as "MMNDInstructor"
Then I should see the application logout successfully

#Purpose:Verify The User LogOut As MMNDStudent
Scenario: User LogOut As MMNDStudent
When I log out from the application
Then I should see the application logout successfully
