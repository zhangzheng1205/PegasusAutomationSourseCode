Feature: CommonLoginLogout
	            As a User
				I want to manage User login and logout related usecases 
				so that I would validate User login and logout scenarios are working fine.

#Purpose:Verify The User Login As WorkspaceAdmin
Scenario: User Login As WorkspaceAdmin
Given I browsed the login url for "HedWsAdmin"
When I logged into the Pegasus as "HedWsAdmin" in "WorkSpace"
Then I should logged in successfully

#Purpose:Verify The User LogOut As WorkSpaceAdmin
Scenario: User LogOut As WorkSpaceAdmin
When I "Sign out" from the "HedWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As HedWsInstrucor and Navigate to Master Course
Scenario: User Login As HedWsInstrucor and Navigate to MySpanishLabMaster Course
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
And I should be on the "Global Home" page
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"

#Purpose:Verify The User Login As HedWsInstrucor and Navigate to Empty Course
Scenario: User Login As HedWsInstrucor and Navigate to HedEmptyClass Course
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
And I should be on the "Global Home" page
When I enter in the "HedEmptyClass" from the Global Home page as "HedWsInstructor"

#Purpose:Verify The User Logout As HedWsInstrucor
Scenario: User Logout As HedWsInstrucor
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As HedCsAdmin
Scenario: User Login As HedCsAdmin
Given I browsed the login url for "HedCsAdmin"
When I logged into the Pegasus as "HedCsAdmin" in "CourseSpace"
Then I should logged in successfully

#Purpose:Verify The User Logout As HedCsAdmin
Scenario: User Logout As HedCsAdmin
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As CsSmsInstructor
Scenario: User Login As CsSmsInstructor
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose:Verify The User Login As CsSmsInstructor and Navigate to MyTestBankCourse Course
Scenario: User Login As CsSmsInstructor and Navigate to MyTestBankCourse Course
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyTestBankCourse" from the Global Home page as "CsSmsInstructor"

#Purpose:Verify The User Login As CsSmsInstructor and Navigate to MyTestInstructorCourse
Scenario: User Login As CsSmsInstructor and Navigate to MyTestInstructorCourse
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyTestInstructorCourse" from the Global Home page as "CsSmsInstructor"

#Purpose:Verify The User Logout As CsSmsInstructor
Scenario: User Logout As CsSmsInstructor
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As CsSmsStudent and Navigate to MyTestInstructorCourse
Scenario: User Login As CsSmsStudent and Navigate to MyTestInstructorCourse
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyTestInstructorCourse" from the Global Home page as "CsSmsStudent"

#Purpose:Verify The User Login As CsSmsStudent
Scenario: User Login As CsSmsStudent
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose:Verify The User Logout As CsSmsStudent
Scenario: User Logout As CsSmsStudent
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

