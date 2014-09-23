﻿Feature: CommonUserScenarios
	            As a User
				I want to manage all the MyItLab User related usecases 
				so that I would validate all the MyItLab scenarios are working fine.


Scenario: User Login as PPEStudent in HedMil
Given I browsed the login url for "HedMilPPEStudent"
When I logged into the Pegasus as "HedMilPPEStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Open Ws Url and Login as Workspace Admin
Scenario: User Login as Workspace Admin in HedMil
Given I browsed the login url for "HedMiLWsAdmin"
When I logged into the Pegasus as "HedMiLWsAdmin" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Course Enrollment" page

#Purpose: Open Ws Url and Logout as Workspace Admin
Scenario: User Logout as Workspace Admin in HedMil
When I "Sign out" from the "HedMiLWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Open Ws Url and Login as CTGPublisher Admin
Scenario: User Login as CTGPublisher Admin in HedMil
Given I browsed the login url for "HEDWSCTGPublisherAdmin"
When I logged into the Pegasus as "HEDWSCTGPublisherAdmin" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Workspaces" page

#Purpose: Open Ws Url and Logout as CTGPublisher Admin
Scenario: User Logout as CTGPublisher Admin in HedMil
When I "Sign out" from the "HEDWSCTGPublisherAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Open Ws Url and Login as Workspace Instructor
Scenario: User Login as Workspace Instructor
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Open Ws Url and Login as Workspace Instructor and Navigate to MyItLabSIM5MasterCourse
Scenario: User Login as Workspace Instructor and Navigate to MyItLabSIM5MasterCourse
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabSIM5MasterCourse" course from the Global Home page as "HedWsInstructor"

#Purpose: Open Ws Url and Login as Workspace Instructor and Navigate to MyItLabSIMMasterCourse
Scenario: User Login as Workspace Instructor and Navigate to MyItLabSIMMasterCourse
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabSIMMasterCourse" course from the Global Home page as "HedWsInstructor"

#Purpose: Open Ws Url and Login as Workspace Instructor and Navigate to HedEmptyClass
Scenario: User Login as Workspace Instructor and Navigate to HedEmptyClass
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HedEmptyClass" course from the Global Home page as "HedWsInstructor"

#Purpose: Open Ws Url and Logout as Workspace Instructor
Scenario: User Logout as Workspace Teacher
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Login as SMS Instructor and Navigate to MyItLabInstructorCourse
Scenario: User Login as SMS Instructor and Navigate to MyItLabInstructorCourse
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"

#Purpose: Login as SMS Student and Navigate to MyItLabInstructorCourse
Scenario: User Login as SMS Student and Navigate to MyItLabInstructorCourse
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsStudent"

#Purpose: Login as SMS Student and Navigate to MyItLabProgramCourse
Scenario: User Login as SMS Student and Navigate to MyItLabProgramCourse
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabProgramCourse" course from the Global Home page as "CsSmsStudent"

#Purpose: Login as SMS Instructor
Scenario: User Login as SMS Instructor
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#MyITLabOffice2013Program
#Purpose: Login as SMS Instructor and Navigate to MyITLabOffice2013Section
Scenario: User Login as SMS Instructor and Navigate MyITLabOffice2013Section Course
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "CsSmsInstructor"

#User enter into the program course
#Purpose: Login as SMS Instructor and Navigate to MyITLabOffice2013Program
Scenario: User Login as Program Admin and Navigate MyITLabOffice2013Program Course
Given I browsed the login url for "HedProgramAdmin"
When I logged into the Pegasus as "HedProgramAdmin" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "HedProgramAdmin"

#User enter into the program course and enter into section
#Purpose: Login as Program Admin and Navigate to section MyITLabOffice2013Program
Scenario: User Login Program Admin and Navigate MyITLabOffice2013Section Course
Given I browsed the login url for "HedProgramAdmin"
When I logged into the Pegasus as "HedProgramAdmin" in "CourseSpace"
Then I should logged in successfully
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "HedProgramAdmin"
Then I should be on the "Program Administration" page
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "MyITLabOffice2013Program" first section
And I click the "Enter Section as Instructor"

#Purpose: Logout as SMS Instructor
Scenario: User Logout as SMS Instructor
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Login as Coursespace Admin
Scenario: User Login as Coursespace Admin
Given I browsed the login url for "HedCsAdmin"
When I logged into the Pegasus as "HedCsAdmin" in "CourseSpace"
Then I should logged in successfully

#Purpose: Logout as Coursespace Admin
Scenario: User Logout as Coursespace Admin
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Login as SMS Student and Navigate to MyITLabOffice2013Program
Scenario: User Login as SMS Student and Navigate to MyITLabOffice2013Section Course
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "CsSmsStudent"

#Purpose: Login as SMS Student
Scenario: User Login as SMS Student
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Login as Zero Score SMS Student
Scenario: User login as SMS student to score zero percent
Given I browsed the login url for "CsSmsStudent"
When I login as "scoring 0" into the pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "CsSmsStudent"

#Purpose: Login as Set Idle SMS Student
Scenario: User Login as Set Idle SMS Student
Given I browsed the login url for "CsSmsStudent"
When I login as "set idle" into the pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Logout as SMS Student
Scenario: User Logout as SMS Student
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

Scenario: User Login as SMS Instructor and Navigate to MyItLabProgramCourse
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabProgramCourse" course from the Global Home page as "CsSmsInstructor"

