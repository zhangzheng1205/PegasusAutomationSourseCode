Feature: SMS
	CommonUserScenarios
	            As a User
				I want to manage all the SMS User related usecases 
				so that I would validate all the SMS scenarios are working fine.


#Purpose: Login as SMS Instructor and Navigate to MyITLabOffice2013Section
Scenario: User Login as SMS Instructor and Navigate MyITLab Course
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I am on the "Global Home" page


#Purpose: Logout as SMS Instructor
Scenario: User Logout as SMS Instructor
Given I am on the "Global Home" page
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Login as SMS Student
Scenario: User Login as SMS Student
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
#Then I should logged in successfully
Then I am on the "Global Home" page

#Purpose: Logout as SMS Student
Scenario: User Logout as SMS Student
Given I am on the "Global Home" page
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As TA Instructor
Scenario: User Login As CsTAInstructor
Given I browsed the login url for "HedTeacherAssistant"
When I logged into the Pegasus as "HedTeacherAssistant" in "CourseSpace"
#Then I should logged in successfully
Then I am on the "Global Home" page

#Purpose:Verify The User LogOut As CsTAInstructor
Scenario: User LogOut As CsTAInstructor
When I "Sign out" from the "HedTeacherAssistant"
Then I should see the successfull message "You have been signed out of the application."