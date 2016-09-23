Feature: D2LIntegration
	



#Feature: Instructor selecting a Pegasus course link in home Page
Scenario: D2L Instructor selecting a Pegasus course link in home Page
Given I am on the "Instructor Dashboard" page
When I enter into D2L direct course "D2LKioskCourse" as "D2LKioskTeacher1"
Then I should be on the "Homepage" page

#Purpose:D2L Instructor selecting a MMND course link
Scenario: D2L User selecting a MMND course link
When I select "Pearson's Mylab and Mastering" course link 
Then I should see "Pearson MyLab and Mastering" Page

#Purpose:
Scenario: D2L User accessing Pegasus from MMND
When Instructor access "D2LPegasusKioskCourse" Link
#Then I should be on the "Pearson" page

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
Given I am on the "Homepage" page
When I enter into D2L direct course "D2LKioskCourse" as "D2LKioskStudent1"
Then I should be on the "Homepage" page

Scenario: D2L Student selecting a MMND course link
When I select "Pearson's Mylab and Mastering" course link 
Then I should see "Pearson MyLab and Mastering" Page

#Feature:Instructor Logout from D2L Kiosk
Scenario:Instructor Logout from D2L Kiosk
When I Sign Out from the D2L Kiosk as "D2LKioskTeacher1"

#Feature:Student Logout from D2L Kiosk
Scenario:Student Logout from D2L Kiosk
When I Sign Out from the D2L Kiosk as "D2LKioskStudent1"