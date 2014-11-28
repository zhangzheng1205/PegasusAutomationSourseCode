Feature: CommonUserLoginLogOut
				As a Pegasus User
				I want to manage all the Pegasus User related usecases 
				so that I would validate all the Pegasus User scenarios are working fine.

#Purpose:Verify The User Login As CourseSpaceProgramAdmin
Scenario: User Login As HSSProgramAdmin and Navigate To HSSMyPsychLabProgram Course
Given I browsed the login url for "HSSProgramAdmin"
When I logged into the Pegasus as "HSSProgramAdmin" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSProgramAdmin"

#Purpose: Verify The User Login As CourseSpaceSMSInstructor To HedMyPsychLabProgram Course
Scenario: User Login As HSSCsSMSInstructor and navigate to HSSMyPsychLabProgram Course
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsInstructor"

#Purpose: Verify The User Login As CourseSpaceSMSStudent
Scenario: User Login As HSSCsSMSStudent 
Given I browsed the login url for "HSSCsSmsStudent"
When I logged into the Pegasus as "HSSCsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Verify The User Login As CourseSpaceSMSStudent To HedMyPsychLabProgram Course
Scenario: User Login As HSSCsSMSStudent and navigate to HSSMyPsychLabProgram Course
Given I browsed the login url for "HSSCsSmsStudent"
When I logged into the Pegasus as "HSSCsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsStudent"

#Purpose: Login as Zero Score SMS Student 
Scenario: User login as HSSCsSMSStudent student to score zero percent
Given I browsed the login url for "HSSCsSmsStudent"
When I login as "scoring 0" into the pegasus as "HSSCsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Login as Zero Score SMS Student and navigate to HSSMyPsychLabProgram
Scenario: User login as HSSCsSMSStudent student to score zero percent and navigate to instructor course
Given I browsed the login url for "HSSCsSmsStudent"
When I login as "scoring 0" into the pegasus as "HSSCsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsStudent"

#Purpose:Verify The User LogOut As HSSCourseSpaceSMSInstructor
Scenario: User LogOut As HSSCsSMSInstructor
When I "Sign out" from the "HSSCsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User LogOut As HSSCourseSpaceSMSStudent
Scenario: User LogOut As HSSCsSMSStudent
When I "Sign out" from the "HSSCsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User LogOut As HSSProgramAdmin
Scenario: User LogOut As HSSCourseSpaceAdmin
When I "Sign out" from the "HSSProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."


#Purpose: Verify The User Login As CourseSpaceSMSInstructor 
Scenario: User Login As HSSCsSMSInstructor
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page




