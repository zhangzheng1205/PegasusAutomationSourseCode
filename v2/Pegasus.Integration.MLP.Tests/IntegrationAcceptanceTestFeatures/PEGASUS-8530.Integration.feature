Feature: PEGASUS-8530: Enable 'Synchronize with LMS' preference of Activity in Gradebook
				As a ECollege Teacher
				I want to launch ECollege course and navigate to Pegasus window 
				so that I would enable 'Synchronize with LMS' preference of activity in Gradebook.

#Purpose: Login on ECollege Portal as ECollege Teacher and click on Course.
Background: Login as ECollege Teacher on ECollege Portal URL
Given I browsed the ECollege URL as "ECollegeTeacher"
When I login to Pearson TPI Cert as "ECollegeTeacher"
Then I should logged in successfully on ECollege
Given I am on the "Home PSH" page
When I click on "Academics PSH" Option on Home PSH page
Then I should be on the "Academics PSH" page
When I enter inside "ECollege" course
And I click on Enter Course Link option
Then I should be on the "Today's View" launched Pegasus popup window

#Purpose: Enable 'Synchronize with LMS' preference of activity in Gradebook. 
Scenario: Enable 'Synchronize with LMS' preference of activity in Gradebook
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate to the "Grades" tab
Then I should be on the "Gradebook" page
And I should see the grades for submitted activity
When I click on Synchronize with LMS of submitted activity
Then I should see the successfull message "LMS Synchronization is enabled"
When I close "Gradebook" presentation window
And I click on "Exit Course" button from bottom left frame
And I "Signoff" from the "ECollegeStudent"
Then I should be on the "Pearson TPI Cert| WELCOME" page






 
 