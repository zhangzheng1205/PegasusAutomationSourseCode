Feature: CourseSpaceProgramAdminReport
	           As a Program Admin
			   I want to manage all the coursespace admin report related usecases 
			   so that I would validate all the coursespace admin report related scenarios are working fine.

#Purpose : Generate “Activity Result (Multiple students and activities)" Report by Program Admin
#Test Case Id:peg-2117
#MyITLabOffice2013Program
Scenario: Activity Result (Multiple students and activities) report generation and data verification by Program Admin
When I navigate to "Reports" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I click on "Activity Result (Multiple students and activities)" report link as "HedProgramAdmin"
Then I should open "Options for Activity Results (Multiple students and activities)" criteria page as "HedProgramAdmin"
When I select "MyITLabOffice2013Program" section under "MyITLabForOffice2013Master" template in 'Section Options'
And I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" asset in "Select Activities" by "HedProgramAdmin"
And I 'Select All' in 'Student Options' by "HedProgramAdmin"
And I select 'save settings to My Reports' option by "HedProgramAdmin"
And I click on the "Run Report" button in reports by "HedProgramAdmin"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the "MyItLabActivityResultsMultipleStudentsAdActivities" report name
And I click on "SaveandRun" button
Then I should see the "Activities: Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" with average score "50%"
And I should see 'Zero' "CsSmsStudent" along with section "MyITLabOffice2013Program" attempt as "1" submitted as score as "0.00%"
And I should see the "CsSmsStudent" along with section "MyITLabOffice2013Program" attempt as "2" submitted as score as "100.00%"
When I close the "Activity Results (Multiple students and activities)" window
And I click on the "Cancel" button in reports by "HedProgramAdmin"
And I select "Run Report" for "MyItLabActivityResultsMultipleStudentsAdActivities" report in 'My Reports' grid by "HedProgramAdmin"
Then I should be on the "Activity Results (Multiple students and activities)" page
And I close the "Activity Results (Multiple students and activities)" window

#Purpose : Generate "Training Frequency Analysis" Report by Program Admin
#Test Case Id: peg-21962
#MyITLabOffice2013Program
Scenario:To run and save "Training Frequency Analysis" Report by Program Admin
When I navigate to "Reports" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I click on "Training Frequency Analysis" report link as "HedProgramAdmin"
Then I should open "Options for Training Frequency Analysis" criteria page as "HedProgramAdmin"
When I select "MyITLabOffice2013Program" section under "MyITLabForOffice2013Master" template in 'Section Options'
And I select "Excel Chapter 1 Skill-Based Training" asset in "Select Trainings" by "HedProgramAdmin"
And I select 'save settings to My Reports' option by "HedProgramAdmin"
And I click on the "Run Report" button in reports by "HedProgramAdmin"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the "MyITLabTrainingFrequencyAnalysis" report name
And I click on "SaveandRun" button
Then I should be on the "Training Frequency Analysis" page
And I should see the "Excel Chapter 1 Skill-Based Training" along with average score "50%"
And I should see the question details "XL Activity 1.01: Starting Excel, Navigating Excel, and Naming and Saving a Workbook" "MyITLabOffice2013Program" "Excel 2013" "50.00%"
And I should see the question details "XL Activity 1.02: Entering Text, Using AutoComplete, and Using the Name Box to Select a Cell" "MyITLabOffice2013Program" "Excel 2013" "50.00%"
When I close the "Activity Results (Multiple students and activities)" window
And I click on the "Cancel" button in reports by "HedProgramAdmin"
And I select "Run Report" for " MyITLabTrainingFrequencyAnalysis" report in 'My Reports' grid by "HedProgramAdmin"
Then I should be on the "Training Frequency Analysis" page
When I close the "Training Frequency Analysis" window

#Purpose: To run and save the "Exam Frequency Analysis" Report by Program Admin
#Test Case Id: peg-21947
#MyITLabOffice2013Program
Scenario: To run and save "Exam Frequency Analysis" Report by Program Admin
When I navigate to "Reports" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I click on "Exam Frequency Analysis" report link as "HedProgramAdmin"
Then I should open "Options for Exam Frequency Analysis" criteria page as "HedProgramAdmin"
When I select "MyITLabOffice2013Program" section under "MyITLabForOffice2013Master" template in 'Section Options'
And I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" asset in "Select Exams" by "HedProgramAdmin"
And I select 'save settings to My Reports' option by "HedProgramAdmin"
And I click on the "Run Report" button in reports by "HedProgramAdmin"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the " MyITLabExamFrequencyAnalysis" report name
And I click on "SaveandRun" button
Then I should be on the "Exam Frequency Analysis" page
And I should see the "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" along with average score "50%"
And I should see details of the question "WD Activity 1.01: Starting a New Word Document" "MyITLabOffice2013Program" "SIM5 Question" "Word 2013" "50.00%"
And I should see details of the question "WD Activity 1.02: Inserting Text from Another Document" "MyITLabOffice2013Program" "SIM5 Question" "Word 2013" "50.00%"
When I close the "Exam Frequency Analysis" window
And I click on the "Cancel" button in reports by "HedProgramAdmin"
And I select "Run Report" for " MyITLabExamFrequencyAnalysis" report in 'My Reports' grid by "HedProgramAdmin"
Then I should be on the "Exam Frequency Analysis" page
And I close the "Exam Frequency Analysis" window

#Purpose: To run and save the "Learning Aid Usage" Report by Program Admin
#Test Case Id: peg-22192
#MyITLabOffice2013Program
Scenario: To run and save "Learning Aid Usage" Report by Program Admin
When I navigate to "Reports" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I click on "Learning Aid Usage" report link as "HedProgramAdmin"
Then I should open "Options for Learning Aid Usage" criteria page as "HedProgramAdmin"
When I select "MyITLabOffice2013Program" section under "MyITLabForOffice2013Master" template in 'Section Options'
And I select the "Word Chapter 1 Skill-Based Training" asset in'Select Activity'
And I select 'save settings to My Reports' option by "HedProgramAdmin"
And I click on the "Run Report" button in reports by "HedProgramAdmin"
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And I enter the " MyITLabExamFrequencyAnalysis" report name
And I click on "SaveandRun" button
Then I should see  "Word Chapter 1 Skill-Based Training" along with average score "100.00%"
Then I should see the details for the question "WD Activity 1.01: Starting a New Word Document" "SIM5" "MyITLabOffice2013Program" "Word 2013" "100.00" "--"
And I should see the details for the question "WD Activity 1.02: Inserting Text from Another Document" "SIM5" "MyITLabOffice2013Program" "Word 2013" "--" "100.00"
When I close the "Learning Aid Usage" window
And I click on the "Cancel" button in reports by "HedProgramAdmin"
And I select "Run Report" for " MyITLabExamFrequencyAnalysis" report in 'My Reports' grid by "HedProgramAdmin"
And I click  "Close" button


#Purpose: To generate and save the "Integrity Violation" Report by Program Admin
#Test Case Id: peg-22132
#MyITLabOffice2013Program
Scenario: To generate and save the "Integrity Violation" Report by Program Admin
When I navigate to "Reports" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I click on "Integrity Violation" report link as "HedProgramAdmin"
Then I should be on "Student Integrity Violation" page as HedProgramAdmin
When I select section ID from the dropdown in "MyITLabOffice2013Program" course
And I click  "Generate Report" button
Then I should see row "1" in the report "ZeroScore" for "CsSmsStudent" "Word Chapter 1 Grader Project [Assessment 3]" with "Document Level" "Yes" column details
And I should see row "3" in the report "CsSmsStudent" "Word Chapter 1 Grader Project [Assessment 3]" "Document Level" "Yes" column details
And I close the "Student Integrity Violation" window

#Purpose: To view Availability of 'Certificate of Completion (Custom) Report Link Under Report Tab
#Test Case Id: peg-2142
#MyITLabOffice2013Program
Scenario: To View Availability of 'Certificate of Completion (Custom) Report Link Under Report Tab
When I navigate to "Reports" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
And I should see "Certificate of Completion (Custom)" report under report page
When I click on "Certificate of Completion (Custom)" report link as "HedProgramAdmin"
Then I should see "Options for Certificate of Completion (Custom)" header present


	                
					  