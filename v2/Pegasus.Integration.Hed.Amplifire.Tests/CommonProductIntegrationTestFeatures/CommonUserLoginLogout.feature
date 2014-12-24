Feature: CommonUserLoginLogOut
				As a Pegasus User
				I want to manage all the Pegasus User related usecases 
				so that I would validate all the Pegasus User scenarios are working fine.


#Purpose: Login as HED SMS Instructor
Scenario: User Login as CourseSpace SMS Instructor
Given I browsed the login url for "AmpCsSmsInstructor"
When  I login to Pegasus as "AmpCsSmsInstructor" in "CourseSpace"
Then  I should be logged in successfully
Given I am on the "Global Home" page

#Purpose: Login as HED Program Admin and Navigate to  ProgramCourse
Scenario: User Login CourseSpace Program Admin and Navigate ProgramCourse Course
Given I browsed the login url for "AmpProgramAdmin"
When I logged into the Pegasus as "AmpProgramAdmin" in "CourseSpace"
Then  I should be logged in successfully
Given I am on the "Global Home" page
When I enter in the "AmpProgramCourse" course from the Global Home page as "AmpProgramAdmin"
Then I should be on the "Program Administration" page
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "AmpProgramCourse" first section
And I click the "Enter Section as Instructor"

#Purpose: Login as SMS Student
Scenario: User Login As CsSMSStudent Navigate To InstructorCourse
Given I browsed the login url for "AmpCsSmsStudent"
When I logged into the Pegasus as "AmpCsSmsStudent" in "CourseSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page


#Purpose: Logout as SMS Instructor
Scenario: User Logout as SMS Instructor
When I "Sign out" from the "AmpCsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Logout as Program Admin
Scenario: User Logout as Program Admin
When I "Sign out" from the "AmpProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Logout as SMS Student
Scenario: User Logout as SMS Student
When I "Sign out" from the "AmpCsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Login as WSInstructor
Scenario: User Login As WSInstructor
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page

#Purpose: Open Ws Url and Logout as Workspace Instructor
Scenario: User Logout as Workspace Teacher
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."




