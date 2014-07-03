Feature: CourseSpaceStudentAssets
	                As a CS Student 
					I want to manage all the Student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.


#Purpose: Open Student Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Context menu option  view submission of a Activity in View All Course Materials
#TestCase Id: HED_MIL_PWF_420
Scenario: Context menu option  view submission of a Activity in View All Course Materials
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I open the "SIM5StudyPlan" Activity
Then I should be on the "myitlab Study Plan" page
When I select 'View Grades' option of study plan pre test
When I click on cmenu "View Submissions" of asset "Sim5PreTest"
Then I should be on the "View Submission" page
And I should see the score "0" in View Submission page
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."


#Purpose: Context menu option compose mail of a Activity in  View All Course Materials
#Testcase Id: HED_MIL_PWF_421
Scenario: Context menu option compose mail of a Activity in  View All Course Materials
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I open the "SIM5StudyPlan" Activity
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
And I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."


#Purpose: Context menu option get information of a Activity in  "View All Course Materials
 #Testcase Id : HED_MIL_PWF_422
Scenario: Context menu option get information of a Activity in View All Course Materials
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select cmenu option "GetInformation" of activity "SIM5Activity"
Then I should see the "SIM5Activity" in Information frame
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To verify the behavior of the presentation ,when  “Display feedback”  option is set to : "Never" in activity preferences 
#Test Case Id : HED_MIL_PWF_495
Scenario: To verify the behavior of the presentation when Display feedback option is set to Never in activity preferences 
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the activity named as "HomeWork"
And I submit the "HomeWork" activity
Then I should not see the "Feedback" in the 'Homework Presentation Page'
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To verify the functionality of resource tools usage as a student
#TestCase Id: HED_MIL_PWF_513
Scenario: To verify the functionality of resource tools usage as a student
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I select "Glossary" resource tool from 'Tools' dropdown
Then I should be on the "Glossary" page
When I close the "Glossary" window
And I select "VerbChart" resource tool from 'Tools' dropdown
Then I should see the 'Verb Chart' tool launched successfully
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: When Display correct answers after student submits the activity option is selected At attempt
#TestCase Id:HED_MIL_PWF_492
Scenario: When Display correct answers after student submits the activity option is selected At attempt
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the activity named as "Test"
And I submit the "Test" activity
Then I should see the "Correct Answer" in the 'Test Presentation Page'
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."