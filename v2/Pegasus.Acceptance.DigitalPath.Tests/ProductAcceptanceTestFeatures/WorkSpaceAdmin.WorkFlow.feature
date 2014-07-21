Feature: WorkSpaceAdmin
					As a WorkSpace Admin 
					I want to manage all the workspace admin related usecases 
					so that I would validate all the workspace admin scenarios are working fine.

# Purpose: Change time zone by WS admin
Scenario: Change Time Zone by WS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I changed the WS Admin Time Zone to Indian GMT in MyProfile

#Purpose : Creating the System Announcement
Scenario: Create System Announcement by WS Admin
When I navigate to the "Announcement" tab
Then I should be on the "Announcement Archive" page
When I create "WsSystem" Announcement
Then I should see the successfull message "Announcement created successfully."
When I navigate back to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page

#Purpose: To create Teacher in Workspace
Scenario: Create Teacher by WS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I click on the "Create New User" link in "left" frame
Then I should see the "Create New User" popup
When I create a new "WsTeacher" user
Then I should see the successfull message "New user created successfully."
When I search the created "WsTeacher" in  Manage Users frame
Then I should see the "WsTeacher" in Manage Users frame

#Purpose: To create Student in Workspace
Scenario: Create Student by WS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I click on the "Create New User" link in "left" frame
Then I should see the "Create New User" popup
When I create a new "WsStudent" user
Then I should see the successfull message "New user created successfully."
When I search the created "WsStudent" in  Manage Users frame
Then I should see the "WsStudent" in Manage Users frame

#Purpose: To create User In Administrators Tab in Workspace
Scenario: Create User In Administrators Tab By WS Admin
When I navigate to the "Administrators" tab
Then I should be on the "Administration Tool" page
When I click on the "Create New User" link in "left" frame
Then I should see the "Create New User" popup
When I create a new "DPWorkSpacePramotedAdmin" user
Then I should see the successfull message "New user created successfully."
When I search the created "DPWorkSpacePramotedAdmin" in  Manage Users frame
Then I should see the "DPWorkSpacePramotedAdmin" in Manage Users frame

#Purpose: UseCase To Enroll Teacher In Course
Scenario: Enroll Teacher in Course by WS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search "MasterLibrary" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MasterLibrary" course in Manage Courses frame
When I select the created "MasterLibrary" course
And I select the "WsTeacher" user
And I enroll the "WsTeacher" in the selected course
Then I should see the successfull message "Teachers enrolled successfully."
And I should see the enrolled "WsTeacher" in the Manage Courses frame

#Purpose: UseCase To Enroll Student In Course
@EnrollStudentInWS
Scenario: Enroll Student in Course by WS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search "MasterLibrary" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MasterLibrary" course in Manage Courses frame
When I select the created "MasterLibrary" course
When I select the "WsStudent" user
And I enroll the "WsStudent" in the selected course
Then I should see the successfull message "Students enrolled successfully."
And I should see the enrolled "WsStudent" in the Manage Courses frame

#Purpose: To publish copied authored Course as Master Library
Scenario: Publish Course as Master Library by WS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search "MasterLibrary" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MasterLibrary" course in Manage Courses frame
When I publish the Copied Authored "MasterLibrary" in workspace as "Master Library"
Then I should see the successfull message "Course published successfully."

#purpose: UseCase To Create Copy Of Authored Course 
Scenario: Create Master Course by WS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "MasterLibrary" course by selecting "General Course" format
Then I should see the successfull message "New course created successfully."
When I search "MasterLibrary" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MasterLibrary" course in Manage Courses frame

#Purpose: UseCase To Create Copy As Testing Course of authored course 
Scenario: Course Copy Creation as Testing Course by Ws Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search "DigitsAuthoredCourse" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "DigitsAuthoredCourse" course in Manage Courses frame
When I create testing type course copy as "CTCDigitsAuthoredCourse"
Then I should see the successfull message "Copied as test course."
When I verify the course "CTCDigitsAuthoredCourse" for AssignedToCopy state by "CourseName" and "Equals" dropdown option
Then I should see the copied course out of Assigned to Copy State
And I should see the searched "CTCDigitsAuthoredCourse" course in Manage Courses frame

#Purpose: Unenrol the Enrolled Student to the Course
Scenario: UnEnrol the Enrolled Student by Workspace Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search "MasterLibrary" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MasterLibrary" course in Manage Courses frame
When I select the created "MasterLibrary" course
And I select the "WsStudent" user
And I enroll the "WsStudent" in the selected course
Then I should see the successfull message "Students enrolled successfully."
When I select the "WsStudent" in the enrolled course
And I Unenroll the 'user' from the course
Then I should see the successfull message "Users unenrolled successfully."

#Purpose : View the contents of Context Menu Options for WsTeacher
Scenario: Context Menu Option of the Users by Workspace Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search the created "WsTeacher" in  Manage Users frame
Then I should see the "WsTeacher" in Manage Users frame
When I click on the cmenu link for "WsTeacher"
Then I should see 'User Information', 'Edit', 'Delete' and 'Deny Access' in CMenu Options

#Purpose : View the CMenu Options and User Information For User in Administrators tab
Scenario: Functionality of the User Cmenu options displayed in Administrators tab by Workspace Admin
When I navigate to the "Administrators" tab
Then I should be on the "Announcement Archive" page
When I search the created "DPWorkSpacePramotedAdmin" in  administrators tab
Then I should see the "DPWorkSpacePramotedAdmin" in administrators tab	
When I click on the cmenu link for "DPWorkSpacePramotedAdmin"
Then I should see 'User Information', 'Edit', 'Delete' and 'Deny Access' in CMenu Options
When I select the Cmenu option "UserInformation"
Then I should be able to view the information of the "DPWorkSpacePramotedAdmin"
When I click on the cmenu link for "DPWorkSpacePramotedAdmin"
And  I select the Cmenu option "Edit"
And  I edit the details of "DPWorkSpacePramotedAdmin"
Then I should see the successfull message "User details updated successfully."

#Purpose: Functionality to Verify Deny access grant access and delete user
Scenario: Functionality to Verify Deny Access, Grant Access and Delete User
When I navigate to the "Administrators" tab
Then I should be on the "Announcement Archive" page
When I search the created "DPWorkSpacePramotedAdmin" in  administrators tab
Then I should see the "DPWorkSpacePramotedAdmin" in administrators tab	
When I click on the cmenu link for "DPWorkSpacePramotedAdmin"
And  I select the Cmenu option "DenyAccess"
Then I should see the successfull message "Access denied successfully."
When I click on the cmenu link for "DPWorkSpacePramotedAdmin"
And  I select the Cmenu option "Grantaccess"
Then I should see the successfull message "Access granted successfully."
When I click on the cmenu link for "DPWorkSpacePramotedAdmin"
And  I select the Cmenu option "Delete"
And I select 'OK' option
Then I should see the successfull message "Users deleted successfully."

#Purpose : Copy master course in different workspace
Scenario: Copying the Courses across the Workspace by Workspace Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search "DigitsCourse" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "DigitsCourse" course in Manage Courses frame
When I create course copy to other workspace as "CopiedDigitsAuthoredCourse"
Then I should see the successfull message "Copied as master course."
When I "Sign out" from the "WsAdmin"
Then I should see the successfull message "You have been signed out of the application."
When I login to Pegasus as "DPWsAdmin" in "WorkSpace"
Then I should be logged in successfully
And I should be on the "Course Enrollment" page
When I search "CopiedDigitsAuthoredCourse" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "CopiedDigitsAuthoredCourse" course in Manage Courses frame

#purpose: UseCase To Check Context Menu Option of the CTC Courses
Scenario: Context CMenu Option of the Courses By WsAdmin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
And I should see "CreateNewCourse" button
And I should see "DisplayAllCourses" button
And I should see "Course name" radio button
And I should see "Search" button
And I should see Text field next to the Filters
And I should see Equals, Contains, Begins With and Ends With Filters
When I search "MasterLibrary" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MasterLibrary" course in Manage Courses frame
And I should see the 'Created','Type' and 'Status' of course
And I should see the 'New search' and 'Delete Selected Courses' button
When I click on the cmenu option 
Then I should see cmenu options of course

#purpose: UseCase To Check Context Menu Option of the CTC Courses
Scenario: Context CMenu Option of the CTC Courses By WsAdmin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I click the "EnrollmentDisplayAllCourses" button
And I search the "CTCDigitsAuthoredCourse" course in workspace by "CourseName" and "Equals" dropdown option
And I click the cmenu option of CTC course
Then I should see the default cmenu options of CTC

#Purpose: UseCase To view manage course frame for workspace admin
Scenario: Default view of the Manage Course frame for Workspace admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
And I should see "CreateNewCourse" button
And I should see "DisplayAllCourses" button
And I should see "Course name" radio button
And I should see "Search" button
And I should see Text field next to the Filters
And I should see Equals, Contains, Begins With and Ends With Filters

#Purpose: Enrolling the User as Promoted Admin in the Administrators tab
Scenario: Enrolling The User As Promoted Admin In Administrators Tab By WS Admin
When I navigate to the "Administrators" tab
Then I should be on the "Administration Tool" page
When I click the "AdministratorsDisplayAllUsers" button
And I select the "DPWorkSpacePramotedAdmin" user
And I click the Add button
Then I should see the successfull message "Administrators enrolled successfully."
And I should see the "DPWorkSpacePramotedAdmin" as Promoted Workspace Admin

#Purpose: UnEnrolling the User as Promoted Admin in the Administrators tab
Scenario: UnEnrolling Of Promoted Workspace Admin By WS Admin
When I navigate to the "Administrators" tab
Then I should be on the "Administration Tool" page
When I search the "DPWorkSpacePramotedAdmin" in Administrator tab
And I click on the 'Unenroll Selected Users' button
Then I should see the successfull message "Administrators unenrolled successfully."

#Purpose: Context menu option displayed for Promoted Workspace Admin
Scenario: Context menu option displayed for Promoted Workspace Admin by WS admin
When I navigate to the "Administrators" tab
Then I should be on the "Administration Tool" page
When I click on the cmenu option of "DPWorkSpacePramotedAdmin"
Then I should successfully see the cmenu option "Unenroll"

#Purpose: Delete The Created Course In Workspace Admin
Scenario: Delete The Created Course by WS admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search "MasterLibrary" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "MasterLibrary" course in Manage Courses frame
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "MasterLibrary" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message in Manage Course

#Purpose: UseCase To Create Empty Course
Scenario: Create Empty Course by WS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I click on the "Create New Courses" link in "right" frame
Then I should see the "Create New Courses" popup
When I create a new "EmptyClass" course by selecting "General Course" format
Then I should see the successfull message "New course created successfully."
When I search "EmptyClass" course in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "EmptyClass" course in Manage Courses frame

#Purpose: UseCase To Enroll Teacher To Empty Course
Scenario: Enroll Teacher To Empty Course by WS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search "EmptyClass" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "EmptyClass" course in Manage Courses frame
When I select the created "EmptyClass" course
And I select the "WsTeacher" user
And I enroll the "WsTeacher" in the selected course
Then I should see the successfull message "Teachers enrolled successfully."
And I should see the enrolled "WsTeacher" in the Manage Courses frame

#Purpose: To publish copied authored Course as Master Library
Scenario: Publish The Empty Course as Master Course by WS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search "EmptyClass" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "EmptyClass" course in Manage Courses frame
When I publish the Copied Authored "EmptyClass" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."

#Purpose: Delete The Created Empty Course In Workspace Admin
Scenario: Delete The Created Empty Course by WS admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search "EmptyClass" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the searched "EmptyClass" course in Manage Courses frame
When I select the course to delete in manage course frame
Then I should see the successfull message ""Courses deleted successfully."
When I search "EmptyClass" in workspace by "CourseName" and "Equals" dropdown option
Then I should see the "There are no courses. To add courses, click Create New Course." message in Manage Course

#Purpose: Delete The Created User In Workspace Admin
Scenario: Delete The Created User by WS admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I search the created "WsTeacher" in  Manage Users frame
Then I should see the "WsTeacher" in Manage Users frame
When I click the user cmenu option in manage user frame
And I select the Cmenu option "Delete"
And I select 'OK' option
Then I should see the successfull message "Users deleted successfully."