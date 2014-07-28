Feature: PEGASUS-674 Create notification for Instructors to know that comments have been viewed by student
						As a Hed Core Instructor
						I want to verify the functionality of "Unread Comments" channel
						so that students who are unread the comments should list.

# Used HedCoreAcceptanceProgramCourse
#Purpose: Student activity submission
Scenario: Manually Gradable Activity Submission by Student
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When  I open the 'Manually Gradable' activity
And   I submit the 'Manually Gradable' activity
Then  I should see the status of manually gradable activity as "Submitted"

# Used HedCoreAcceptanceProgramCourse
#Purpose : To View Manually Graded grades by the Instructor in Cs
Scenario: Manually Grade the Activity by Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I manually grade the activity in gradebook
Then  I should be on the "Gradebook" page

#Purpose: To check presens of "Unread Comments" channel in TV HED course space
Scenario: To make sure that "Unread Comments" channel exits in the HED Core course by Instructor
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
When  I select the "Unread Comments" tab
Then  I should see the "Students listed here have the following unread comments" and student in "Unread comments frame"
When  I click on student tree view expand icon
Then  I should see the activity name "HomeWork: Manual gradable" in the page
