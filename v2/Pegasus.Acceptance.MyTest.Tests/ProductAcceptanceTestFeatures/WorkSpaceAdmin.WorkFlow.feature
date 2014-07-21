Feature: WorkSpaceAdmin
					As a WS Admin 
					I want to manage all the workspace admin related usecases 
					so that I would validate all the workspace admin scenarios are working fine.

#Purpose: UseCase To Create Ws User(s) 
Scenario: Create Teacher by Ws Admin 
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I click on the "Create New User" link in "left" frame
Then I should see the "Create New User" popup
When I create a new "HedWsInstructor" user
Then I should see the successfull message "New user created successfully." 

#Purpose: UseCase To Create Master Course 
Scenario: Create Master Course by Ws Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "MySpanishLabMaster" course by selecting "General Course" format
Then I should see the successfull message "New course created successfully."
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MySpanishLabMaster" course in Manage Courses frame

#Purpose: UseCase To Enroll User To Master Course
Scenario: Enroll Teacher in Master Course by WS Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MySpanishLabMaster" course
When I select the created "MySpanishLabMaster" course
And I select the "HedWsInstructor"
When I enrolled the "HedWsInstructor" in the Master course
Then I should see the successfull message "Instructors enrolled successfully."

#Purpose: To publish the authored master course
Scenario: Publish Master Course by Ws Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MySpanishLabMaster" course
When I publish the Authored "MySpanishLabMaster" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."

#Purpose: Delete The Created Course In Workspace Admin
Scenario: Delete The Created Master Course by WS Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MySpanishLabMaster" course
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message

#Purpose: UseCase To Create Empty Course 
Scenario: Create Empty Course by Ws Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "HedEmptyClass" course by selecting "General Course" format
Then I should see the successfull message "New course created successfully."
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "HedEmptyClass" course in Manage Courses frame

#Purpose: UseCase To Enroll User To Empty Course
Scenario: Enroll Teacher To Empty Course by WS Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "HedEmptyClass" course
When I select the created "HedEmptyClass" course
And I select the "HedWsInstructor"
When I enrolled the "HedWsInstructor" in the Master course
Then I should see the successfull message "Instructors enrolled successfully."

#Purpose: To publish the Empty course
Scenario: Publish The Empty Course by Ws Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "HedEmptyClass" course
When I publish the Authored "HedEmptyClass" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."

#Purpose: Delete The Created Empty Course In Workspace Admin
Scenario: Delete The Created Empty Course by WS Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "HedEmptyClass" course
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message
