Feature: CourseSpaceInstructorReport
	                As a CS Instructor 
					I want to manage all the coursespace instructor report related usecases 
					so that I would validate all the coursespace instructor report related scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose : Report request : Activity Results (Single Student) 
#Test Case Id :HED_MIL_PWF_935
Scenario: Activity Results for Single Student by Program Admin
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And I click on "Activity Results (Single Student)" report in 'Activity Reports' panel
And I select options to generate report
And I click on the "Run Report" button in reports
Then I should see the score "100" of "SIM5Activity" activity of behavioral mode "SkillBased" type under launched report
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : "Save and Run" functionality for Study Plan single student report 
#Test Case Id :HED_MIL_PWF_978
Scenario: Save and Run functionality for Study Plan single student report
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
And I navigate to the "Reports" tab
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
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To verify the functionality of "Run Report" button in the Options Page (with valid details added in the fields provided) 
#Test Case Id :HED_MIL_PWF_963
Scenario: To verify the functionality of "Run Report" button in the Options Page (with valid details added in the fields provided)
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
And I navigate to the "Reports" tab
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
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Report request : Activity Results (Single Student) 
#Test Case Id : HED_MIL_PWF_965
Scenario: Activity Results for Single Student by SMS Instructor
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
And I navigate to the "Reports" tab
When I click on "ActivityResultsSingleStudent" report type
And I select options to generate report by instructor for "Test"
And I click on "Run Report" button in reports
Then I should see the score "100" in Activity Result Single Student generated report
When I close the "Activity Results (Single Student)" window
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To verify the functionality of "Most Recent" radio button
#Test Case Id : HED_MIL_PWF_972
Scenario: To verify the functionality of "Most Recent" radio button by SMS Instructor
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
And I navigate to the "Reports" tab
Then I should be on the "Reports" page
When I click on "ExamFrequencyAnalysis" report type
And I enter the exam frequency analysis valid data in the fields to generate report
And I click on "Run Report" button in reports
Then I should see the score "100" in Exam Frequency Analysis generated report
When I close the "Exam Frequency Analysis" window
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Certificate of Competition Exam based PADMIN
#Test Case Id :HED_MIL_PWF_958
Scenario: Certificate of Competition Exam based PADMIN
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And I click on "Certificate of Completion (Exam)" certificate report in 'Activity Reports' panel
And I select options for 'Certificate of Completion Exam'
And I click on the "Run Report" button in reports
Then I should be on the "Certificate of Completion (Exam)" page
And I should see the exam score "100.00%" in 'Certificate of Completion Exam' page
When I close the "Certificate of Completion (Exam)" window
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Certificate of Competition Training based 
#Test Case Id : HED_MIL_PWF_968
Scenario: Certificate of Competition Training based By SMS Instructor
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
And I navigate to the "Reports" tab
Then I should be on the "Reports" page
When I click on "CertificateofCompletionTraining" certificate type
And I enter the valid data in the fields to generate certificate
And I click on "Run Report" button in reports
Then I should see the training score "100.00%" in 'Certificate of Completion Training' certificate
When I close the "Certificate of Completion (Training)" window
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Certificate of Competition Exam based 
#Test Case Id : HED_MIL_PWF_967
Scenario: Certificate of Competition Exam based By SMS Instructor
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
And I navigate to the "Reports" tab
Then I should be on the "Reports" page
When I click on "CertificateofCompletionExam" certificate type
And I enter the valid data in the fields to generate certificate for Exam report
And I click on "Run Report" button in reports
Then I should see the exam score "100.00%" in 'Certificate of Completion Exam' page
When I close the "Certificate of Completion (Exam)" window
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."