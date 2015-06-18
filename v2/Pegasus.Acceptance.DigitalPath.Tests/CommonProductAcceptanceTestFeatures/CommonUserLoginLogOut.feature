Feature: CommonLoginLogOut

				As a Pegasus User
				I want to manage all the Pegasus User related usecases 
				so that I would validate all the Pegasus User scenarios are working fine.


#Purpose:Verify The User Login As CTGPublisherAdmin
Scenario: User Login As CTGPublisherAdmin
Given I browsed the login url for "DPCTGPPublisherAdmin"
When I login to Pegasus as "DPCTGPPublisherAdmin" in "WorkSpace"
Then I should be logged in successfully

#Purpose:Verify The User LogOut As CTGPublisherAdmin
Scenario: User LogOut As CTGPublisherAdmin
When I "Sign out" from the "DPCTGPPublisherAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As WorkSpaceAdmin
Scenario: User Login As WorkSpaceAdmin
Given I browsed the login url for "WsAdmin"
When I login to Pegasus as "WsAdmin" in "WorkSpace"
Then I should be logged in successfully

#Purpose:Verify The User LogOut As WorkSpaceAdmin
Scenario: User LogOut As WorkSpaceAdmin
When I "Sign out" from the "WsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As WorkSpaceTeacher Navigate to MasterCourse
Scenario: User Login As WorkSpaceTeacher Navigate to MasterCourse
Given I browsed the login url for "WsTeacher"
When I login to Pegasus as "WsTeacher" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page
When I enter in the "MasterLibrary" as "WsTeacher" from the Global Home page

#Purpose:Verify The User Login As WorkSpaceTeacher Navigate to EmptyCourse
Scenario: User Login As WorkSpaceTeacher Navigate to EmptyCourse
Given I browsed the login url for "WsTeacher"
When I login to Pegasus as "WsTeacher" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page
When I enter in the "EmptyClass" as "WsTeacher" from the Global Home page

#Purpose:Verify The User LogOut As WorkSpaceTeacher
Scenario: User LogOut As WorkSpaceTeacher
When I "Sign out" from the "WsTeacher"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As WorkSpaceStudent
Scenario: User Login As WorkSpaceStudent
Given I browsed the login url for "WsStudent"
When I login to Pegasus as "WsStudent" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page 
When I enter in the "MasterLibrary" as "WsStudent" from the Global Home page

#Purpose:Verify The User LogOut As WorkSpaceStudent
Scenario: User LogOut As WorkSpaceStudent
When I "Sign out" from the "WsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As CourseSpaceAdmin
Scenario: User Login As CourseSpaceAdmin
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully

#Purpose:Verify The User LogOut As CourseSpaceAdmin
Scenario: User LogOut As CourseSpaceAdmin
When I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As CSOrganizationAdmin
Scenario: User Login As CSOrganizationAdmin
Given I browsed the login url for "DPCsOrganizationAdmin"
When I login to Pegasus as "DPCsOrganizationAdmin" in "Coursespace"
Then I should be logged in successfully

#Purpose:Verify The User LogOut As CSOrganizationAdmin
Scenario: User LogOut As CSOrganizationAdmin
When I "Sign out" from the "DPCsOrganizationAdmin"
Then I should see the "Signed Out" message

#Purpose:Verify The User Login As CSPromotedAdmin
Scenario: User Login As CSPromotedAdmin
Given I browsed the login url for "DPCourseSpacePramotedAdmin"
When I login to Pegasus as "DPCourseSpacePramotedAdmin" in "Coursespace"
Then I should be logged in successfully

#Purpose:Verify The User LogOut As CSPromotedAdmin
Scenario: User LogOut As CSPromotedAdmin
When I "Sign out" from the "DPCourseSpacePramotedAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Verify The User Login As CourseSpaceStudent
Scenario: User Login As CourseSpaceStudent
Given I browsed the login url for "DPCsStudent"
When I login to Pegasus as "DPCsStudent" in "CourseSpace"
Then I should be logged in successfully

#Purpose:Verify The User Login As new CourseSpaceStudent
Scenario: User Login As new CourseSpaceStudent
Given I browsed the login url for "DPCsNewStudent"
When I login to Pegasus as "DPCsNewStudent" in "CourseSpace"
Then I should be logged in successfully

#Purpose:Verify The User LogOut As new CourseSpaceStudent
Scenario: User LogOut As new CourseSpaceStudent
When I "Sign Out" from the "DPCsNewStudent"
Then I should see the "Signed Out" message

#Purpose:Verify The User Login As new CourseSpaceTeacher
Scenario: User Login As new CourseSpaceTeacher
Given I browsed the login url for "DPCsNewTeacher"
When I login to Pegasus as "DPCsNewTeacher" in "CourseSpace"
Then I should be logged in successfully

#Purpose:Verify The User LogOut As CourseSpaceAide
Scenario: User LogOut As CourseSpaceAide
When I "Sign Out" from the "DPCsAide"
Then I should see the "Signed Out" message

#Purpose:Verify The User LogOut As new CourseSpaceAide
Scenario: User LogOut As new CourseSpaceAide
When I "Sign Out" from the "DPCsNewAide"
Then I should see the "Signed Out" message

#Purpose:Verify The User Login As new CourseSpaceAide
Scenario: User Login As new CourseSpaceAide
Given I browsed the login url for "DPCsNewAide"
When I login to Pegasus as "DPCsNewAide" in "CourseSpace"
Then I should be logged in successfully

#Purpose:Verify The User Login As CourseSpaceAide
Scenario: User Login As CourseSpaceAide
Given I browsed the login url for "DPNewAide"
When I login to Pegasus as "DPNewAide" in "CourseSpace"
Then I should be logged in successfully

#Purpose:Verify The User LogOut As new CourseSpaceTeacher
Scenario: User LogOut As new CourseSpaceTeacher
When I "Sign Out" from the "DPCsNewTeacher"
Then I should see the "Signed Out" message

#Purpose:Verify The User LogOut As CourseSpaceStudent
Scenario: User LogOut As CourseSpaceStudent
When I "Sign Out" from the "DPCsStudent"
Then I should see the "Signed Out" message

#Purpose:Verify The User Login As CourseSpaceTeacher
Scenario: User Login As CourseSpaceTeacher
Given I browsed the login url for "DPCsTeacher"
When I login to Pegasus as "DPCsTeacher" in "CourseSpace"
Then I should be logged in successfully

#Purpose:Verify The User LogOut As CourseSpaceTeacher
Scenario: User LogOut As CourseSpaceTeacher
When I "Sign out" from the "DPCsTeacher"
Then I should see the "Signed Out" message

#Purpose: To save the profile date and time
Scenario: DP Teacher saving the profile date and time
When I click 'My Profile' link as "DPCsTeacher"
And I store user current date and time of the teacher

#Purpose: Coursespace Teacher enter into digital path class
Scenario: Teacher enter into DigitalPath Class
When I enter into the DP "DigitalPathMasterLibrary" class
Then I should be on the "Classes" page

#Purpose:Update enum values for GradeBook Verification
Scenario:Update Enum values for gradebook verification
Given I update enum values for gradebook
