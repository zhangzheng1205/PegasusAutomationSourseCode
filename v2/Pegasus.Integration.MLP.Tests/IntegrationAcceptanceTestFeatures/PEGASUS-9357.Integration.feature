Feature: PEGASUS-9357: Launch Etext By ECollege Instructor
					As a ECollege Teacher
					I want to manage eText activity related usecases 
					so that I would validate all the eText activity scenarios are working fine.

#Purpose: Login on ECollege Portal as ECollege Teacher and click on Course.
Background: Login as ECollege Teacher on ECollge Portal URL
Given I browsed the ECollege URL as "ECollegeAdmin"
When I login to Pearson TPI Cert as "ECollegeTeacher"
Then I should logged in successfully on ECollege
Given I am on the "Home PSH" page
When I click on "Academics PSH" Option on Home PSH page
Then I should be on the "Academics PSH" page
When I enter inside "ECollege" course
And I click on Enter Course Link option
Then I should be on the "Today's View" launched Pegasus popup window

#Purpose: To Add eTextLink in course material tab by ECollege Teacher.
Scenario: To Add eTextLink in course material tab by ECollege Teacher
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add eText Link" activity type
And I create "eText" activity
Then I should see the successfull message "eText link saved successfully." in "Course Materials" window
And I should see the "eText" Activity in the MyCourse Frame
When I click on 'ShowHide' option of Activity
And I close "Course Materials" presentation window
And I click on "Exit Course" button from bottom left frame
And I "Signoff" from the "ECollegeTeacher"
Then I should be on the "Pearson TPI Cert| WELCOME" page

#Purpose: Launch eText by ECollege teacher.
Scenario: Launch eText by ECollege teacher
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to the "Manage Course Materials" tab
Then I should be on the "Course Materials" page
When I open the "eText" Activity 
Then I should see the 'etext' launched successfully
When I close etext "Pearson eText" presentation window
And I close "Course Materials" presentation window
And I click on "Exit Course" button from bottom left frame
And I "Signoff" from the "ECollegeTeacher"
Then I should be on the "Pearson TPI Cert| WELCOME" page