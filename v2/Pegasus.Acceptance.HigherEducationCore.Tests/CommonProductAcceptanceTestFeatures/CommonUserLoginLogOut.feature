Feature: CommonUserLoginLogOut
				As a Pegasus User
				I want to manage all the Pegasus User related usecases 
				so that I would validate all the Pegasus User scenarios are working fine.

#Purpose:Verify The User Login As CTGPublisherAdmin
Scenario: User Login As CTGPublisherAdmin
Given I browsed the login url for "HEDCSCTGPPublisherAdmin"
When I logged into the Pegasus as "HEDCSCTGPPublisherAdmin" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Workspaces" page

#Purpose:Verify The User Login As HedCoreAcceptanceInstructor Navigate to HedCoreAcceptanceProgramCourse
Scenario: User Login As HedCoreAcceptanceInstructor Navigate to HedCoreAcceptanceProgramCourse
Given I browsed the login url for "HedCoreAcceptanceInstructor"
When I logged into the Pegasus as "HedCoreAcceptanceInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HedCoreAcceptanceProgramCourse" from the Global Home page as "HedCoreAcceptanceInstructor"

#Purpose:Verify The User Login As HedCoreAcceptanceInstructor Navigate to HedCoreAcceptanceInstructorCourse
Scenario: User Login As HedCoreAcceptanceInstructor Navigate to HedCoreAcceptanceInstructorCourse
Given I browsed the login url for "HedCoreAcceptanceInstructor"
When I logged into the Pegasus as "HedCoreAcceptanceInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"

#Purpose:Verify The User LogOut As HedCoreAcceptanceInstructor
Scenario: User LogOut As HedCoreAcceptanceInstructor
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As HedCoreAcceptanceStudent Navigate to HedCoreAcceptanceInstructorCourse
Scenario: User Login As HedCoreAcceptanceStudent Navigate to HedCoreAcceptanceInstructorCourse
Given I browsed the login url for "HedCoreAcceptanceStudent"
When  I logged into the Pegasus as "HedCoreAcceptanceStudent" in "CourseSpace"
Then  I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceStudent"

#Purpose:Verify The User Login As HedCoreAcceptanceStudent Navigate to HedCoreAcceptanceProgramCourse
Scenario: User Login As HedCoreAcceptanceStudent Navigate to HedCoreAcceptanceProgramCourse
Given I browsed the login url for "HedCoreAcceptanceStudent"
When  I logged into the Pegasus as "HedCoreAcceptanceStudent" in "CourseSpace"
Then  I should logged in successfully
Given I am on the "Global Home" page
When  I enter in the "HedCoreAcceptanceProgramCourse" from the Global Home page as "HedCoreAcceptanceStudent"

#Purpose:Verify The User LogOut As HedCoreAcceptanceStudent
Scenario: User LogOut As HedCoreAcceptanceStudent
When  I "Sign out" from the "HedCoreAcceptanceStudent"
Then  I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As WorkSpaceAdmin
Scenario: User Login As WorkSpaceAdmin
Given I browsed the login url for "HedWsAdmin"
When I logged into the Pegasus as "HedWsAdmin" in "WorkSpace"
Then I should logged in successfully

#Purpose:Verify The User LogOut As WorkSpaceAdmin
Scenario: User LogOut As WorkSpaceAdmin
When I "Sign out" from the "HedWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As WorkSpaceTeacher GlobalHome
Scenario: User Login As WorkSpaceTeacher 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully

#Purpose:Verify The User Login As WorkSpaceTeacher GeneralCourse
Scenario: User Login As WorkSpaceTeacher Navigate to GeneralCourse
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HEDGeneral" from the Global Home page as "HedWsInstructor"

#Purpose:Verify The User Login As WorkSpaceTeacher MasterCourse
Scenario: User Login As WorkSpaceTeacher Navigate to MasterCourse
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor" 

#Purpose:Verify The User Login As WorkSpaceTeacher EmptyCourse
Scenario: User Login As WorkSpaceTeacher Navigate to EmptyCourse
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HedEmptyClass" from the Global Home page as "HedWsInstructor"

#Purpose:Verify The User LogOut As WorkSpaceTeacher
Scenario: User LogOut As WorkSpaceTeacher
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As CourseSpaceAdmin
Scenario: User Login As CourseSpaceAdmin
Given I browsed the login url for "HedCsAdmin"
When I logged into the Pegasus as "HedCsAdmin" in "CourseSpace"
Then I should logged in successfully

#Purpose:Verify The User LogOut As CourseSpaceAdmin
Scenario: User LogOut As CourseSpaceAdmin
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Verify the global home page usecases
#Purpose:Verify The User Login As CourseSpaceSMSInstructor
Scenario: User Login As CsSMSInstructor
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Verify the usecases in Program Course
#Purpose:Verify The User Login As CourseSpaceSMSInstructor
Scenario: User Login As CsSMSInstructor Navigate To ProgramCourse
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"

#Verify the usecases in Instructor Course
#Purpose:Verify The User Login As CourseSpaceSMSInstructor
Scenario: User Login As CsSMSInstructor Navigate To InstructorCourse
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"

#Purpose:Verify The User LogOut As CourseSpaceSMSInstructor
Scenario: User LogOut As CsSMSInstructor
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Verify the global home page usecases
#Purpose:Verify The User Login As CourseSpaceSMSStudent
Scenario: User Login As CsSMSStudent
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page


#Verify the usecases in InstructorCourse
#Purpose:Verify The User Login As CourseSpaceSMSStudent
Scenario: User Login As CsSMSStudent Navigate To InstructorCourse
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"

#Purpose:Verify The User LogOut As CourseSpaceSMSStudent
Scenario: User LogOut As CsSMSStudent
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Verify the global home page usecases
#Purpose:Verify The User Login As TA Instructor
Scenario: User Login As CsTAInstructor
Given I browsed the login url for "HedTeacherAssistant"
When I logged into the Pegasus as "HedTeacherAssistant" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Verify the usecases in Instructor Course
#Purpose:Verify The User Login As TA Instructor
Scenario: User Login As CsTAInstructor Navigate To InstructorCourse
Given I browsed the login url for "HedTeacherAssistant"
When I logged into the Pegasus as "HedTeacherAssistant" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "HedTeacherAssistant"

#Purpose:Verify The User LogOut As CsTAInstructor
Scenario: User LogOut As CsTAInstructor
When I "Sign out" from the "HedTeacherAssistant"
Then I should see the successfull message "You have been signed out of the application."

#MySpanishLab for ¡Anda! Curso elemental, 2e -AuthoredCourse
#Purpose: Verify The User Login As CourseSpaceSMSStudent TO MySpanishLabAuthoredCourse
Scenario: User Login As CsSMSStudent Navigate To MySpanishLabAuthored
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MySpanishLabMaster" from the Global Home page as "CsSmsStudent"