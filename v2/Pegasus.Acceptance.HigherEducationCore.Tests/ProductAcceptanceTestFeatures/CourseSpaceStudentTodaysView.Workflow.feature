Feature: CourseSpaceStudentTodaysView
	                As a CS Student 
					I want to manage all the coursespace student Today's View related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: Open Student Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To lookup the obtained grades in student side
# TestCase Id: HSS_Core_PWF_410
Scenario: To lookup the obtained grades By SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the "Test" Activity
And I submit the activity in course material
And I navigate to the "Today's View" tab
Then I should successfully see the alert for New Grades
When I click New Grades alert option
Then I should see the successfully submitted "Test" activity name
When I click the cmenu option 'ViewAllSubmissions' in student side
Then I should see the grade "100" in view submission page
When I close the "View Submission" window
And I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."


#Usecase To View and Read Mail Message
#TestCase Id: HSS_Core_PWF_171
Scenario: View Mail Message by Cs Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Communicate" tab
And I select 'Mail' option
Then I should see the mail message sent by "CsSmsInstructor" 
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."
