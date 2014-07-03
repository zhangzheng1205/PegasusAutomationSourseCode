Feature: PEGASUSU-3787(1) - Create Course Copy by WS Admin
						As a WorkSpace Admin 
						I want to create course copy and publish the same
						so that I can create class in Course Space out of it

Background:
#Purpose: Open Ws Url
Given I browsed the login url for "WsAdmin"
When I login to Pegasus as "WsAdmin" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Course Enrollment" page

#Purpose: To Publish Copied Authored Course as Master Library as Test Data
Scenario: Publish Pegasus Course as Master Library by WS Admin
When I search "MasterLibrary" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MasterLibrary" course in Manage Courses frame
When I publish the Copied Authored "MasterLibrary" in workspace as "Master Library"
Then I should see the successfull message "Course published successfully."
When I "Sign out" from the "WsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#purpose: To Create Copy Of Authored Course as Test Data
Scenario: Create Pegasus Course Copy by WS Admin
When I search "DigitsAuthoredCourse" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "DigitsAuthoredCourse" course in Manage Courses frame
When I create course copy as "MasterLibrary" in workspace
Then I should see the successfull message "Copied as master course."
When I verify the course "MasterLibrary" for AssignedToCopy state by "CourseName" and "Equals" dropdown option
Then I should see the copied course out of Assigned to Copy State
And I should see the searched "MasterLibrary" course in Manage Courses frame
When I "Sign out" from the "WsAdmin"
Then I should see the successfull message "You have been signed out of the application."