Feature: CourseSpaceStudentReport
	                 As a CS Student 
					I want to manage all the coursespace student Report related usecases 
					so that I would validate all the coursespace student Report scenarios are working fine.

#Purpose :To check the functionality of the view submission report
#TestCase Id : HED_MIL_PWF_957
#MyItLabInstructorCourse
Scenario: To check the functionality of the view submission report by SMS Student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'View Submissions' cmenu option of "SIM5StudyPlan" which has been submitted
Then I should see the total submission "1/1"
And I should see the score "0" in view submission page
When I close the "View Submission" window

#Purpose : To check the functionality of the view button in report page
#TestCase Id : HED_MIL_PWF_953
#MyItLabInstructorCourse
Scenario: To Check the Functionality of the View Button in Report page by SMS Student
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I click on the "SIM5StudyPlan" 'View Grades' option 
And I click on cmenu "View Report" of asset "Sim5PreTest"
Then I should be on the "StudyPlan Summary Report" page
When I click the 'View' button in report
Then I should see the attempt by the student submission "1/1"
When I close the "View Submission" window
And I close the "StudyPlan Summary Report" window

#Purpose : To check the functionality of the close button in reports page
#TestCase Id : HED_MIL_PWF_956
#MyItLabInstructorCourse
Scenario: To check the functionality of the close button in reports page by SMS Student
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I click on the "SIM5StudyPlan" 'View Grades' option 
And I click on cmenu "View Report" of asset "Sim5PreTest"
Then I should be on the "StudyPlan Summary Report" page
When I click the close button in report page