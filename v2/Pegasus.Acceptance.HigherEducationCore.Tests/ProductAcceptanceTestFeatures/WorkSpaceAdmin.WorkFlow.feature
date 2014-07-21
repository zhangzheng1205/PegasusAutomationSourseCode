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


#Purpose: UseCase To Create Ws Student(s) 
Scenario: Create Student by Ws Admin 
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I click on the "Create New User" link in "left" frame
Then I should see the "Create New User" popup
When I create a new "HedWsStudent" user
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


#Purpose: UseCase To Create Workspace Course Copy  of authored course
Scenario: Course Copy Creation in other Workspace by Ws Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "MySpanishLabAuthored" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MySpanishLabAuthored" course
When I create course copy to other workspace as "MySpanishLabCopiedMaster" course
Then I should see the successfull message "Copied as master course."


#Purpose: UseCase To Create Copy As Testing Course of authored course
Scenario: Course Copy Creation as Testing Course by Ws Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "MySpanishLabAuthored" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MySpanishLabAuthored" course
When I create testing type course copy as "MySpanishLabTestingMaster" course
Then I should see the successfull message "Copied as test course."
When I verified the course "MySpanishLabTestingMaster" for AssignedToCopy state by "CourseName" and "Equals" dropdown option
Then I should see the Copied "MySpanishLabTestingMaster" Course Out Of Assigned to Copy State


#Purpose: UseCase To Enroll User(s) To Master Course
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
@PublishCourse
Scenario: Publish Master Course by Ws Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MySpanishLabMaster" course
When I publish the Authored "MySpanishLabMaster" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."


#Purpose: UseCase To Create New General Course
# TestCase Id: HSS_Core_PWF_001| Story Id: PEGASUS-3316
Scenario: Create New General Course by Ws Admin 
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "HEDGeneral" course by selecting "General Course" format
Then I should see the successfull message "New course created successfully."
When I search "HEDGeneral" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "HEDGeneral" course in Manage Courses frame


#Purpose: UseCase To Enroll Student(s) To General Course
# TestCase Id: HSS_Core_PWF_003| Story Id: PEGASUS-3317
Scenario: Enroll Student in General Course by WS Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "HEDGeneral" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "HEDGeneral" course
When I select the created "HEDGeneral" course
And I select the "HedWsStudent"
When I enrolled the "HedWsStudent" in the Master course
Then I should see the successfull message "Students enrolled successfully."


#Purpose: UseCase To Enroll Teacher(s) To General Course
# TestCase Id: HSS_Core_PWF_004| Story Id: PEGASUS-3319
Scenario: Enroll Teacher in General Course by WS Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "HEDGeneral" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "HEDGeneral" course
When I select the created "HEDGeneral" course
And I select the "HedWsInstructor"
When I enrolled the "HedWsInstructor" in the Master course
Then I should see the successfull message "Instructors enrolled successfully."


#Purpose : Creating the System Announcement
# TestCase Id: HSS_Core_PWF_015
Scenario: Create System Announcement by WS Admin
When I change the WS Admin Time Zone to Indian GMT in MyProfile
And I navigate to the "Announcement" tab
Then I should be on the "Announcement Archive" page
When I create "WsSystem" Announcement
Then I should see the successfull message "Announcement created successfully."

#Purpose : Functionality of the Course Name,WS ID radio buttons and Search button -Equals/Contains/Begins with/Ends
# TestCase Id: HSS_PWF_012
Scenario: Functionality of the Course Name,WS ID radio buttons and Search button Equals/Contains/Begins with/Ends  by WS Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MySpanishLabMaster" course
When I search "MySpanishLabMaster" course in workspace by "WSId" and "Equals" filter dropdown option
Then I should be able to see the searched "MySpanishLabMaster" course
And I should see the column headers in manage users frame

#Purpose: Delete The Created Course In Workspace Admin
Scenario: Delete The Created Master Course by WS admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MySpanishLabMaster" course in Manage Courses frame
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "MySpanishLabMaster" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message in Manage Course

#Purpose: Delete The Created Course In Workspace Admin
Scenario: Delete The Created General Course by WS admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "HEDGeneral" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "HEDGeneral" course in Manage Courses frame
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "HEDGeneral" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message in Manage Course

#Purpose: UseCase To Create New Empty Course
Scenario: Create New Empty Course by WS Admin
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
Scenario: Publish Empty Course As Master Course by Ws Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "HedEmptyClass" course
When I publish the Authored "HedEmptyClass" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."

#Purpose: Delete The Created Empty Course In Workspace Admin
Scenario: Delete The Created Empty Course by WS admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "HedEmptyClass" course in Manage Courses frame
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "HedEmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message in Manage Course



