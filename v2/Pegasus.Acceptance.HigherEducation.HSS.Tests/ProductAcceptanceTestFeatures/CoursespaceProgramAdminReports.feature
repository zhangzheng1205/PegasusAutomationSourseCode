Feature: CourseSpaceProgramAdminReport
	           As a Program Admin
			   I want to manage all the coursespace admin report related usecases 
			   so that I would validate all the coursespace admin report related scenarios are working fine

#Purpose : Generate and save the "Student Results by Activity" as a ProgramAdmin
#Test Case Id:peg-22216
#PEGASUS-29437
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Generate and save the "Student Results by Activity" as a ProgramAdmin
When I navigate to "Reports" tab of the "Program Administration" page as Admin
And  I clicked on the "Student Results by Activity" report link
Then I should be on the "Program Administration" page
When I select "HSSMyPsychLabProgram" section under "HSSMyPsychLabMaster" template in "Select Sections"
And  I select Activity "Take the Chapter 1 Exam"
And  I select "HSSCsSmsStudent" student in "Select Student"
Then I select 'save settings to My Reports' option
When I click on the "Run Report" button in reports
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And  I enter the "HSSActivityResultsByStudent" report name
And  I click on "SaveandRun" button
Then I should see the section "HSSMyPsychLabProgram" for "HSSCsSmsStudent" with average score "100%" 
And I should see "Take the Chapter 1 Exam" "Exam" details in report
When I close the "Report: Student Results by Activity" window
And I click on the "Cancel" button in reports
Then I should see the "Save settings to My Reports" popup closed
And I should be on the "Program Administration" page
When I select "Run Report" for "HSSActivityResultsByStudent" report in 'My Reports' grid by "HSSProgramAdmin"
Then I should be on the "Report: Student Results by Activity" page
When I close the "Report: Student Results by Activity" window


#Purpose : Generate and save the  "Study plan Results report"  as a ProgramAdmin
#Test case ID : peg-22233
#PEGASUS-29740
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Generate and save the "Study plan Result report" as a ProgramAdmin
When I navigate to "Reports" tab of the "Program Administration" page as Admin
And  I clicked on the "Study Plan Results" report link
Then I should be on the "Program Administration" page
When I select "HSSMyPsychLabProgram" section under "HSSMyPsychLabMaster" template in "Select Sections"
And I select "Complete the Chapter 1 Study Plan" asset in "Select Study Plans" by "HSSProgramAdmin"
And I 'Select All' in 'Student Options' by "HSSProgramAdmin"
Then I select 'save settings to My Reports' option
When I click on the "Run Report" button in reports
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And  I enter the "HSSActivityResultsByStudent" report name
And  I click on "SaveandRun" button
Then I should see the "Save settings to My Reports" popup closed
And I should see average score "36%"
And I should see 'Zero' "HSSCsSmsStudent" along with Pre-test "0%" Post-test "0%"
And I should see the "HSSCsSmsStudent" along with  Pre-test "72%" Post-test "72%"
When I close the "Report: Student Results by Activity" window
And I click on the "Cancel" button in reports
Then I should be on the "Program Administration" page
When I select "Run Report" for "HSSActivityResultsByStudent" report in 'My Reports' grid by "HSSProgramAdmin"
Then I should be on the "Study Plan Results" page
When I close the "Study Plan Results" window


#Purpose : Generate and save the "Activity Results by Student" as a Program Admin
#Test case ID : peg-22218
#PEGASUS-29742
#Products : HSS
#Pre condition : This test case is to generate the Activity Results by Student Report across the Sections in the program based on the below activities submissions available in the Course (Refer: Test link peg-22218)
#Dependency : No dependency test can run with existing data
Scenario: Generate and save the "Activity Results by Student" as a Program Admin
When I navigate to "Reports" tab of the "Program Administration" page as Admin
And  I clicked on the "Activity Results by Student" report link
Then I should be on the "Program Administration" page
When I select "HSSMyPsychLabProgram" section under "HSSMyPsychLabMaster" template in "Select Sections"
And  I select Activity "Take the Chapter 1 Exam"
And I 'Select All' in 'Student Options' by "HSSProgramAdmin"
Then I select 'save settings to My Reports' option
When I click on the "Run Report" button in reports
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And  I enter the "HSSActivityResultsByStudent" report name
And  I click on "SaveandRun" button
Then I should see the "Save settings to My Reports" popup closed
And I should see the "Take the Chapter 1 Exam" with section name "HSSMyPsychLabProgram" with average score "50%" 
And I should see 'Zero' "HSSCsSmsStudent" along with submitted score "0%"
And I should see the "HSSCsSmsStudent" along with attempt submitted as score "100%"
When I close the "Report: Activity Results by Student" window
When I click on the "Cancel" button in reports
Then I should be on the "Program Administration" page
When I select "Run Report" for "HSSActivityResultsByStudent" report in 'My Reports' grid by "HSSProgramAdmin"
Then I should be on the "Report: Activity Results by Student" page
When I close the "Report: Activity Results by Student" window


