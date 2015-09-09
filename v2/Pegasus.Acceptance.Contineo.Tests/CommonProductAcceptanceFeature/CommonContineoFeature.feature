Feature: CommonLoginLogOut
				As a Contineo User
				I want to manage all the Contineo User related usecases 
				so that I would validate all the Contineo User scenarios are working fine.

#Purpose: Verify The User Login As PowerSchool Teacher
Scenario: Login as Contineo Teacher
Given I browsed the login url for "ContineoTeacher"
When I login to PowerSchool as "ContineoTeacher"
Then I should be logged in successfully

#Purpose:Verify The User LogOut As Contineo Teacher from PSNPlus
Scenario: User LogOut As ContineoTeacher from PSNPlus
When I 'Sign Out' from PSNPlus as 'ContineoTeacher'
Then I should see the "Pearson Signed Out" page

#Purpose:Verify The User LogOut As Contineo Teacher from Central Admin
Scenario: User LogOut As ContineoTeacher from Central Admin
When I 'Sign Out' from Central Admin as "ContineoTeacher"
Then I should see the "Pearson Signed Out" page

#Purpose:Verify The User LogOut As Contineo Teacher from Power School
Scenario: User LogOut As ContineoTeacher from Power School
When I 'Sign Out' from Power School as "ContineoTeacher"
Then I should see the "PowerTeacher" page

#Purpose: Verify The User Login As PowerSchool Student
Scenario: Login as Contineo Student
Given I browsed the login url for "ContineoStudent"
When I login to PowerSchool as "ContineoStudent"
Then I should be logged in successfully

#Purpose:Verify The User LogOut As Contineo Student from PSNPlus
Scenario: User LogOut As ContineoStudent from PSNPlus
When I 'Sign Out' from PSNPlus as 'ContineoStudent'
Then I should see the "Pearson Signed Out" page

#Purpose:Verify The User LogOut As Contineo Student from Central Admin
Scenario: User LogOut As ContineoStudent from Central Admin
When I 'Sign Out' from Central Admin as "ContineoStudent"
Then I should see the "Pearson Signed Out" page

#Purpose:Verify The User LogOut As Contineo Student from Power School
Scenario: User LogOut As ContineoStudent from Power School
When I 'Sign Out' from Power School as "ContineoStudent"
Then I should see the "Student and Parent Sign In" page
