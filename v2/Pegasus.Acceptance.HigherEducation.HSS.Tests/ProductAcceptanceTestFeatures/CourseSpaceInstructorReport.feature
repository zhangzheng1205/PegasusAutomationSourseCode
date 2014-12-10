Feature: CourseSpaceInstructorReport
	                As a HSS CS Instructor 
					I want to manage all the coursespace instructor report related usecases 
					so that I would validate all the coursespace instructor report related scenarios are working fine.


#Purpose : Generate and save the "Student Results by Activity" as a Section Instructor
#Test Case Id:peg-22217
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Generate and save the "Student Results by Activity" as a Section Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on "Student Results by Activity" report link as "HSSCsSmsInstructor"
And I select "HSSCsSmsStudent" asset in "Select Student" by "HSSCsSmsInstructor"
And I select "Take the Chapter 1 Exam" asset in "Select Activities" by "HSSCsSmsInstructor"
And I select 'save settings to My Reports' option by "HSSCsSmsInstructor"
And I click on the "Run Report" button in reports by "HSSCsSmsInstructor"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And  I enter the "HSSActivityResultsByStudent" report name
And  I click on "SaveandRun" button
Then I should see the "Save settings to My Reports" popup closed
And I should be on the "Report: Student Results by Activity" page
And I should see the section name "HSSMyPsychLabProgram" for "HSSCsSmsStudent" with average score "100%" 
And I should see " Take the Chapter 1 Exam " "Exam" details in the report
When I close the "Report: Student Results by Activity" window
And I click on the "Cancel" button in reports by "HSSCsSmsInstructor"
And I select "Run Report" for "HSSActivityResultsByStudent" report in 'My Reports' grid by "HSSCsSmsInstructor"
Then I should be on the "Report: Activity Results by Student" page
When I close the "Report: Student Results by Activity" window
And I "Sign out" from the "HSSCsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Generate and save the "Activity Results by Student" as a Section Instructor
#Test case ID : peg-22219
#Products : HSS
#Pre condition : This test case is to generate the Activity Results by Student Report across the Sections
# in the program based on the below activities submissions available in the Course (Refer: Test link peg-22219)
#Dependency : No dependency test can run with existing data
Scenario: Generate and save the "Activity Results by Student" as a Section Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
And I click on "Activity Results by Student" report link as "HSSCsSmsInstructor"
And I select "Take the Chapter 1 Exam" asset in "Select Activity" by "HSSCsSmsInstructor"
And I 'Select All' in 'Student Options' by "HSSCsSmsInstructor"
And I select 'save settings to My Reports' option by "HSSCsSmsInstructor"
And I click on the "Run Report" button in reports by "HSSCsSmsInstructor"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And  I enter the "HSSActivityResultsByStudent" report name
And  I click on "SaveandRun" button
Then I should see the "Save settings to My Reports" popup closed
And I should be on the "Report: Activity Results by Student" page
And I should see the "Take the Chapter 1 Exam" with section name "HSSMyPsychLabProgram" with average score "49%" 
And I should see 'Zero' "HSSCsSmsStudent" along with submitted score as "24%"
And I should see the "HSSCsSmsStudent" along with attempt submitted as score as "40%"
When I close the "Report: Activity Results by Student" window
And I click on the "Cancel" button in reports by "HSSCsSmsInstructor"
And I select "Run Report" for "HSSActivityResultsByStudent" report in 'My Reports' grid by "HSSCsSmsInstructor"
Then I should be on the "Report: Activity Results by Student" page
When I close the "Report: Activity Results by Student" window
And I "Sign out" from the "HSSCsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Generate and save the  "Study plan Results report"  as a Section Instructor
#Test case ID : peg-22223
#Products : HSS
#Pre condition : This test case is to generate the Activity Results by Student Report across the Sections in the program based on the below activities submissions available in the Course (Refer: Test link peg-22219)
#Dependency : No dependency test can run with existing data
Scenario: Generate and save the  "Study plan Results report"  as a Section Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
And I click on "Study Plan Results" report link as "HSSCsSmsInstructor"
And I select "Complete the Chapter 1 Study Plan" asset in "Select Study Plans" by "HSSCsSmsInstructor"
And I 'Select All' in 'Student Options' by "HSSCsSmsInstructor"
And I select 'save settings to My Reports' option by "HSSCsSmsInstructor"
And I click on the "Run Report" button in reports by "HSSCsSmsInstructor"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And  I enter the "HSSStudytPlanResults" report name
And  I click on "SaveandRun" button
Then I should see the "Save settings to My Reports" popup closed
And I should be on the "Study Plan Results" page
And I should see average score "13.5%"
And I should see 'Zero' "HSSCsSmsStudent" along with Pre-test "0%" Post-test "0%"
And I should see the "HSSCsSmsStudent" along with  Pre-test "72%" Post-test "29.7%"
When I close the "Study Plan Results" window
And I click on the "Cancel" button in reports by "HSSCsSmsInstructor"
And I select "Run Report" for "HSSStudytPlanResults" report in 'My Reports' grid by "HSSCsSmsInstructor"
Then I should be on the "Study Plan Results" page
When I close the "Study Plan Results" window
And I "Sign out" from the "HSSCsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."