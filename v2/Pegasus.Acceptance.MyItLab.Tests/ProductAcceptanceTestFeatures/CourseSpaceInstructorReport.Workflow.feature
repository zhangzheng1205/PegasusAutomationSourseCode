Feature: CourseSpaceInstructorReport
	                As a CS Instructor 
					I want to manage all the coursespace instructor report related usecases 
					so that I would validate all the coursespace instructor report related scenarios are working fine.

#Purpose : Report request : Activity Results (Single Student) 
#Test Case Id :HED_MIL_PWF_935
#MyItLabProgramCourse
Scenario: Activity Results for Single Student by Program Admin
When I navigate to "Reports" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I click on "Activity Results (Single Student)" report in 'Activity Reports' panel
And I select options to generate report
And I click on the "Run Report" button in reports
Then I should see the score "100" of "SIM5Activity" activity of behavioral mode "SkillBased" type under launched report

#Purpose : "Save and Run" functionality for Study Plan single student report 
#Test Case Id :HED_MIL_PWF_978
#MyItLabInstructorCourse
Scenario: Save and Run functionality for Study Plan single student report
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on 'Study Plan Single Student' report link
And I select options to create 'Study Plan Single Student' report
And I click on "Run Report" button in reports
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the "HedMilStudyPlanSingleStudent" report name
And I click on "SaveOnly" button
Then I should see the "Save settings to My Reports" popup closed
When I click on "Cancel" button in reports
Then I should see the "HedMilStudyPlanSingleStudent" report in 'My Reports' grid
When I click on 'Study Plan Single Student' report link
And I select options to create 'Study Plan Single Student' report
And I click on "Run Report" button in reports
Then I should be on the "Save settings to My Reports" page
When I select "Replaceexistingreport" radiobutton
Then I should see "HedMilStudyPlanSingleStudent" report in dropdown 
When I click on "Cancel" button

#Purpose : To verify the functionality of "Run Report" button in the Options Page (with valid details added in the fields provided) 
#Test Case Id :HED_MIL_PWF_963
#MyItLabInstructorCourse
Scenario: To verify the functionality of "Run Report" button in the Options Page (with valid details added in the fields provided)
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on "TrainingFrequencyAnalysis" report type
And I enter the valid data in the fields to 'Training Frequency Analysis' generate report
And I select 'save settings to My Reports' option
And I click on "Run Report" button in reports
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the "MyItLabTrainingFrequencyAnalysis" report name
And I click on "SaveandRun" button
Then I should see the "Save settings to My Reports" popup closed
And I should see the score "100" in generated report
When I close the "Training Frequency Analysis" window
And I click on "Cancel" button in reports
Then I should see the "MyItLabTrainingFrequencyAnalysis" report in 'My Reports' grid

#Purpose : Report request : Activity Results (Single Student) 
#Test Case Id : HED_MIL_PWF_965
#MyItLabInstructorCourse
Scenario: Activity Results for Single Student by SMS Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on "ActivityResultsSingleStudent" report type
And I select options to generate report by instructor for "Test"
And I click on "Run Report" button in reports
Then I should see the score "100" in Activity Result Single Student generated report
When I close the "Activity Results (Single Student)" window

#Purpose : To verify the functionality of "Most Recent" radio button
#Test Case Id : HED_MIL_PWF_972
#MyItLabInstructorCourse
Scenario: To verify the functionality of "Most Recent" radio button by SMS Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on "ExamFrequencyAnalysis" report type
And I enter the exam frequency analysis valid data in the fields to generate report
And I click on "Run Report" button in reports
Then I should see the score "100" in Exam Frequency Analysis generated report
When I close the "Exam Frequency Analysis" window

#Purpose : Certificate of Competition Exam based PADMIN
#Test Case Id :HED_MIL_PWF_958
#MyItLabProgramCourse
Scenario: Certificate of Competition Exam based PADMIN
When I navigate to "Reports" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I click on "Certificate of Completion (Exam)" certificate report in 'Activity Reports' panel
And I select options for 'Certificate of Completion Exam'
And I click on the "Run Report" button in reports
Then I should be on the "Certificate of Completion (Exam)" page
And I should see the exam score "100.00%" in 'Certificate of Completion Exam' page
When I close the "Certificate of Completion (Exam)" window

#Purpose : Certificate of Competition Training based 
#Test Case Id : HED_MIL_PWF_968
#MyItLabInstructorCourse
Scenario: Certificate of Competition Training based By SMS Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on "CertificateofCompletionTraining" certificate type
And I enter the valid data in the fields to generate certificate
And I click on "Run Report" button in reports
Then I should see the training score "100.00%" in 'Certificate of Completion Training' certificate
When I close the "Certificate of Completion (Training)" window

#Purpose : Certificate of Competition Exam based 
#Test Case Id : HED_MIL_PWF_967
Scenario: Certificate of Competition Exam based By SMS Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on "CertificateofCompletionExam" certificate type
And I enter the valid data in the fields to generate certificate for Exam report
And I click on "Run Report" button in reports
Then I should see the exam score "100.00%" in 'Certificate of Completion Exam' page
When I close the "Certificate of Completion (Exam)" window

#Purpose : Generate “Activity Result (Multiple students and activities)" Report by SMS Instructor
#Test Case Id:peg-21964
#MyITLabOffice2013Program
Scenario:Activity Result (Multiple students and activities) report generation and data verification by SMS Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on the "Activity Result (Multiple students and activities)" report link as "CsSmsInstructor"
Then I should open "Options for Activity Results (Multiple students and activities)" criteria page as "CsSmsInstructor"
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" asset in "Select Activities" by "CsSmsInstructor"
And I 'Select All' in 'Student Options' by "CsSmsInstructor"
And I select 'save settings to My Reports' option by "CsSmsInstructor"
And I click on the "Run Report" button in reports by "CsSmsInstructor"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the "MyItLabActivityResultsMultipleStudentsAdActivities" report name
And I click on "SaveandRun" button
Then I should see the "Activities: Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" with section "MyITLabOffice2013Program" average score "50%"
And I should see 'Zero' "CsSmsStudent" along with attempt as "1" score as "0%"
And I should see the "CsSmsStudent" along with attempt as "2" score as "100%"
When I close the "Activity Results (Multiple students and activities) " window
And I click on the "Cancel" button in reports by "CsSmsInstructor"
And I select "Run Report" for "MyItLabActivityResultsMultipleStudentsAdActivities" report in 'My Reports' grid by "CsSmsInstructor"
Then I should be on the "Activity Results (Multiple students and activities)" page
When I close the "Activity Results (Multiple students and activities) " window

#Purpose : Generate “Activity Results (Multiple Students)" Report by SMS Instructor
#Test Case Id:peg-21984
#MyITLabOffice2013Program
Scenario: Activity Results (Multiple Students) report generation and data verification by SMS Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on the "Activity Results (Multiple Students)" report link as "CsSmsInstructor"
Then I should open "Options for Activity Results (Multiple Students)" criteria page as "CsSmsInstructor"
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" asset in 'Select Activity' 
And I 'Select All' in 'Student Options' by "CsSmsInstructor"
And I select 'save settings to My Reports' option by "CsSmsInstructor"
And I click on the "Run Report" button in reports by "CsSmsInstructor"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the "MyITLabActivityResultsMultipleStudents" report name
And I click on "SaveandRun" button
Then I should be on the "Activity Results (Multiple Students)" page
Then I should see the "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" along with section "MyITLabOffice2013Program" average score "50%"
And I should see 'Zero' "CsSmsStudent" along with attempt as "1" submitted as score as "0%"
And I should see the "CsSmsStudent" along with attempt as "2" submitted as score as "100%"
When I close the "Activity Results (Multiple Students)" window
And I click on the "Cancel" button in reports by "CsSmsInstructor"
And I select "Run Report" for "MyITLabActivityResultsMultipleStudents" report in 'My Reports' grid by "CsSmsInstructor"
Then I should be on the "Activity Results (Multiple Students)" page
And I close the "Activity Results (Multiple Students)" window

#Purpose: To run and save the "Exam Frequency Analysis" Report As Section instructor
#Test Case Id: peg-21956
#MyITLabOffice2013Program
Scenario: To run and save "Exam Frequency Analysis" Report As Section instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on the "Exam Frequency Analysis" report link as "CsSmsInstructor"
Then I should open "Options for Exam Frequency Analysis" criteria page as "CsSmsInstructor"
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" asset in "Select Exams" by "CsSmsInstructor"
And I select 'save settings to My Reports' option by "CsSmsInstructor"
And I click on the "Run Report" button in reports by "CsSmsInstructor"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the " MyITLabExamFrequencyAnalysis" report name
And I click on "SaveandRun" button
Then I should be on the "Exam Frequency Analysis" page
And I should see the "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" along with average score "50%"
And I should see questions details "WD Activity 1.01: Starting a New Word Document" "SIM5 Question" "Word 2013" "50.00%"
And I should see question detail "WD Activity 1.02: Inserting Text from Another Document" "SIM5 Question" "Word 2013" "50.00%"
When I close the "Exam Frequency Analysis" window
And I click on the "Cancel" button in reports by "CsSmsInstructor"
And I select "Run Report" for " MyITLabExamFrequencyAnalysis" report in 'My Reports' grid by "CsSmsInstructor"
Then I should be on the "Exam Frequency Analysis" page
And I close the "Exam Frequency Analysis" window

#Purpose: To run and save the "Training Frequency Analysis" Report As Section instructor
#Test Case Id: peg-21960
#MyITLabOffice2013Program
Scenario: To run and save "Training Frequency Analysis" Report As Section instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on the "Training Frequency Analysis" report link as "CsSmsInstructor"
Then I should open "Options for Training Frequency Analysis" criteria page as "CsSmsInstructor"
When I select "Excel Chapter 1 Skill-Based Training" asset in "Select Trainings" by "CsSmsInstructor"
And I select 'save settings to My Reports' option by "CsSmsInstructor"
And I click on the "Run Report" button in reports by "CsSmsInstructor"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the "MyITLabTrainingFrequencyAnalysis" report name
And I click on "SaveandRun" button
Then I should be on the "Training Frequency Analysis" page
And I should see the "Excel Chapter 1 Skill-Based Training" along with average score "50%"
And I should see question details "XL Activity 1.01: Starting Excel, Navigating Excel, and Naming and Saving a Workbook" "Excel 2013" "50.00%"
And I should see training question details "XL Activity 1.02: Entering Text, Using AutoComplete, and Using the Name Box to Select a Cell" "Excel 2013" "50.00%" 
When I close the "Training Frequency Analysis" window
And I click on the "Cancel" button in reports by "CsSmsInstructor"
And I select "Run Report" for " MyITLabTrainingFrequencyAnalysis" report in 'My Reports' grid by "CsSmsInstructor"
Then I should be on the "Training Frequency Analysis" page
And I close the "Training Frequency Analysis" window

#Purpose: To run and save the "Learning Aid Usage" Report by Section Instructor
#Test Case Id: peg-22196
#MyITLabOffice2013Program
Scenario: To run and save "Learning Aid Usage" Report by Section Instructor
Given I browsed the login url for "HedProgramAdmin"
When I logged into the Pegasus as "HedProgramAdmin" in "CourseSpace"
Then I should logged in successfully
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "HedProgramAdmin"
Then I should be on the "Program Administration" page
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "MyITLabOffice2013Program" first section
And I click the "Enter Section as Instructor"
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
When I click on the "Learning Aid Usage" report link as "CsSmsInstructor"
Then I should open "Options for Learning Aid Usage" criteria page as "CsSmsInstructor"
When I select "Word Chapter 1 Skill-Based Training" asset in 'Select Activity' 
And I select 'save settings to My Reports' option by "CsSmsInstructor"
And I click on the "Run Report" button in reports by "CsSmsInstructor"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the " MyITLabExamFrequencyAnalysis" report name
And I click on "SaveandRun" button
Then I should see  "Word Chapter 1 Skill-Based Training" along with average score "42.86%"
And I should see the details of the row number "1" "WD Activity 1.01: Starting a New Word Document" "SIM5" "ST_ReportSection" "Word 2013" "100.00" "100.00"
And I should see the details of the row number "3" "WD Activity 1.02: Inserting Text from Another Document" "SIM5" "ST_ReportSection" "Word 2013" "--" "--"
When I close the "Learning Aid Usage" window
And I click on the "Cancel" button in reports by "HedProgramAdmin"
And I select "Run Report" for " MyITLabExamFrequencyAnalysis" report in 'My Reports' grid by "HedProgramAdmin"
And I click  "Close" button


 

        
       
        


