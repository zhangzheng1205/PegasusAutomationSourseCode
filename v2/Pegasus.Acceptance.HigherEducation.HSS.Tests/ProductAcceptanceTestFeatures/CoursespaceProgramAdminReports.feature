Feature: CourseSpaceProgramAdminReport
	           As a Program Admin
			   I want to manage all the coursespace admin report related usecases 
			   so that I would validate all the coursespace admin report related scenarios are working fine

#Purpose : Generate and save the "Student Results by Activity" as a ProgramAdmin
#Test Case Id:peg-22216
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Generate and save the "Student Results by Activity" as a ProgramAdmin
Given I browsed the login url for "HSSProgramAdmin"
When I logged into the Pegasus as "HSSProgramAdmin" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSProgramAdmin"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And  I clicked on the "Student Results by Activity" report link
Then I should be on the "Program Administration" page
When I select Section
And  I select Activity "Take the Chapter 1 Exam"
And  I select "HSSCsSmsStudent" student in "Select Student"
Then I select 'save settings to My Reports' option
When I click on the "Run Report" button in reports
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And  I enter the "HSSActivityResultsByStudent" report name
And  I click on "SaveandRun" button
Then I should see the "Save settings to My Reports" popup closed
And I should see the section name "HSSMyPsychLabProgram" for "HSSCsSmsStudent" with average score "100%" 
And I should see " Take the Chapter 1 Exam " "Exam" details in the report
When I click on the "Cancel" button in reports
Then I should be on the "Program Administration" page
When I select "Run Report" for "HSSActivityResultsByStudent" report in 'My Reports' grid by "HSSProgramAdmin"
Then I should be on the "Program Administration" page

#Purpose : Generate and save the  "Study plan Results report"  as a ProgramAdmin
#Test case ID : peg-22233
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Generate and save the "Study plan Result report" as a ProgramAdmin
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSProgramAdmin"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And  I clicked on the "Study Plan Results" report link
Then I should be on the "Program Administration" page
When I select Section
And  I select Activity "Complete the Chapter 1 Study Plan"
And I 'Select All' in 'Student Options' by "HSSProgramAdmin"
Then I select 'save settings to My Reports' option
When I click on the "Run Report" button in reports
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And  I enter the "HSSActivityResultsByStudent" report name
And  I click on "SaveandRun" button
Then I should see the "Save settings to My Reports" popup closed
Then I should see average score "13.5%"
And I should see 'Zero' "HSSCsSmsStudent" along with Pre-test "0%" Post-test "0%"
And I should see the "HSSCsSmsStudent" along with  Pre-test "72%" Post-test "29.7%"
When I click on the "Cancel" button in reports
Then I should be on the "Program Administration" page
When I select "Run Report" for "HSSActivityResultsByStudent" report in 'My Reports' grid by "HSSProgramAdmin"
Then I should be on the "Program Administration" page