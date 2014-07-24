Feature: CourseSpaceStudentTodaysView
	                As a CS Student 
					I want to manage all the coursespace student Today's View related usecases 
					so that I would validate all the coursespace student scenarios are working fine.


#Used Instructor Course
#Purpose: To lookup the obtained grades in student side
# TestCase Id: HSS_Core_PWF_410
Scenario: To lookup the obtained grades By SMS Student
When I navigate to "Course Materials" tab of the "Course Materials" page
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


#Used Instructor Course
#Purpose: To lookup the obtained grades in student side
# TestCase Id: HSS_Core_PWF_410
Scenario: To Verify The New Grades By SMS Student
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
And I should successfully see the alert for New Grades
When I click New Grades alert option
Then I should see the successfully submitted "Test" activity name
When I click the cmenu option 'ViewAllSubmissions' in student side
Then I should see the grade "100" in view submission page
When I close the "View Submission" window

#Used Instructor Course
#Usecase To View and Read Mail Message
#TestCase Id: HSS_Core_PWF_171
Scenario: View Mail Message by Cs Student
When I navigate to "Communicate" tab and selected "Mail" subtab
Then I should be on the "Course Mail" page
And I should see the mail message sent by "CsSmsInstructor" 
