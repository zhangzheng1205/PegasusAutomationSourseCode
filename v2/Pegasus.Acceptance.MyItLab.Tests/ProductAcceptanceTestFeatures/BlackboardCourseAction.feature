Feature: BlackboardInstructorCourseAction
	                As a BB Instructor 
					I want to manage all the Blackboard course management usecases 
					so that I would validate all the course mana scenarios are working fine.

Scenario: Blackboard Instructors Selects Course
Given I am on the "My Institution" page of Blackboard
When I Select "PegasusCourse" link
Then I should see "Content" links for Pegasus

#Purpose : Blackboard Instructor validate startsync and stop sync option functionality
Scenario: Blackboard Instructor validate startsync and stop sync
When I select the cmenu "StopLMSSynchronization" of asset "GO! Excel Chapter 1 Skill-Based Exam (Scenario 1)"
Then I should see the successfull message "LMS Synchronization is stopped" in "Gradebook" window
When I select the cmenu "SynchronizewithLMS" of asset "GO! Excel Chapter 1 Skill-Based Exam (Scenario 1)"
Then I should see the successfull message "LMS Synchronization is enabled" in "Gradebook" window

#Purpose : Blackboard Instructor edit grade in gradebook in Pegasus
#MyItLabInstructorCourse
Scenario: Blackboard instructor Edit Grade in Pegasus
When I enter into blackboard course "BBCourse"
Then I should be displayed with "Home Page"
When I click on the "Content" link
And I click on the "Gradebook" link
Then I should be on the "Gradebook" page
When I select "Word Chapter 1 Grader Project [Assessment 3]" in "Gradebook" by "CsSmsInstructor"
And I click on Edit Grade "PegasusEditedGrade" of "BBEditActivity" activity for "BBStudent" in Pegasus
Then I should see the score "PegasusEditedGrade" of "Word Chapter 1 Grader Project [Homework 3] (Project G)" activity for "BBStudent" in Pegasus
When I "Close" from the "BBInstructor"
And I click on the "Grade Center" link
And I click on the "Full Grade Center" link
When I select option "Pearson Custom Tools" form "Manage" dropdown
And I click on the "Refresh Pearson Grades" link
When I click on submit button
And I click on the "Full Grade Center" link 
Then I should see the score "PegasusEditedGrade" for "Word Chapter 1 Grader Project [Homework 3] (Project G)" activity for "BBStudent" in BlackBoard
When I "Logout" of Blackboard as "BBInstructor"

#Purpose : Blackbord student submit the activity
Scenario: BBStudent submit activity
When I enter into blackboard course "BBCourse"
Then I should be displayed with "Home Page"
When I click on the "Content" link
And I click on the "Grades" link
When I navigate to "Course Materials" tab
And I select "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Word Chapter 1 Grader Project [Assessment 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_w01_grader_a3.docx"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Word file for 100%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "Word Chapter 1 Grader Project [Assessment 3]" activity
Then I should see message "Your file, go_w01_grader_a3.docx, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
Then I should see a "Passed" status for the activity "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "100" score "PegasusNewGrade" for the activity "Word Chapter 1 Grader Project [Assessment 3]" in course material page in Pegasus
When I "Close" from the "BBStudent"
When I logout of Pegasus

#Purpose : Blackboard instructor validate the newly submited grades in Pegasus
Scenario: BBInstructor validate new activity submission in Pegasus
When I login to Blackboard Cert as "BBInstructor"
Then I should be logged in successfully as "BBInstructor"
When I enter into blackboard course "BBCourse"
Then I should be displayed with "Home Page"
When I click on the "Content" link
And I click on the "Gradebook" link
Then I should be on the "Gradebook" page
When I select "Word Chapter 1 Grader Project [Assessment 3]" in the "Gradebook" by "CsSmsInstructor"
Then I should see GBSync icon for "Word Chapter 1 Grader Project [Assessment 3]" activity
And I should see the score "PegasusNewGrade" of "Word Chapter 1 Grader Project [Assessment 3]" activity for "BBStudent" in Pegasus
When I "Close" from the "BBInstructor"

#Purpose : Blackboard instructor validate the sync grades in Pegasus
Scenario: BBInstructor validate newly sync grades in Blackboard
When I click on the "Grade Center" link
And I click on the "Full Grade Center" link
When I select option "Pearson Custom Tools" form "Manage" dropdown
And I click on the "Refresh Pearson Grades" link
And I click on submit button
And I click on the "Full Grade Center" link 
Then I should see the score "PegasusNewGrade" for "Word Chapter 1 Grader Project [Assessment 3]" activity for "BBStudent" in BlackBoard