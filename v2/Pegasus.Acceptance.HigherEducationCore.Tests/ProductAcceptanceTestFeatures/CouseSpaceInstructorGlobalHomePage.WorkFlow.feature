Feature: CouseSpaceInstructorGlobalHomePage
	                As a CS Instructor 
					I want to manage all the coursespace Instructor Global Home Page related usecases 
					so that I would validate all the coursespace Instructor Global Home Page scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To verify the functionality of C-menu "Enter Section as Instructor " of the created section
# TestCase Id: HSS_Core_PWF_036
Scenario: Cmenu "Enter Section as Instructor " of the created section
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
And I click the "Enter Section as Instructor" option
When I navigate to the "Today's View" tab
Then I should be on the "Today's View" page
And I should see the section name and ID of "ProgramCourse"
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To verify the message display for the user if the entered search criteria not holds good with the course info in the catalog
# TestCase Id: HSS_Core_PWF_026
Scenario: To verify the message display for the user if the entered search criteria not holds good with the course info in the catalog by SMS Instructor
When I enter the invalid search parameter "InvalidText" in search catalog 
And I click on next button
Then I should see the message "No records found."
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To verify the functionality of C-menu "Enter Template as Instructor " of the created Template
# TestCase Id: HSS_Core_PWF_028
Scenario: Select "Enter Template as Instructor" cmenu option of Template
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I click the "Enter Template as Instructor" option
Then I should see the "MySpanishLabMaster" course
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Accessibility of SMS Courses which are having same start date and end date by SMS Student and SMS TA
# TestCase Id: HSS_Core_PWF_366
Scenario: Accessibility of SMS Courses which are having same start date and end date by SMS Student
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
And I click the "Copy as Section" option
Then I should be on the "Copy as Section" page
When I derive section from parent section
Then I should see the successfull message "Section Copied Successfully."
When I verify the "MySpanishLabMaster" course Template for AssignedToCopy state
Then I should see the "MySpanishLabMaster" course Template to be successfully out of AssignedToCopy state
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enroll SMS Student in "ProgramCourse"
Then I should see enrolled Section in Global Home Page 
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: User Promoted As Teaching Assistant By Program Admin
# TestCase Id: HSS_Core_PWF_366
Scenario: User Promoted As Teaching Assistant By Program Admin
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
And I search section
And I click the "Enter Section as Instructor" option
And I navigate to the "Enrollments" tab
Then I should be on the "Roster" page
When I select the "CsSmsStudent" as promoted "HedTeacherAssistant" in SMS Instructor
Then I should see the role as "Teaching Assistant"
Then I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."