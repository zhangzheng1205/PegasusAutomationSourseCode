Feature: PEGASUS-9358: Launch Etext By ECollege Student
					As a ECollege Student
					I want to launch eText activity related usecases 
					so that I would validate the eText activity launch scenarios are working fine.

#Purpose: Login on ECollege Portal as ECollege Student and click on Course.
Background: Login as ECollege Student on ECollge Portal URL
Given I browsed the ECollege URL as "ECollegeStudent"
When I login to Pearson TPI Cert as "ECollegeStudent"
Then I should logged in successfully on ECollege
Given I am on the "Home PSH" page
When I click on "Academics PSH" Option on Home PSH page
Then I should be on the "Academics PSH" page
When I enter inside "ECollege" course
And I click on Enter Course Link option
Then I should be on the "Today's View" launched Pegasus popup window

#Purpose: Launch eText by ECollege Student.
Scenario: Launch eText by ECollege Student
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the "eText" Activity 
Then I should see the 'etext' launched successfully
When I close etext "Pearson eText" presentation window
And I close "Course Materials" presentation window
And I click on "Exit Course" button from bottom left frame
And I "Signoff" from the "ECollegeStudent"
Then I should be on the "Pearson TPI Cert| WELCOME" page

