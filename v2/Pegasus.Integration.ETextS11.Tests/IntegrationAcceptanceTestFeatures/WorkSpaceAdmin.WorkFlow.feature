Feature: WorkSpaceAdmin
					As a WS Admin 
					I want to manage all the workspace admin related usecases 
					so that I would validate all the workspace admin scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsAdmin"
When I login to Pegasus as "HedWsAdmin" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Course Enrollment" page

#Purpose: UseCase To Create Ws User(s) 
Scenario: Create Teacher by Ws Admin 
When I click on the "Create New User" link in "left" frame
Then I should see the "Create New User" popup
When I create a new "HedWsInstructor" user
Then I should see the successfull message "New user created successfully." 
When I "Sign out" from the "HedWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Create Master Course 
Scenario: Create Master Course by Ws Admin
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "MySpanishLabMaster" course by selecting "General Course" format
Then I should see the successfull message "New course created successfully."
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MySpanishLabMaster" course in Manage Courses frame

#Purpose: UseCase To Enroll User(s) To Master Course
Scenario: Enroll Teacher in Master Course by WS Admin
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MySpanishLabMaster" course
When I select the created "MySpanishLabMaster" course
And I select the "HedWsInstructor"
When I enrolled the "HedWsInstructor" in the Master course
Then I should see the successfull message "Instructors enrolled successfully."
When I "Sign out" from the "HedWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To publish the authored master course
@PublishCourse
Scenario: Publish Master Course by Ws Admin
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MySpanishLabMaster" course
When I publish the Authored "MySpanishLabMaster" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."
When I "Sign out" from the "HedWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

