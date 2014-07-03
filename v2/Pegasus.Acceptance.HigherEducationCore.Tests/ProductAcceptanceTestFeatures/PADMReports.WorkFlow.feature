Feature: PADMReports
                    As a Program Admin 
					I want to manage all the PADMIN  related reports 
					so that I would validate all the PADMIN report scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose:Generation of Student Enrollment Report
Scenario: Generate Student Enrollment Report by Program Admin
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I select the "Reports" tab
And  I clicked on the "Student Enrollment" link
And  I select Section
And  I select Student
When I click on the "Run Report" button in reports
Then I should see "StudentEnrollment" report launched successfully
When I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Generation of course section usage report by Program Admin
Scenario: Generate Course Section Usage Report by Program Admin
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I select the "Reports" tab
And  I clicked on the "Course Section Usage" link
And  I select Section
And I click on the "Run Report" button in reports
Then I should see "CourseSectionUsage" report launched successfully
When I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:To verify the functionality of "Hide  Section(s)" button present in Select sections pop up by Program Admin
# TestCase Id: HSS_Core_PWF_799
Scenario: To verify the functionality of Hide Section(s) button present in Select sections pop up by Program Admin
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And I clicked on the "Student Enrollment" link
And I clicked on 'Select Sections'
Then I should be on the "Select Sections" page
When I click on 'Show Sections' link
Then I should see the section
When I click on 'Hide Sections' link
Then I should not see the section
When I click on "Cancel" button in select sections popup
And I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:To check the functionality of the ADD section button in select section(s) popup window When no section is selected
# TestCase Id: HSS_Core_PWF_807
Scenario: To check the functionality of the ADD section button in select section(s) popup window When no section is selected by Program Admin
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And I clicked on the "Student Enrollment" link
And I clicked on 'Select Sections'
Then I should be on the "Select Sections" page
When I click on "AddSections" button in select sections popup
Then I should see the message "Please select template sections" in select sections popup
When I click on expand link
And I click on collapse link
Then I should not see the section
When I click on "Cancel" button in select sections popup
And I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:To verify the functionality of "Inactive radio" button present in section option frame  
# TestCase Id: HSS_Core_PWF_801
Scenario: To verify the functionality of Inactive radio button present in section option frame by Program Admin
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I navigate to the "Sections" tab
And I click the "Set to Inactive" option
Then I should see the successfull message "Section inactivated successfully."
When I navigate to the "Users" tab
And I navigate to the "Reports" tab
And I clicked on the "Student Enrollment" link
Then I should be on the "Program Administration" page
When I select "Inactive" radio button in section options
And I clicked on 'Select Sections'
Then I should be on the "Select Sections" page
When I click on expand link
Then I should see the section
When I click on "Cancel" button in select sections popup
And I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:To verify the functionality of "All Statuses radio" button present in section option frame 
# TestCase Id: HSS_Core_PWF_802
Scenario: To verify the functionality of All Statuses radio button present in section option frame by Program Admin
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And I clicked on the "Student Enrollment" link
Then I should be on the "Program Administration" page
When I select "AllStatuses" radio button in section options
And I clicked on 'Select Sections'
Then I should be on the "Select Sections" page
When I click on expand link
Then I should see both active and inactive sections
When I click on "Cancel" button in select sections popup
And I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:To verify the functionality of "Save and Run" button present in the "Save settings to My Reports" pop up (when a name is entered  to the report)
# TestCase Id: HSS_Core_PWF_812
Scenario: Student Enrollment Save and Run button when a name is entered to the report by Program Admin
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And I clicked on the "Student Enrollment" link
Then I should be on the "Program Administration" page
When I select Section
And I select Student
And I select 'save settings to My Reports' option
And I click on the "Run Report" button in reports
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the "HedCoreStudentEnrollment" report name
And I click on "SaveandRun" button
Then I should see the "Save settings to My Reports" popup closed
And I should see "StudentEnrollment" report launched successfully
When I click on the "Cancel" button in reports
Then I should see the "HedCoreStudentEnrollment" report in 'My Reports' grid
When I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:To check the functionality of the enrolment date column In student enrolment report
# TestCase Id: HSS_Core_PWF_813
Scenario: To check the functionality of the enrolment date column In student enrolment report by Program Admin
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And I clicked on the "Student Enrollment" link
Then I should be on the "Program Administration" page
When I select Section
And I select Student
And I click on the "Run Report" button in reports
Then I should see the enrollment date
When I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:To check the functionality of the Last login column In student enrolment report
# TestCase Id: HSS_Core_PWF_814
Scenario: To check the functionality of the Last login column In student enrolment report by Program Admin
When I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
And I should be on the "Global Home" page
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And I clicked on the "Student Enrollment" link
Then I should be on the "Program Administration" page
When I select Section
And I select Student
And I click on the "Run Report" button in reports
Then I should see the last login date in report
When I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:To check the functionality of the Student Enrollment Report in  the reports tab
# TestCase Id:HSS_Core_PWF_796
Scenario: To check the functionality of the Student Enrollment Report in  the reports tab by Program Admin
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And I clicked on the "Student Enrollment" link
Then I should be on the "Program Administration" page
When I select Section
Then I should see all the fields in 'Student Enrollment' report
When I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."