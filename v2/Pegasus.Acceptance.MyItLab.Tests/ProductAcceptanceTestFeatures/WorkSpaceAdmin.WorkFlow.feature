Feature: WorkSpaceAdmin
					As a WS Admin 
					I want to manage all the workspace admin related usecases 
					so that I would validate all the workspace admin scenarios are working fine.

#Purpose: UseCase To Create New SIM5 Master Course
# TestCase Id: HED_MIL_PWF_011
Scenario: Create New SIM5 Master Course by Ws Admin 
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "MyItLabSIM5MasterCourse" course by selecting "Sim Course" format
Then I should see the successfull message "New course created successfully."
When I search "MyItLabSIM5MasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MyItLabSIM5MasterCourse" course in Manage Courses frame

#Purpose: UseCase To Create Ws User(s) 
Scenario: Create Teacher by Ws Admin 
When I click on the "Create New User" link in "left" frame
Then I should see the "Create New User" popup
When I create a new "HedWsInstructor" user
Then I should see the successfull message "New user created successfully." 

#Purpose: UseCase To Enroll User(s) To SIM5 Master Course
Scenario: Enroll Teacher to SIM5 Master Course by WS Admin
When I search "MyItLabSIM5MasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabSIM5MasterCourse" course
When I select the created "MyItLabSIM5MasterCourse" course
And I select the "HedWsInstructor"
When I enrolled the "HedWsInstructor" in the Master course
Then I should see the successfull message "Instructors enrolled successfully."

#Purpose: To publish the authored SIM5 Master Course
Scenario: Publish SIM5 Master Course by Ws Admin
When I search "MyItLabSIM5MasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabSIM5MasterCourse" course
When I publish the Authored "MyItLabSIM5MasterCourse" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."


#Purpose: UseCase To Enroll User(s) To SIM Master Course
Scenario: Enroll Teacher to SIM Master Course by WS Admin
When I search "MyItLabSIMMasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabSIMMasterCourse" course
When I select the created "MyItLabSIMMasterCourse" course
And I select the "HedWsInstructor"
When I enrolled the "HedWsInstructor" in the Master course
Then I should see the successfull message "Instructors enrolled successfully."

#Purpose: To publish the authored SIM Master Course
Scenario: Publish SIM Master Course by Ws Admin
When I search "MyItLabSIMMasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabSIMMasterCourse" course
When I publish the Authored "MyItLabSIMMasterCourse" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."

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

#Purpose: UseCase To Create New Testing Course
Scenario: Create New Testing Master Course by Ws Admin 
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "MyItLabSIMMasterCourse" course by selecting "MyTest Course" format
Then I should see the successfull message "New course created successfully."
When I search "MyItLabSIMMasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MyItLabSIMMasterCourse" course in Manage Courses frame

#Purpose: UseCase To Create Copy As Testing Course of authored course
Scenario: Course Copy Creation as Testing Course by Ws Admin
When I navigate to the "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "MyTestAuthoredCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyTestAuthoredCourse" course
When I perform "Copy as Testing Course" for "MySpanishLabMaster" course
Then I should see the successfull message "Copied as test course."
When I verified the course "MySpanishLabMaster" for AssignedToCopy state by "CourseName" and "Equals" dropdown option
Then I should see the Copied "MySpanishLabMaster" Course Out Of Assigned to Copy State

#Purpose: UseCase To Create Copy As Master Course of authored course
Scenario: Course Copy Creation as  Master Course by Ws Admin
When I navigate to the "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "MyItLabAuthoredCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabAuthoredCourse" course
When I perform "Copy as Master Course" for "MyItLabSIM5MasterCourse" course
Then I should see the successfull message "Copied as master course."
When I verified the course "MyItLabSIM5MasterCourse" for AssignedToCopy state by "CourseName" and "Equals" dropdown option
Then I should see the Copied "MyItLabSIM5MasterCourse" Course Out Of Assigned to Copy State

#Pupose: Usecase to Copy Master course to Another workspace
Scenario:Copy Master course to Another workspace
When I navigate to the "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "MyItLabAuthoredCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabAuthoredCourse" course
When I perform "Copy as Master Course" for "MyItLabSIM5AnotherWorkSpaceMasterCourse" course to another workspace "HedWsAdmin2"
Then I should see the successfull message "Copied as master course."

#Purpose: Verify Course copied from Another Workspace
Scenario: Verify Course copied from Another Workspace
When I verified the course "MyItLabSIM5AnotherWorkSpaceMasterCourse" for AssignedToCopy state by "CourseName" and "Equals" dropdown option
Then I should see the Copied "MyItLabSIM5AnotherWorkSpaceMasterCourse" Course Out Of Assigned to Copy State