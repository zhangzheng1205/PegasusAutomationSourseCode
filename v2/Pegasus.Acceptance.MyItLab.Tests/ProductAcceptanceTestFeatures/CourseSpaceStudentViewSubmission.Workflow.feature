Feature: CourseSpaceStudentViewSubmission
					As a CS Student 
					I want to manage all the coursespace student Submission related usecases 
					so that I would validate all the coursespace student Submission scenarios are working fine.

#Purpose : To verify the functionality of “Submit for grading” button in presentation window
#Test Case Id : HED_MIL_PWF_424,HED_MIL_PWF_491
#MyItLabInstructorCourse
Scenario: Verify the Basic Random Activity of “Submit for grading” button in presentation window By SMS Student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the activity named as "Test"
And I submit the "Test" activity
Then I should see the "Feedback" in the 'Test Presentation Page'
When I close the Test Presentation Page
Then I should see the "Passed" status of the "Test" activity type

#Purpose : To verify the functionality of View Submission option in student side, for different status of Activity
#Test Case Id : HED_MIL_PWF_434
#MyItLabInstructorCourse
Scenario: To verify the functionality of View Submission status of Activity in student side By SMS Student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the activity named as "HomeWork"
And I submit the activity "HomeWork" save for later
Then I should see the "In Progress" status of the "HomeWork" activity type
And I should be on the "Course Materials" page
When I navigate to the "Grades" tab
And I click on cmenu "View Submissions" of asset "HomeWork" in grades tab
Then I should be on the "View Submission" page
And I should see the message "Activity has been started and saved for later but not yet submitted."

#Purpose : Status of Manual Gradable Activity
#Test Case Id : HED_MIL_PWF_509
#MyItLabInstructorCourse
Scenario: Status of Manual Gradable Activity By SMS Student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see the "Not started" status of the "Quiz" activity type
When I open the activity named as "Quiz"
And I submit the activity "Quiz" save for later
Then I should see the "In Progress" status of the "Quiz" activity type
When I open the activity named as "Quiz"
And I submit the manual gradable "Quiz" activity
Then I should see the "Submitted" status of the "Quiz" activity type

#Purpose : Check the Status of Edited Instructor Manual Gradable Activity
#Test Case Id : HED_MIL_PWF_509
#MyItLabInstructorCourse
Scenario: Check the Status of Edited Instructor Manual Gradable Activity By SMS Student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see the "Passed" status of the "Quiz" activity type

#Purpose : (Activity types and tools) Sim5 assessment launch when "Trap ALT + TAB" is disabled
Scenario: Sim5 assessment launch when "Trap ALT + TAB" is disabled
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the activity named as "Test"
Then I should see the activity successfully launched in browser normal mode
When I close the "Launch" window
Then I should be on the "Course Materials" page

Scenario:To verify the attempts for past due activity by SMS student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I launch the activity named as "Excel Chapter 1: End-of-Chapter Quiz" in Course Materials
Then I should be on the "Objective-Based Question Only" page
And I should see the message "This activity is past due." in activity presentation page
When I submit the past due "Objective-Based Question Only" activity
Then I should see the message "You submitted this activity after the due date. Your instructor must accept the submission before it is included in the gradebook or counted in any course scores." in activity presentation page
And I should return to parent window
