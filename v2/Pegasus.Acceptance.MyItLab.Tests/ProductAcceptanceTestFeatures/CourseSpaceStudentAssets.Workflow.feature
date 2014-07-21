Feature: CourseSpaceStudentAssets
	                As a CS Student 
					I want to manage all the Student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.


#Purpose: Context menu option  view submission of a Activity in View All Course Materials
#TestCase Id: HED_MIL_PWF_420
#MyItLabInstructorCourse
Scenario: Context menu option  view submission of a Activity in View All Course Materials
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the "SIM5StudyPlan" Activity
Then I should be on the "myitlab Study Plan" page
When I select 'View Grades' option of study plan pre test
When I click on cmenu "View Submissions" of asset "Sim5PreTest"
Then I should be on the "View Submission" page
And I should see the score "0" in View Submission page

#Purpose: Context menu option compose mail of a Activity in  View All Course Materials
#Testcase Id: HED_MIL_PWF_421
#MyItLabInstructorCourse
Scenario: Context menu option compose mail of a Activity in  View All Course Materials
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the "SIM5StudyPlan" Activity
Then I should be on the "myitlab Study Plan" page
When I select 'View Grades' option of study plan pre test
When I click on cmenu "View Submissions" of asset "Sim5PreTest"
Then I should be on the "View Submission" page
When I select the submitted activity in View Submission Page
And I select 'Send Message' option in View Submission Page
Then I should be on the "Send Message" page
And I should see the "SendSave as draftCancel" buttons
When I close the "Send Message" window
And I close the "View Submission" window

#Purpose: Context menu option get information of a Activity in  "View All Course Materials
 #Testcase Id : HED_MIL_PWF_422
 #MyItLabInstructorCourse
Scenario: Context menu option get information of a Activity in View All Course Materials
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I select cmenu option "GetInformation" of activity "SIM5Activity"
Then I should see the "SIM5Activity" in Information frame

#Purpose : To verify the behavior of the presentation ,when  “Display feedback”  option is set to : "Never" in activity preferences 
#Test Case Id : HED_MIL_PWF_495
#MyItLabInstructorCourse
Scenario: To verify the behavior of the presentation when Display feedback option is set to Never in activity preferences 
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the activity named as "HomeWork"
And I submit the "HomeWork" activity
Then I should not see the "Feedback" in the 'Homework Presentation Page'

#Purpose: To verify the functionality of resource tools usage as a student
#TestCase Id: HED_MIL_PWF_513
#MyItLabInstructorCourse
Scenario: To verify the functionality of resource tools usage as a student
When I select "Glossary" resource tool from 'Tools' dropdown
Then I should be on the "Glossary" page
When I close the "Glossary" window
And I select "VerbChart" resource tool from 'Tools' dropdown
Then I should see the 'Verb Chart' tool launched successfully

#Purpose: When Display correct answers after student submits the activity option is selected At attempt
#TestCase Id:HED_MIL_PWF_492
#MyItLabInstructorCourse
Scenario: When Display correct answers after student submits the activity option is selected At attempt
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the activity named as "Test"
And I submit the "Test" activity
Then I should see the "Correct Answer" in the 'Test Presentation Page'
