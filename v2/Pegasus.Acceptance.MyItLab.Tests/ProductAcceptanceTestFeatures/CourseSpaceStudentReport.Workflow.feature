Feature: CourseSpaceStudentReport
	                 As a CS Student 
					I want to manage all the coursespace student Report related usecases 
					so that I would validate all the coursespace student Report scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose :To check the functionality of the view submission report
#TestCase Id : HED_MIL_PWF_957
Scenario: To check the functionality of the view submission report by SMS Student
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'View Submissions' cmenu option of "SIM5StudyPlan" which has been submitted
Then I should see the total submission "1/1"
And I should see the score "0" in view submission page
When I close the "View Submission" window
And I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To check the functionality of the view button in report page
#TestCase Id : HED_MIL_PWF_953
Scenario: To Check the Functionality of the View Button in Report page by SMS Student
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Grades" tab
Then I should be on the "Gradebook" page
When I click on the "SIM5StudyPlan" 'View Grades' option 
And I click on cmenu "View Report" of asset "Sim5PreTest"
Then I should be on the "StudyPlan Summary Report" page
When I click the 'View' button in report
Then I should see the attempt by the student submission "1/1"
When I close the "View Submission" window
And I close the "StudyPlan Summary Report" window
And I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To check the functionality of the close button in reports page
#TestCase Id : HED_MIL_PWF_956
Scenario: To check the functionality of the close button in reports page by SMS Student
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Grades" tab
Then I should be on the "Gradebook" page
When I click on the "SIM5StudyPlan" 'View Grades' option 
And I click on cmenu "View Report" of asset "Sim5PreTest"
Then I should be on the "StudyPlan Summary Report" page
When I click the close button in report page
And I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."