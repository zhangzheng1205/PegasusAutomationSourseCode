Feature: PADMReports
                    As a Program Admin 
					I want to manage all the PADMIN  related reports 
					so that I would validate all the PADMIN report scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "HSSProgramAdmin"
When  I logged into the Pegasus as "HSSProgramAdmin" in "CourseSpace"
Then  I should logged in successfully
Given I am on the "Global Home" page

#Purpose : Generate and save the "Activity Results by Student" as a Program Admin
#Test case ID : peg-22218
#Products : HSS
#Pre condition : This test case is to generate the Activity Results by Student Report across the Sections in the program based on the below activities submissions available in the Course (Refer: Test link peg-22218)
#Dependency : No dependency test can run with existing data
Scenario: Generate and save the "Activity Results by Student" as a Program Admin
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSProgramAdmin"
Then I should be on the "Program Administration" page
When I navigate to the "Reports" tab
And  I clicked on the "Activity Results by Student" report link
Then I should be on the "Program Administration" page
When I select Section
And  I select Activity "Take the Chapter 1 Exam"
And  I select Student
Then I select 'save settings to My Reports' option
When I click on the "Run Report" button in reports
Then I should be on the "Save settings to My Reports" page
When I select "Createnewreport" radiobutton
And  I enter the "HSSActivityResultsByStudent" report name
And  I click on "SaveandRun" button
Then I should see the "Save settings to My Reports" popup closed
And  I should see "ActivityResultByStudent" report launched successfully
When I click on the "Cancel" button in reports
Then I should be on the "Program Administration" page
When I select "Run Report" for "HSSActivityResultsByStudent" report in 'My Reports' grid by "HSSProgramAdmin"
Then I should see "ActivityResultByStudent" report launched successfully
And  I should be on the "Program Administration" page
