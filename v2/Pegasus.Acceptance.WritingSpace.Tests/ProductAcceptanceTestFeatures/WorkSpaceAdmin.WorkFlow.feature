Feature: WorkSpaceAdmin
					As a WS Admin 
					I want to manage all the workspace admin related usecases 
					so that I would validate all the workspace admin scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsAdmin"
When I logged into the Pegasus as "HedWsAdmin" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Course Enrollment" page

#Purpose: UseCase To Create New General Course
Scenario: Create New General Course by Ws Admin 
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "HEDGeneral" course by selecting "General Course" format
Then I should see the successfull message "New course created successfully."
When I search "HEDGeneral" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "HEDGeneral" course in Manage Courses frame
When I "Sign out" from the "HedWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Create Ws User(s) 
Scenario: Create Teacher by Ws Admin 
When I click on the "Create New User" link in "left" frame
Then I should see the "Create New User" popup
When I create a new "HedWsInstructor" user
Then I should see the successfull message "New user created successfully." 
When I "Sign out" from the "HedWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Enroll Teacher(s) To General Course
Scenario: Enroll Teacher in General Course by WS Admin
When I search "HEDGeneral" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "HEDGeneral" course
When I select the created "HEDGeneral" course
And I select the "HedWsInstructor"
When I enrolled the "HedWsInstructor" in the Master course
Then I should see the successfull message "Instructors enrolled successfully."
When I "Sign out" from the "HedWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To publish the General course
Scenario: Publish General Course by Ws Admin
When I search "HEDGeneral" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "HEDGeneral" course
When I publish the Authored "HEDGeneral" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."
When I "Sign out" from the "HedWsAdmin"
Then I should see the successfull message "You have been signed out of the application."