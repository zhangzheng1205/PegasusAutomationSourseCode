Feature: WorkSpaceAdmin
					As a WS Admin 
					I want to manage all the workspace admin related usecases 
					so that I would validate all the workspace admin scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedMiLWsAdmin"
When I logged into the Pegasus as "HedMiLWsAdmin" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Course Enrollment" page


#Purpose: UseCase To Create New SIM5 Master Course
# TestCase Id: HED_MIL_PWF_011
Scenario: Create New SIM5 Master Course by Ws Admin 
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "MyItLabSIM5MasterCourse" course by selecting "Sim Course" format
Then I should see the successfull message "New course created successfully."
When I search "MyItLabSIM5MasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MyItLabSIM5MasterCourse" course in Manage Courses frame
When I "Sign out" from the "HedMiLWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Create Ws User(s) 
Scenario: Create Teacher by Ws Admin 
When I click on the "Create New User" link in "left" frame
Then I should see the "Create New User" popup
When I create a new "HedWsInstructor" user
Then I should see the successfull message "New user created successfully." 
When I "Sign out" from the "HedMiLWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Enroll User(s) To SIM5 Master Course
Scenario: Enroll Teacher to SIM5 Master Course by WS Admin
When I search "MyItLabSIM5MasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabSIM5MasterCourse" course
When I select the created "MyItLabSIM5MasterCourse" course
And I select the "HedWsInstructor"
When I enrolled the "HedWsInstructor" in the Master course
Then I should see the successfull message "Instructors enrolled successfully."
When I "Sign out" from the "HedMiLWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To publish the authored SIM5 Master Course
Scenario: Publish SIM5 Master Course by Ws Admin
When I search "MyItLabSIM5MasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabSIM5MasterCourse" course
When I publish the Authored "MyItLabSIM5MasterCourse" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."
When I "Sign out" from the "HedMiLWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Create New SIM Course
Scenario: Create New SIM Master Course by Ws Admin 
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "MyItLabSIMMasterCourse" course by selecting "Sim Course" format
Then I should see the successfull message "New course created successfully."
When I search "MyItLabSIMMasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MyItLabSIMMasterCourse" course in Manage Courses frame
When I "Sign out" from the "HedMiLWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Enroll User(s) To SIM Master Course
Scenario: Enroll Teacher to SIM Master Course by WS Admin
When I search "MyItLabSIMMasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabSIMMasterCourse" course
When I select the created "MyItLabSIMMasterCourse" course
And I select the "HedWsInstructor"
When I enrolled the "HedWsInstructor" in the Master course
Then I should see the successfull message "Instructors enrolled successfully."
When I "Sign out" from the "HedMiLWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To publish the authored SIM Master Course
Scenario: Publish SIM Master Course by Ws Admin
When I search "MyItLabSIMMasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabSIMMasterCourse" course
When I publish the Authored "MyItLabSIMMasterCourse" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."
When I "Sign out" from the "HedMiLWsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Delete The Created SIM Master Course In Workspace Admin
Scenario: Delete The Created SIM Master Course by WS admin
When I search "MyItLabSIMMasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MyItLabSIMMasterCourse" course in Manage Courses frame
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "MyItLabSIMMasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message in Manage Course

#Purpose: Delete The Created SIM5 Master Course In Workspace Admin
Scenario: Delete The Created SIM5 Master Course by WS admin
When I search "MyItLabSIM5MasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MyItLabSIM5MasterCourse" course in Manage Courses frame
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "MyItLabSIM5MasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message in Manage Course

#Purpose: UseCase To Create New Empty Course
Scenario: Create New Empty Course by Ws Admin 
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "HedEmptyClass" course by selecting "General Course" format
Then I should see the successfull message "New course created successfully."
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "HedEmptyClass" course in Manage Courses frame

#Purpose: UseCase To Enroll User To Empty Course
Scenario: Enroll Teacher to Empty Course by WS Admin
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "HedEmptyClass" course
When I select the created "HedEmptyClass" course
And I select the "HedWsInstructor"
When I enrolled the "HedWsInstructor" in the Master course
Then I should see the successfull message "Instructors enrolled successfully."

#Purpose: To publish the Empty Course
Scenario: Publish The Empty Course by Ws Admin
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "HedEmptyClass" course
When I publish the Authored "HedEmptyClass" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."

#Purpose: Delete The Created Empty Course In Workspace Admin
Scenario: Delete The Created Empty Course by WS admin
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "HedEmptyClass" course in Manage Courses frame
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message in Manage Course