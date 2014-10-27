Feature: CourseSpaceStudent
                    As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: To View CS System Announcement
Scenario: View System Announcement by CS Student
When I navigate to the "Overview" tab
Then I should be on the "Overview" page
When I changed the CS User Time Zone to Indian GMT in MyProfile by "DPCsStudent"
And I click on the Messages and select the View All link by "DPCsStudent"
And  I select "System Announcements" in 'View by' drop down 
Then I should see the details of  "CsSystem" Announcement in Announcement Light box

#Purpose: To View CS Course Announcement
Scenario: View Course Announcement by CS Student
When I navigate to the "Overview" tab
Then I should be on the "Overview" page
When I changed the CS User Time Zone to Indian GMT in MyProfile by "DPCsStudent"
And I click on the Messages and select the View All link by "DPCsStudent"
And  I select "Course Announcements" in 'View by' drop down 
Then I should see the details of  "CsCourse" Announcement in Announcement Light box

#Purpose - View welcome message by the student
Scenario: View Login Welcome Message by CS Student
When I navigate to the "Overview" tab
Then I should be on the "Overview" page
When I close the welcome message
Then I should see the welcome message popup closed successfully for "DPCsStudent"

#Purpose: To View Enrolled Classes in the Overview Tab
Scenario: Display of Enrolled Classes in the Overview Tab by CS Student
When I navigate to the "Overview" tab
Then I should be on the "Overview" page
Then I should see the "DigitalPathMasterLibrary" class present in the overview tab
When I navigate to the "Grades" tab
Then I should be on the "Gradebook" page

#Purpose: To View Assigned Contents in the Overview Tab
Scenario: Display of Assigned Contents in the Overview Tab by CS Student
When I navigate to the "Overview" tab
Then I should be on the "Overview" page
Then I should see the calendar icon for assigned asset
When I click on the calendar icon of assigned asset 
Then I should see the assigned asset "StudyPlan"

#Purpose: UseCase To Validate Home Page Tabs
Scenario: View Classes Tab by CS Student
When I navigate to the "Overview" tab
Then I should be on the "Overview" page
Then I should see the defaults tabs for "DPCsStudent"

#Purpose: UseCase To Access Tabs
Scenario: Access Classes Tab by by CS Student
When I navigate to the "Practice" tab
Then I should able to access the "Practice" tab
When I navigate to the "To Do" tab
Then I should able to access the "Assignments - To Do" tab
When I navigate to the "Overview" tab
Then I should able to access the "Overview" tab

#Usecase To View and Read Mail Message
Scenario: View Mail Message by Cs Student
When I navigate to the "Overview" tab
Then I should be on the "Overview" page
When I enter in the "DPCsStudent" mail inbox
Then I should see the mail message sent by the "DPCsTeacher" 

#Purpose: Submit study plan activity by student in course space
Scenario: Study Plan Submission by CS Student
When I navigate to the "View All Content" tab
Then I should be on the "Content" page
When I open the activity named as "StudyPlan"
And I start the Pre-Test
And I submit the StudyPlan activity
And I click return to course button
Then I should see the status of "StudyPlan" assets as "Completed"

#Purpose: Submit test activity by student in course space
Scenario: Test Activity Submission by CS Student
When I navigate to the "View All Content" tab
Then I should be on the "Content" page
When I open the activity named as "Test"
And I submit the "Test" activity
Then I should see the status of "Test" assets as "Passed"

#Purpose: View Assigned Contents in ToDo Tab by Cs Student
Scenario: Display of Assigned Contents in ToDo Tab by Cs Student
When I navigate to the "To Do" tab
Then I should see the display of assigned asset "Test" in ToDo tab

#Purpose: View Assigned Contents in View All content Tab by Cs Student   
Scenario: View Submission Status of the Test Activity in View All content tab by Cs Student
When I navigate to the "View All Content" tab
Then I should be on the "Content" page
And I should see the status of "Test" assets as "Passed"

#Purpose: View Assigned Contents in View All content Tab by Cs Student
Scenario: View Submission Status of StudyPlan Activity in View All content tab by Cs Student
When I navigate to the "View All Content" tab
Then I should be on the "Content" page
And I should see the status of "StudyPlan" assets as "Completed"

