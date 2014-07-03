Feature: WorkSpaceAdmin
	                As a WS Admin 
					I want to manage all the workspace admin related usecases 
					so that I would validate all the workspace admin scenarios are working fine.

#Purpose: Open Ws Url and login as NovaNETWsAdmin
Background: 
Given I browsed the login url for "NovaNETWsAdmin"
When I login to Pegasus as "NovaNETWsAdmin" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Course Enrollment" page

#purpose: UseCase To Create Master Course
Scenario: Create Master Course by WS Admin
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "NovaNETMasterLibrary" course by selecting "General Course" format
Then I should see the successfull message "New course created successfully."
When I search "NovaNETMasterLibrary" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "NovaNETMasterLibrary" course in Manage Courses frame
When I "Sign out" from the "NovaNETWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Create Empty Course
Scenario: Create Empty Course by Ws Admin
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "EmptyClass" course by selecting "General Course" format
Then I should see the successfull message "New course created successfully."
When I search "EmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "EmptyClass" course in Manage Courses frame
When I "Sign out" from the "NovaNETWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Create Container Course
Scenario: Create Container Course by Ws Admin
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "Container" course by selecting "General Course" format
Then I should see the successfull message "New course created successfully."
When I search "Container" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "Container" course in Manage Courses frame
When I "Sign out" from the "NovaNETWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To create Teacher in Workspace
Scenario: Create Teacher by WS Admin
When I click on the "Create New User" link in "left" frame
Then I should see the "Create New User" popup
When I create a new "WsTeacher" user
Then I should see the successfull message "New user created successfully."
When I search the created "WsTeacher" in  Manage Users frame
Then I should see the "WsTeacher" in Manage Users frame
When I "Sign out" from the "NovaNETWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Enroll User To Empty Course
Scenario: Enroll the User to the Empty Course by Ws Admin
When I search "EmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "EmptyClass" course in Manage Courses frame
When I select the created "EmptyClass" course
And I select the "WsTeacher" user
And I enroll the "WsTeacher" in the selected course
Then I should see the successfull message "Teachers enrolled successfully."
And I should see the enrolled "WsTeacher" in the Manage Courses frame
When I "Sign out" from the "NovaNETWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Enroll User To Container Course
Scenario: Enroll the User to the Container Course by Ws Admin
When I search "Container" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "Container" course in Manage Courses frame
When I select the created "Container" course
And I select the "WsTeacher" user
And I enroll the "WsTeacher" in the selected course
Then I should see the successfull message "Teachers enrolled successfully."
And I should see the enrolled "WsTeacher" in the Manage Courses frame
When I "Sign out" from the "NovaNETWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Enroll User To NovaNetMasterLibrary Course
Scenario: Enroll the User to the NovaNetMasterLibrary Course by Ws Admin
When I search "NovaNETMasterLibrary" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "NovaNETMasterLibrary" course in Manage Courses frame
When I select the created "NovaNETMasterLibrary" course
And I select the "WsTeacher" user
And I enroll the "WsTeacher" in the selected course
Then I should see the successfull message "Teachers enrolled successfully."
And I should see the enrolled "WsTeacher" in the Manage Courses frame
When I "Sign out" from the "NovaNETWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To publish the Empty course
Scenario: Publish Empty Course by WsAdmin
When I search "EmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "EmptyClass" course in Manage Courses frame
When I publish the "EmptyClass" course in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."
When I "Sign out" from the "NovaNETWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To publish the Container course
Scenario: Publish Container Course by WsAdmin
When I search "Container" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "Container" course in Manage Courses frame
When I publish the "Container" course in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."
When I "Sign out" from the "NovaNETWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To publish the Master Library
Scenario: Publish Master Library by WsAdmin
When I search "NovaNETMasterLibrary" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "NovaNETMasterLibrary" course in Manage Courses frame
When I publish the "NovaNETMasterLibrary" course in workspace as "Master Library"
Then I should see the successfull message "Course published successfully."
When I "Sign out" from the "NovaNETWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Delete The Created Empty Course In Workspace Admin
Scenario: Delete The Created Empty Course by WS Admin
When I search "EmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "EmptyClass" course in Manage Courses frame
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "EmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message in Manage Course

#Purpose: Delete The Created Container Course In Workspace Admin
Scenario: Delete The Created Container Course by WS Admin
When I search "Container" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "Container" course in Manage Courses frame
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "Container" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message in Manage Course

#Purpose: Delete The Created Master Course In Workspace Admin
Scenario: Delete The Created Master Course by WS Admin
When I search "NovaNETMasterLibrary" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "NovaNETMasterLibrary" course in Manage Courses frame
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "NovaNETMasterLibrary" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message in Manage Course

#Purpose: Delete The Created User In Workspace Admin
Scenario: Delete The Created User by WS admin
When I search the created "WsTeacher" in  Manage Users frame
Then I should see the "WsTeacher" in Manage Users frame
When I click the user cmenu option in manage user frame
And I select the Cmenu option "Delete"
And I select 'OK' option
Then I should see the successfull message "Users deleted successfully."
