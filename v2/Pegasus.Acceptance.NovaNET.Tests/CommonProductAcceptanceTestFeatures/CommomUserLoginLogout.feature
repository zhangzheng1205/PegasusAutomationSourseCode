Feature: CommonLoginLogout
	            As a User
				I want to manage User login and logout related usecases 
				so that I would validate User login and logout scenarios are working fine.

#Purpose:Verify The User Login As WorkspaceAdmin
Scenario: User Login As WorkspaceAdmin
Given I browsed the login url for "NovaNETWsAdmin"
When I login to Pegasus as "NovaNETWsAdmin" in "WorkSpace"
Then I should be logged in successfully

#Purpose:Verify The User Logout As WorkspaceAdmin
Scenario: User Logout As WorkspaceAdmin
When I "Sign out" from the "NovaNETWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As WsTeacher and Navigate to Masterlibrary
Scenario: User Login As WsTeacher and Navigate to Masterlibrary
Given I browsed the login url for "WsTeacher"
When I login to Pegasus as "WsTeacher" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page
When I enter in the "NNMasterLibrary" course as "WsTeacher" from the Global Home page

#Purpose:Verify The User Logout As WsTeacher
Scenario: User LogOut As WsTeacher
When I "Sign out" from the "WsTeacher"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As WsTeacher and Navigate to Container Course
Scenario: User Login As WsTeacher and Navigate to Container Course
Given I browsed the login url for "WsTeacher"
When I login to Pegasus as "WsTeacher" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page
When I enter in the "Container" course as "WsTeacher" from the Global Home page

#Purpose:Verify The User Login As WsTeacher and Navigate to Empty Class Course
Scenario: User Login As WsTeacher and Navigate to Empty Class Course
Given I browsed the login url for "WsTeacher"
When I login to Pegasus as "WsTeacher" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page
When I enter in the "EmptyClass" course as "WsTeacher" from the Global Home page

#Purpose:Verify The User Login As CsAdmin
Scenario: User Login As CsAdmin
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully

#Purpose:Verify The User Logout As CsAdmin
Scenario: User Logout As CsAdmin
When I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As NovaNETCsTeacher and Navigate to Masterlibrary
Scenario: User Login As NovaNETCsTeacher and Navigate to Masterlibrary
Given I browsed the login url for "NovaNETCsTeacher"
When I login to Pegasus as "NovaNETCsTeacher" in "CourseSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page
When I enter in the "NovaNETMasterLibrary" course as "NovaNETCsTeacher" from the Global Home page

#Purpose:Verify The User Logout As NovaNETCsTeacher
Scenario: User Logout As NovaNETCsTeacher
When I "Sign Out" from the "NovaNETCsTeacher"
Then I should see the "Signed Out" message

#Purpose:Verify The User Login As NovaNETCsTeacher
Scenario: User Login As NovaNETCsTeacher
Given I browsed the login url for "NovaNETCsTeacher"
When I login to Pegasus as "NovaNETCsTeacher" in "CourseSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page

#Purpose:Verify The User Login As NovaNETCsStudent
Scenario: User Login As NovaNETCsStudent
Given I browsed the login url for "NovaNETCsStudent"
When I login to Pegasus as "NovaNETCsStudent" in "CourseSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page 
When I enter in the "NovaNETMasterLibrary" course as "NovaNETCsStudent" from the Global Home page

#Purpose:Verify The User Logout As NovaNETCsStudent
Scenario: User Logout As NovaNETCsStudent
When I "Sign out" from the "NovaNETCsStudent"
Then I should see the "Signed Out" message