Feature: PEGASUS-674 Create notification for Instructors to know that comments have been viewed by student
						As a Hed Core Instructor
						I want to verify the functionality of "Unread Comments" channel
						so that students who are unread the comments should list.

#Purpose: Open HigherEducation Course space URL
Background:  
Given I browsed the login url for "HedCoreAcceptanceInstructor"

#Purpose: Student activity submission
Scenario: Manually Gradable Activity Submission by Student
When  I logged into the Pegasus as "HedCoreAcceptanceStudent" in "CourseSpace"
Then  I should logged in successfully
Given I am on the "Global Home" page
When  I enter in the "HedCoreAcceptanceProgramCourse" from the Global Home page as "HedCoreAcceptanceStudent"
Then  I should be on the "Today's View" page
When  I navigate to the "Course Materials" tab
Then  I should be on the "Course Materials" page
When  I open the 'Manually Gradable' activity
And   I submit the 'Manually Gradable' activity
Then  I should see the status of manually gradable activity as "Submitted"
When  I "Sign out" from the "HedCoreAcceptanceStudent"
Then  I should see the successfull message "You have been signed out of the application."

#Purpose : To View Manually Graded grades by the Instructor in Cs
Scenario: Manually Grade the Activity by Instructor
When  I logged into the Pegasus as "HedCoreAcceptanceInstructor" in "CourseSpace"
Then  I should logged in successfully
Given I am on the "Global Home" page
When  I enter in the "HedCoreAcceptanceProgramCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
Then  I should be on the "Today's View" page
When  I navigate to the "Gradebook" tab
And   I manually grade the activity in gradebook
Then  I should be on the "Gradebook" page
When  I "Sign out" from the "HedCoreAcceptanceInstructor"
Then  I should see the successfull message "You have been signed out of the application."

#Purpose: To check presens of "Unread Comments" channel in TV HED course space
Scenario: To make sure that "Unread Comments" channel exits in the HED Core course
When  I logged into the Pegasus as "HedCoreAcceptanceInstructor" in "CourseSpace"
Then  I should logged in successfully
Given I am on the "Global Home" page
When  I enter in the "HedCoreAcceptanceProgramCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
Then  I should be on the "Today's View" page
When  I select the "Unread Comments" tab
Then  I should see the "Students listed here have the following unread comments" and student in "Unread comments frame"
When  I click on student tree view expand icon
Then  I should see the activity name "HomeWork: Manual gradable" in the page
When  I "Sign out" from the "HedCoreAcceptanceInstructor"
Then  I should see the successfull message "You have been signed out of the application."
