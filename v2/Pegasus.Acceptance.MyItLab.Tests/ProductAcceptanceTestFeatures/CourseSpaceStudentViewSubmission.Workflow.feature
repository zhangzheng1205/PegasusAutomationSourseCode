Feature: CourseSpaceStudentViewSubmission
					As a CS Student 
					I want to manage all the coursespace student Submission related usecases 
					so that I would validate all the coursespace student Submission scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose : To verify the functionality of “Submit for grading” button in presentation window
#Test Case Id : HED_MIL_PWF_424,HED_MIL_PWF_491
Scenario: Verify the Basic Random Activity of “Submit for grading” button in presentation window By SMS Student
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the activity named as "Test"
And I submit the "Test" activity
Then I should see the "Feedback" in the 'Test Presentation Page'
When I close the Test Presentation Page
Then I should see the "Passed" status of the "Test" activity type
And I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To verify the functionality of View Submission option in student side, for different status of Activity
#Test Case Id : HED_MIL_PWF_434
Scenario: To verify the functionality of View Submission status of Activity in student side By SMS Student
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the activity named as "HomeWork"
And I submit the activity "HomeWork" save for later
Then I should see the "In Progress" status of the "HomeWork" activity type
And I should be on the "Course Materials" page
When I navigate to the "Grades" tab
And I click on cmenu "View Submissions" of asset "HomeWork" in grades tab
Then I should be on the "View Submission" page
And I should see the message "Activity has been started and saved for later but not yet submitted."
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Status of Manual Gradable Activity
#Test Case Id : HED_MIL_PWF_509
Scenario: Status of Manual Gradable Activity By SMS Student
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see the "Not started" status of the "Quiz" activity type
When I open the activity named as "Quiz"
And I submit the activity "Quiz" save for later
Then I should see the "In Progress" status of the "Quiz" activity type
When I open the activity named as "Quiz"
And I submit the manual gradable "Quiz" activity
Then I should see the "Submitted" status of the "Quiz" activity type
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check the Status of Edited Instructor Manual Gradable Activity
#Test Case Id : HED_MIL_PWF_509
Scenario: Check the Status of Edited Instructor Manual Gradable Activity By SMS Student
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see the "Passed" status of the "Quiz" activity type
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."