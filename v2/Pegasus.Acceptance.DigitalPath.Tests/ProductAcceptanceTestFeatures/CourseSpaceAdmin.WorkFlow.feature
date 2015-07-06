Feature: CourseSpaceAdmin
	                As a CS Admin 
					I want to manage all the coursespace admin related usecases 
					so that I would validate all the coursespace admin scenarios are working fine.

#Purpose: Approve master course in Course space
Scenario: Approve Master Library by CS Admin
When I navigate to the "Publishing" tab
Then I should be on the "Manage Programs" page
When I select the "Manage Products" tab
Then I should be on the "Manage Products" page
When I search the course "MasterLibrary" in coursespace
Then I should be able to see the searched "MasterLibrary" course in the left frame
When I click on "Approve" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."

#Purpose: UseCase To create Program in course space
Scenario: Create Program by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Programs' Page
When I create the "DigitalPath" Program in coursespace
Then I should see the successfull message "Program created successfully."

#Purpose: Create DigitalPath Product
Scenario: Create DP Product by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Products' Page
And I create the "DigitalPath" Product in coursespace using "DigitalPath" Program
Then I should see the successfull message "New product created successfully."

#Purpose: Create DigitalPath Demo Product
Scenario: Create Demo Product by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Products' Page
And I create the "DigitalPathDemo" Product in coursespace using "DigitalPath" Program
Then I should see the successfull message "New product created successfully."

#Purpose: Creation of Demo Organization
Scenario: Create School Level DigitalPath Demo Organization by CS Admin
When I navigate to "Organization Admin" tab of the "Organization Management" page
Then I should be on the "Organization Management" page
When I click on the Create New Organization link 
Then I should see the "Create Organization" popup
When I create the "School" level organization "Independent" in "DigitalPathDemo"
Then I should see the successfull message "Organization created successfully."

#Purpose: Creation of State Level Organization
Scenario: Create State Level Organization by CS Admin
When I navigate to "Organization Admin" tab of the "Organization Management" page
Then I should be on the "Organization Management" page
When I click on the Create New Organization link 
Then I should see the "Create Organization" popup
When I create the "State" level organization "Hierarchical" in "DigitalPath"
Then I should see the successfull message "Organization created successfully."

#Purpose: Creation of Region Level Organization
Scenario: Create Region Level Organization by CS Admin
When I navigate to "Organization Admin" tab of the "Organization Management" page
Then I should be on the "Organization Management" page
When I search the "State" level Organization in "DigitalPath"
Then I should see the "State" level organization name in "DigitalPath"
When I create the "Region" level organization "Hierarchical" in "DigitalPath"
Then I should see the successfull message "Organization created successfully."
When I click on the Select Organization link
Then I should be on the "Organization Management" page

#Purpose: Creation of District Level Organization
Scenario: Create District Level Organization by CS Admin
When I navigate to "Organization Admin" tab of the "Organization Management" page
Then I should be on the "Organization Management" page
When I search the "Region" level Organization in "DigitalPath"
Then I should see the "Region" level organization name in "DigitalPath"
When I create the "District" level organization "Hierarchical" in "DigitalPath"
Then I should see the successfull message "Organization created successfully."
When I click on the Select Organization link
Then I should be on the "Organization Management" page

#Purpose: Creation of School Level Organization
@CreateSchoolLevelOrganiationbyCSAdmin
Scenario: Create School Level Organization by CS Admin
When I navigate to "Organization Admin" tab of the "Organization Management" page
Then I should be on the "Organization Management" page
When I search the "District" level Organization in "DigitalPath"
Then I should see the "District" level organization name in "DigitalPath"
When I create the "School" level organization "Hierarchical" in "DigitalPath"
Then I should see the successfull message "Organization created successfully."
When I search the "School" level Organization in "DigitalPath"
Then I should see the "School" level organization name in "DigitalPath"

#Purpose: To Associate Master Library To Product 
Scenario:Associate Master Library To Product by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Products' Page
And I search the course "MasterLibrary" in coursespace
Then I should be able to see the searched "MasterLibrary" course in the left frame
When I select course in left frame
And I select product type "DigitalPath" in right frame
When I associate the course to Pegasus product
Then I should see the successfull message "The course has been added successfully."

#Purpose: To create Teacher from Users subtab
Scenario: Create Teacher in Users Tab by CS Admin 
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Users" tab in Manage Organization page
And I select the "DPCsTeacher" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "DPCsTeacher" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsTeacher" in "Users" subtab
Then I should see the "DPCsTeacher" in "Users" subtab
When I close the "Manage Organization" window

#Purpose: To create Student from Users subtab
Scenario: Create Student in Users Tab by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
Then I should be on the "Manage Organization" page
When I click on the "Users" tab in Manage Organization page
And I select the "DPCsStudent" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "DPCsStudent" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsStudent" in "Users" subtab
Then I should see the "DPCsStudent" in "Users" subtab
When I close the "Manage Organization" window

#Purpose: To create Aide from Users subtab
Scenario: Create Aide in Users Tab by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Users" tab in Manage Organization page
And I select the "DPCsAide" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "DPCsAide" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsAide" in "Users" subtab
Then I should see the "DPCsAide" in "Users" subtab
When I close the "Manage Organization" window

#Purpose: To create Organization Admin from Users subtab
Scenario: Create Organization Admin in Users Tab by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Users" tab in Manage Organization page
And I select the "DPCsOrganizationAdmin" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "DPCsOrganizationAdmin" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsOrganizationAdmin" in "Users" subtab
Then I should see the "DPCsOrganizationAdmin" in "Users" subtab
When I close the "Manage Organization" window

#Purpose: To Create Bulk Users from Users subtab
Scenario: Upload Bulk User in Users Tab by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Users" tab in Manage Organization page
And I select the Bulk user upload option and Import a bulk users file in "Users" subtab
Then I should see the successfull message "Bulk Registration- 0 of 1 Files in progress" in Users subtab
When I close the "Manage Organization" window

#Purpose: To create Teacher from Enrollment tab
Scenario: Create Teacher in Enrollment Tab by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Enrollment" tab in Manage Organization page
And I select the "DPCsTeacher" option from "Enrollment" subtab
Then I should see the "Add User" popup
When I create a new "DPCsTeacher" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsTeacher" in "Enrollment" subtab
Then I should see the "DPCsTeacher" in "Enrollment" subtab
When I close the "Manage Organization" window

#Purpose: To create Student from Enrollment tab
Scenario: Create Student in Enrollment Tab by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Enrollment" tab in Manage Organization page
And I select the "DPCsStudent" option from "Enrollment" subtab
Then I should see the "Add User" popup
When I create a new "DPCsStudent" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsStudent" in "Enrollment" subtab
Then I should see the "DPCsStudent" in "Enrollment" subtab
When I close the "Manage Organization" window

#Purpose: To create Aide from Enrollment tab
Scenario: Create Aide in Enrollment Tab by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Enrollment" tab in Manage Organization page
And I select the "DPCsAide" option from "Enrollment" subtab
Then I should see the "Add User" popup
When I create a new "DPCsAide" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsAide" in "Enrollment" subtab
Then I should see the "DPCsAide" in "Enrollment" subtab
When I close the "Manage Organization" window

#Purpose: To create Organization Admin from Enrollment tab
Scenario: Create Organization Admin in Enrollment Tab by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Enrollment" tab in Manage Organization page
And I select the "DPCsOrganizationAdmin" option from "Enrollment" subtab
Then I should see the "Add User" popup
When I create a new "DPCsOrganizationAdmin" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsOrganizationAdmin" in "Enrollment" subtab
Then I should see the "DPCsOrganizationAdmin" in "Enrollment" subtab
When I close the "Manage Organization" window

#Purpose: To Create Bulk Users from Enrollment tab
Scenario: Upload Bulk User in Enrollment Tab by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Enrollment" tab in Manage Organization page
And I select the Bulk user upload option and Import a bulk users file in "Enrollment" subtab
Then I should see the successfull message "Bulk Registration- 0 of 1 Files in progress" in Users subtab
When I close the "Manage Organization" window

#Purpose: To create User In Administrators Tab in CourseSpace
Scenario: Create User In Administrators Tab By CS Admin
When I am on the 'Administration Tool' page
When I click on the "Create New User" link in "left" frame
Then I should see the "Create New User" popup
When I create a new "DPCourseSpacePramotedAdmin" user
Then I should see the successfull message "New user created successfully."
When I search the created "DPCourseSpacePramotedAdmin" in  Manage Users frame
Then I should see the "DPCourseSpacePramotedAdmin" in Manage Users frame

#Purpose: Creation of Class Using Master Library Added to the Basal product
Scenario: Create Class Using Master Library by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I navigate to the "Classes" tab
And I click on the Add Classes Option
Then I should see the "Create Class" popup
When I create the class using "MasterLibrary" course
And I search "DigitalPathMasterLibrary" class in Coursespace
And I wait for class "DigitalPathMasterLibrary" to copy
Then I should be able to see the searched "DigitalPathMasterLibrary" class
When I close the "Manage Organization" window

#Purpose: Navigate inside the Course through C menu option "Enter Class as Teacher"
Scenario: Navigate inside Class by Enter Class as Teacher
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I navigate to the "Classes" tab
And I search "DigitalPathMasterLibrary" class in Coursespace
Then I should be able to see the searched "DigitalPathMasterLibrary" class
When I click on Enter Class as Teacher cmenu option of class in coursespace
Then I should see the "Select Course" popup
When I select the course and enter inside the course
Then I should see the default tabs for teacher view
When I enter as Demo Student
Then I should see the "DigitalPathMasterLibrary" class
And I navigate back to Teacher view
When I navigate outside of the class from "Overview" window
Then I should be on the "Manage Organization" page
When I close the "Manage Organization" window

#Purpose: Enroll Teacher to class
Scenario: Teacher Enrollment in Class by CS Admin 
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I navigate to the "Enrollment" tab
And I select the "DigitalPathMasterLibrary" class
And I select the "DPCsTeacher" under User Frame
And I select the Enroll button
Then I should see the successfull message 'Users enrolled successfully'
When I close the "Manage Organization" window

#Purpose: Enroll Student to class
Scenario: Student Enrollment in Class by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I navigate to the "Enrollment" tab
And I select the "DigitalPathMasterLibrary" class
When  I select the "DPCsStudent" under User Frame
And I select the Enroll button
Then I should see the successfull message 'Users enrolled successfully'
When I close the "Manage Organization" window

#Purpose : Creating the System Announcement
Scenario: Create System Announcement by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I changed the WS Admin Time Zone to Indian GMT in MyProfile
And I navigate to the "Announcement" tab
When I create "CsSystem" Announcement
Then I should see the successfull message "Announcement created successfully."
When I navigate back to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page

#Purpose: Edit The School Level Organization for Pearson Admin 
Scenario: Enhance organization management by CS Admin
When I am on the 'Organization Management' page
And I search the "School" level Organization in "DigitalPath"
Then I should see the "School" level organization name in "DigitalPath"
When I click on the Select Button
And I navigate to the "Properties" tab in 'Manage Organization' page
And I edit the "School" level Organization in "DigitalPath"
Then I should see the successfull message "Organization updated successfully."

#Purpose: Enrolling the User as Promoted Admin in the Administrators tab
Scenario: Enrolling The User As Promoted Admin In Administrators Tab By CS Admin
Given I am on the 'Administration Tool' page
When I click the "AdministratorsDisplayAllUsers" button
And I select the "DPCourseSpacePramotedAdmin" user
And I click the Add button
Then I should see the successfull message "Administrators enrolled successfully."
When I search the "DPCourseSpacePramotedAdmin" in Administrator tab
Then I should see the successfull message "Tools saved successfully."

#Purpose: To Create Teacher from Classes subtab for CS Admin
Scenario: Creating Teacher in Classes Tab by CS Admin  
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Classes" tab in Manage Organization page
And I select the "Manage Roster" from "DigitalPathMasterLibrary" cmenu options
And I select the "DPCsTeacherManageRoster" option from "Classes" subtab in Manage Student Page
Then I should see the "Add User" popup
When I create a new "DPCsTeacherManageRoster" user in Coursespace
Then I should see the successfull message "User has been created successfully." in Manage Students page
When I close the "Manage Students" window
And I close the "Manage Organization" window

#Purpose: To Create Student from Classes subtab for CS Admin
Scenario: Creating Student in Classes Tab by CS Admin  
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Classes" tab in Manage Organization page
And I select the "Manage Roster" from "DigitalPathMasterLibrary" cmenu options
And I select the "DPCsStudentManageRoster" option from "Classes" subtab in Manage Student Page
Then I should see the "Add User" popup
When I create a new "DPCsStudentManageRoster" user in Coursespace
Then I should see the successfull message "User has been created successfully." in Manage Students page
When I close the "Manage Students" window
And I close the "Manage Organization" window

#Purpose: To Create Aide from Classes subtab for CS Admin
Scenario: Creating Aide in Classes Tab by CS Admin  
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Classes" tab in Manage Organization page
And I select the "Manage Roster" from "DigitalPathMasterLibrary" cmenu options
And I select the "DPCsAideManageRoster" option from "Classes" subtab in Manage Student Page
Then I should see the "Add User" popup
When I create a new "DPCsAideManageRoster" user in Coursespace
Then I should see the successfull message "User has been created successfully." in Manage Students page
When I close the "Manage Students" window
And I close the "Manage Organization" window

#Purpose: Student Bulk upload in the Manage organization popup by CS Admin
Scenario: Student Bulk upload in the Manage organization popup by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I navigate to the "Classes" tab
And I select the "Manage Roster" from "DigitalPathMasterLibrary" cmenu options
Then I should be on the 'Manage Students' page
When I delete the Older uploaded files
And I select the "Import Students" option from the 'Create New' drop down option
And I Import a bulk users file 
Then I should see the successfull message "Bulk Registration- 0 of 1 Files in progress" in 'Manage Students' window
When I close the "Manage Students" window
And I close the "Manage Organization" window

#Purpose: To Restrict Access to Product 
Scenario: Restrict Access to Product by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Products' Page
And I select product type "DigitalPath" in right frame
And I select "Preferences" cmenu of "MasterLibrary" course
And I disable the course in product
Then I should see the successfull message "Course updated successfully."
When I select product type "DigitalPath" in right frame
Then I should see the "MasterLibrary" course in "Hidden" state

#Purpose: Approve Empty Course in Course space
Scenario: Approve Empty Course by CS Admin
When I navigate to the "Publishing" tab
And I select the "Manage Products" tab
Then I should be on the "Manage Products" page
When I search the course "EmptyClass" in coursespace
Then I should be able to see the searched "EmptyClass" course in the left frame
When I click on "Approve as Empty Class" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."

#Purpose: Context C-Menu Options of the Product
Scenario: Display of Context CMenu Options of the Product by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Manage Products' Page
And I search the product type "DigitalPath" in right frame
And I click the product cmenu option
Then I should able to see the Display of c-menu options for product
| ExpectedResult  | ActualResult    |
| Open            | Open            |
| Edit            | Edit            |
| Product History | Product History |

#Purpose: Delete the created Organization
Scenario: Delete the created Organization by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I am on the 'Organization Management' page
And I create the "School" level organization "Independent" in "DigitalPath"
Then I should see the successfull message "Organization created successfully."
When I search the "School" level Organization in "DigitalPath"
Then I should see the "School" level organization name in "DigitalPath"
When I delete the organization
Then I should see the successfull message "Organization was successfully removed."
When I search the "School" level Organization in "DigitalPath"
Then I should see the message "No records found."


#Purpose: UseCase To license DigitalPath Demo products
Scenario: Create License for the DigitalPath Demo Organization by CS Admin
When I navigate to "Organization Admin" tab of the "Organization Management" page
Then I should be on the "Organization Management" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPathDemo"
And I navigate to the "Licenses" tab
When I click on the Add Products Option
Then I should see the "Product Selection" popup
When I create 3 license for the "DigitalPathDemo" product
And I search "Pegasus" licensed product in Coursespace
Then I should be able to see the searched "Pegasus" licensed product in the frame
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To license Multiple DigitalPath Demo products with same AccessCode
Scenario: Create Multiple License for the DigitalPath Demo Organization by CS Admin
When I navigate to "Organization Admin" tab of the "Organization Management" page
Then I should be on the "Organization Management" page
When I am on the 'Manage Organization' page of "School" level in the "DigitalPathDemo"
And I navigate to the "Licenses" tab
When I click on the Add Products Option
Then I should see the "Product Selection" popup
When I create 3 licenses for different "DigitalPathDemo" product
And I search "Pegasus" licensed product in Coursespace
Then I should be able to see the searched "Pegasus" licensed product in the frame
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: CSAdmin update Organization admin profile details
Scenario: Update Organization Admin profile in Users Tab by CS Admin
When I navigate to the "Course Enrollment" tab
Then I should be on the "Course Enrollment" page
When I navigate to the "Organization Admin" tab
And I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
And I click on the "Users" tab in Manage Organization page
And I select the "DPCsOrganizationAdmin" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "DPCsOrganizationAdmin" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsOrganizationAdmin" in "Users" subtab
Then I should see the "DPCsOrganizationAdmin" in "Users" subtab
When I click on "Edit" cmenu option of "DPCsOrganizationAdmin"
Then I should see the "Update user" popup
When I search the created "DPCsOrganizationAdmin" in "Users" subtab
Then I should see the "DPCsOrganizationAdmin" in "Users" subtab
