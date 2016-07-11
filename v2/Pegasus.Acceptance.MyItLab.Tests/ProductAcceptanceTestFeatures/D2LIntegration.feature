Feature: D2LIntegration
	



#Feature: Instructor selecting a Pegasus course link in home Page
Scenario: D2L Instructor selecting a Pegasus course link in home Page
Given I am on the home page of DesiretoLearn
When I select "516 CGIE Kiosk Course" course link in Select Courses
Then I should see "Homepage - 516 CGIE Kiosk Course" Page

Scenario: D2L Instructor selecting a MMND course link
Given User is on the "Homepage - 516 CGIE Kiosk Course" page
When I select "Pearson's Mylab and Mastering" course link 
Then I should see "Pearson MyLab and Mastering" Page

Scenario: D2L Instructor accessing Pegasus from MMND
#Given Instructor is on the "Pearson MyLab and Mastering" Page
When Instructor access "MyITLab Course Home" Link
Then I should be on the "Pearson" page

Scenario: D2L Instructor accessing Pegasus from Portal
#Given Instructor is on the "Pearson" Page
When Instructor clicks "Instructor Tools" Link
Then I should be on the "Instructor Tools" page

Scenario: D2L Instructor accessing Gradebook from Portal
#Given Instructor is on the "Pearson" Page
When Instructor selects "Gradebook" Link
Then I should be on the Pegasus Gradebook page

Scenario: D2L Instructor searching a synched activity in Gradebook
#Given Instructor is on the "Pearson" Page
When Instructor searches "Chapter 1 Exam" assessment
Then I should see "Chapter 1 Exam" on Pegasus Gradebook page

Scenario: D2L Instructor editing activity in Gradebook
#Given Instructor is on the "Pearson" Page
When Instructor edits "Chapter 1 Exam" assessment to 80%
Then I should see 80% for "Chapter 1 Exam" on Pegasus Gradebook page


#Feature: Student selecting a Pegasus course link in home Page
Scenario: D2L Student selecting a Pegasus course link in home Page
Given I am on the home page of DesiretoLearn
When I select "D2L Kiosk Integration for Automation - Pegasus" course link in Select Courses
Then I should see "Homepage - D2L Kiosk Integration for Automation - Pegasus" Page

Scenario: D2L Student selecting a MMND course link
Given User is on the "Homepage - D2L Kiosk Integration for Automation - Pegasus" page
When I select "Pearson's Mylab and Mastering" course link 
Then I should see "Pearson MyLab and Mastering" Page