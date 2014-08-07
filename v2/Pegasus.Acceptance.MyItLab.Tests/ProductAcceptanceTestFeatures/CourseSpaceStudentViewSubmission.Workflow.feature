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
When I launch the activity named as "Chapter 1 Check Your Understanding: Part 1" in Course Materials
Then I should be on the "Objective-Based Question Only" page
And I should see the message "This activity is past due." in activity presentation page
When I submit the past due "Objective-Based Question Only" activity
Then I should see the message "You submitted this activity after the due date. Your instructor must accept the submission before it is included in the gradebook or counted in any course scores." in activity presentation page
And I should return to parent window


#Purpose : To verify the functionality of View Submission option in student side for save for later
Scenario: To verify the functionality of View Submission status of Activity  for save for later in student side By SMS Student

When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the activity named as "ObjectiveBasedQuestionOnly"
And  I submit the activity "ObjectiveBasedQuestionOnly" for save for later
Then I should see the "In Progress" status of the "ObjectiveBasedQuestionOnly" activity type
When I click on cmenu "ViewSubmissions" of asset "ObjectiveBasedQuestionOnly" for save for later  
Then I should be on the "View Submission" page
When I click on submission list for save for later 
Then I should see the message "Activity has been started and saved for later but not yet submitted." for save for later
And  I should be on the "Course Materials" page

When I navigate to the "Assignments" tab
Then  I should be on the "Course Materials" page
When I click on cmenu "ViewSubmissions" of asset "ObjectiveBasedQuestionOnly" for save for later  
Then I should be on the "View Submission" page
When I click on submission list for save for later 
Then I should see the message "Activity has been started and saved for later but not yet submitted." for save for later
And  I should be on the "Course Materials" page

When I navigate to the "To Do" tab
Then I should be on the "Assignments - To Do" page
When I click on cmenu "ViewSubmissions" of asset "ObjectiveBasedQuestionOnly" for save for later  
Then I should be on the "View Submission" page
When I click on submission list for save for later 
Then I should see the message "Activity has been started and saved for later but not yet submitted." for save for later
And  I should be on the "Assignments - To Do" page

#MyITLabOffice2013Program
#Purpose : Student validating score in gradebook for SIM5 Excel activity
Scenario: Student validating score in gradebook for SIM5 Excel activity By SMS Student
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I select "Excel Chapter 1 Skill-Based Training" in "Gradebook" by "CsSmsStudent"
Then I should see the activity "Excel Chapter 1 Skill-Based Training" score "100"
When I click on cmenu "View Submissions" of asset "Excel Chapter 1 Skill-Based Training" in gradebook
Then I should be on the "View Submission" page
When I close the "View Submission" window

#MyITLabOffice2013Program
#Purpose : Student validating score in gradebook for SIM5 PowerPoint activity
Scenario: Student validating score in gradebook for SIM5 PowerPoint activity By SMS Student
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I select "PowerPoint Chapter 1 Skill-Based Training" in "Gradebook" by "CsSmsStudent"
Then I should see the activity "PowerPoint Chapter 1 Skill-Based Training" score "70"
When I click on cmenu "View Submissions" of asset "PowerPoint Chapter 1 Skill-Based Training" in gradebook
Then I should be on the "View Submission" page
When I close the "View Submission" window

#MyITLabOffice2013Program
#Purpose : Student validating score in gradebook for SIM5 Word activity
Scenario: Student validating score in gradebook for SIM5 Word activity By SMS Student
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Gradebook" by "CsSmsStudent"
Then I should see the activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" score "0"
When I click on cmenu "View Submissions" of asset "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in gradebook
Then I should be on the "View Submission" page
When I close the "View Submission" window

#MyITLabOffice2013Program
#Purpose : Student validating score in gradebook for SIM5 Access activity
Scenario: Student validating score in gradebook for SIM5 Access activity By SMS Student
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I select "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Gradebook" by "CsSmsStudent"
Then I should see the activity "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" score "100"
When I click on cmenu "View Submissions" of asset "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in gradebook
Then I should be on the "View Submission" page
When I close the "View Submission" window
