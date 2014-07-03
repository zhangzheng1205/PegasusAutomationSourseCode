# Feature Description To Verify Defect US66343
Feature: US66343
In order to verify the defect #US66343 
As a CS Instructor
I want to verify the expected result(s) at Assignment calendar Tab in pegasus


Background: 
# Creation of Test Data : Course Copy
Given Authored course copy already created if not then create the authored course copy

# Creation of Test Data : Publish Course
Given Authored course copy is already published if not then publish the authored course copy

# Creation of Test Data : Approve Course
Given Autohored course is already approved in the course space if not then approve the authored course in course space

# Creation of Test Data : Creation of Program
Given HED program is already created if not then create the HED program

# Creation of Test Data : Creation of General Product
Given HED general type product is already created if not then create a new general type product

# Creation of Test Data : Creation of Program Type Product
Given Program type product is already created if not then create a new program type product

# Creation of Test Data : Association of Authored Course to general Type Product
Given Course association to general type product is already created if not then create association

# Creation of Test Data : Association of Authored Course to program Type Product
Given Course association to program type product is already created if not then create association

# Creation of Test Data : Creation of SMS Instructor
Given SMS user is already created if not then create SMS user 

# Creation of Test Data : Enrollment of SMS user in Instructor Course
Given SMS user is already enrolled into the instructor course if not then enroll the SMS user in instructor course


# To verify Defect at Assignment calendar Tab for assigning study plan
Scenario: US66343_AssigingStudyPlan_AssignmentCalendarTab

Given I have browsed url for "CsSmsInstructor"
When I have logged into the course space as SMS Instructor
Then It should show the "Global Home" page
When I select the course from Global home page
Then It should show the "Calendar" page
And  I navigate to the "Course Materials" Tab
And  I create study plan from course materials tab
And  I navigate to the "Assignment Calendar" Tab
And  I select the study plan and assign to any due date says nth date
And  I clicked on “View Advance calendar”,it will open a calendar wizard and click on nth date
And  I Select the study plan and can find Move button in top of the calendar
And I Click on Move button, it opens calendar pop-up and select n+1 the date
And  I navigate to the "Gradebook" Tab
And  I clicked on the "View Grades" of the study plan column
Then Due dates should show same time at study plan level and which should match with due dates of pre-test and post-test
And  I navigate to the "Assignment Calendar" Tab
And  I unassign the Studyplan
And I assigned any activity along with study plan to any due date say n is the date
And  I clicked on “View Advance calendar”,it will open a calendar wizard and click on nth date
And  I Select the study plan and  Acitivity and can find Move button in top of the calendar
And I Click on Move button, it opens calendar pop-up and select n+1 the date
And  I navigate to the "Gradebook" Tab
And  I clicked on the "View Grades" of the study plan column
Then Due dates should show same time at study plan level and which should match with due dates of pre-test and post-test when assigned with activity


# To verify Defect at Assignment calendar Tab for assigning study plan as pastdue 
Scenario: US66343_AssigingStudyPlan_AssignmentCalendarTab_Pastdue

Given I have browsed url for "CsSmsInstructor"
When I have logged into the course space as SMS Instructor
Then It should show the "Global Home" page
When I select the course from Global home page
Then It should show the "Calendar" page
And  I navigate to the "Assignment Calendar" Tab
And  I unassign the Studyplan
And  I assign the study plan to nth date and ensure that it is past due
And  I Navigate to Today's View tab
And  I go to Past due Not Submitted channel
Then Not Submitted Past due study plan's Pre test,Post test should appear immediately once the study plan is past due 
When I have logged into the course space as SMS Student
Then It should show the "Global Home" page
When I select the course from Global home page
And  I navigate to the "Assignments" Tab
And I navigate to the "Completed" Tab
Then On Launching PreTest and PostTest PastDue Message Should Display for Past Due StudyPlan and submit Pretest and Post
And I clicked on the Logout link to get logged out from the application
When I have logged into the course space as SMS Instructor
Then It should show the "Global Home" page
When I select the course from Global home page
Then It should show the "Calendar" page
And  I Navigate to Today's View tab
And  I go to Past due Submitted channel
Then Submitted Past due study plan's Pre test,Post test should appear immediately once the study plan is past due 
And  I navigate to the "Gradebook" Tab
And  I clicked on the "View Grades" of the study plan column
Then Contents of the container study plan should shown past due to the same nth date for Instructor
#And I clicked on the Logout link to get logged out from the application


# To verify Defect at Assignment calendar Tab for assigning study plan through Properties window
Scenario: US66343_AssigingStudyPlan_AssignmentCalendarTab_Properties window

Given I have browsed url for "CsSmsInstructor"
When I have logged into the course space as SMS Instructor
Then It should show the "Global Home" page
When I select the course from Global home page
Then It should show the "Calendar" page
And  I navigate to the "Course Materials" Tab
And  I create study plan from course materials tab
And  I navigate to the "Assignment Calendar" Tab
And  I assign the study plan to nth date and ensure that it is past due through Properties Window
And I clicked on the Logout link to get logged out from the application
When I have logged into the course space as SMS Student
Then It should show the "Global Home" page
When I select the course from Global home page
And  I navigate to the "Assignments" Tab
And I navigate to the "Completed" Tab
Then On Launching PreTest and PostTest PastDue Message Should Display for StudyPlan done Past Due through Properties Window
And  I clicked on the "View Grades" of the study plan column where study assigned through Properties Window
Then Contents of the container study plan should shown past due to the same nth date for Instructor
And I clicked on the Logout link to get logged out from the application










