Feature: CourseSpaceOrganizationAdmin
                    As a CourseSpaceOrganization Admin 
					I want to manage all the course space organization admin related usecases 
					so that I would validate all the organization admin scenarios are working fine.

#Purpose: To create Teacher from Users subtab for Organization Admin
Scenario: Creating Teacher in Users Tab by CS OrganizationAdmin
When I enter in to the 'Organization level' in Admin Home page
And I select the "DPCsTeacher" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "DPCsTeacher" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsTeacher" in "Users" subtab
Then I should see the "DPCsTeacher" in "Users" subtab
When I close the "Manage Organization" window

#Purpose: To create Student from Users subtab for Organization Admin
Scenario: Creating Student in Users Tab by CS OrganizationAdmin 
When I enter in to the 'Organization level' in Admin Home page
And I select the "DPCsStudent" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "DPCsStudent" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsStudent" in "Users" subtab
Then I should see the "DPCsStudent" in "Users" subtab
When I close the "Manage Organization" window

#Purpose: To create Aide from Users subtab for Organization Admin
Scenario: Creating Aide in Users Tab by CS OrganizationAdmin 
When I enter in to the 'Organization level' in Admin Home page
And I select the "DPCsAide" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "DPCsAide" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsAide" in "Users" subtab
Then I should see the "DPCsAide" in "Users" subtab
When I close the "Manage Organization" window

#Purpose: To create Organization Admin from Users subtab for Organization Admin
Scenario: Creating Organization Admin in Users Tab by CS OrganizationAdmin 
When I enter in to the 'Organization level' in Admin Home page
And I select the "DPCsOrganizationAdmin" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "DPCsOrganizationAdmin" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsOrganizationAdmin" in "Users" subtab
Then I should see the "DPCsOrganizationAdmin" in "Users" subtab
When I close the "Manage Organization" window

#Purpose: To create Teacher from Enrollment subtab for Organization Admin
Scenario: Creating Teacher in Enrollment Tab by CS OrganizationAdmin 
When I enter in to the 'Organization level' in Admin Home page
And I click on the "Enrollment" tab in Manage Organization page
And I select the "DPCsTeacher" option from "Enrollment" subtab
Then I should see the "Add User" popup
When I create a new "DPCsTeacher" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsTeacher" in "Enrollment" subtab
Then I should see the "DPCsTeacher" in "Enrollment" subtab
When I close the "Manage Organization" window

#Purpose: To create Student from Enrollment subtab for Organization Admin
Scenario: Creating Student in Enrollment Tab by CS OrganizationAdmin
When I enter in to the 'Organization level' in Admin Home page 
And I click on the "Enrollment" tab in Manage Organization page
And I select the "DPCsStudent" option from "Enrollment" subtab
Then I should see the "Add User" popup
When I create a new "DPCsStudent" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsStudent" in "Enrollment" subtab
Then I should see the "DPCsStudent" in "Enrollment" subtab
When I close the "Manage Organization" window

#Purpose: To create Aide from Enrollment subtab for Organization Admin
Scenario: Creating Aide in Enrollment Tab by CS OrganizationAdmin 
When I enter in to the 'Organization level' in Admin Home page
And I click on the "Enrollment" tab in Manage Organization page
And I select the "DPCsAide" option from "Enrollment" subtab
Then I should see the "Add User" popup
When I create a new "DPCsAide" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsAide" in "Enrollment" subtab
Then I should see the "DPCsAide" in "Enrollment" subtab
When I close the "Manage Organization" window

#Purpose: To create Organization Admin from Enrollment subtab for Organization Admin
Scenario: Creating Organization Admin in Enrollment Tab by CS OrganizationAdmin 
When I enter in to the 'Organization level' in Admin Home page
And I click on the "Enrollment" tab in Manage Organization page
And I select the "DPCsOrganizationAdmin" option from "Enrollment" subtab
Then I should see the "Add User" popup
When I create a new "DPCsOrganizationAdmin" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsOrganizationAdmin" in "Enrollment" subtab
Then I should see the "DPCsOrganizationAdmin" in "Enrollment" subtab
When I close the "Manage Organization" window

#Purpose: To Create Teacher from Classes subtab for Organization Admin
Scenario: Creating Teacher in Classes Tab by CS OrganizationAdmin
When I enter in to the 'Organization level' in Admin Home page 
And I click on the "Classes" tab in Manage Organization page
And I select the "Manage Roster" from "DigitalPathMasterLibrary" cmenu options
And I select the "DPCsTeacherManageRoster" option from "Classes" subtab in Manage Student Page
Then I should see the "Add User" popup
When I create a new "DPCsTeacherManageRoster" user in Coursespace
Then I should see the successfull message "User has been created successfully." in Manage Students page
When I close the "Manage Students" window
And I close the "Manage Organization" window

#Purpose: To create Student from Classes subtab for Organization Admin
Scenario: Creating Student in Classes Tab by CS OrganizationAdmin 
When I enter in to the 'Organization level' in Admin Home page
And I click on the "Classes" tab in Manage Organization page
And I select the "Manage Roster" from "DigitalPathMasterLibrary" cmenu options
And I select the "DPCsStudentManageRoster" option from "Classes" subtab in Manage Student Page
Then I should see the "Add User" popup
When I create a new "DPCsStudentManageRoster" user in Coursespace
Then I should see the successfull message "User has been created successfully." in Manage Students page
When I close the "Manage Students" window
And I close the "Manage Organization" window

#Purpose: To create Aide from Classes subtab for Organization Admin
Scenario: Creating Aide in Classes Tab by CS OrganizationAdmin 
When I enter in to the 'Organization level' in Admin Home page
And I click on the "Classes" tab in Manage Organization page
And I select the "Manage Roster" from "DigitalPathMasterLibrary" cmenu options
And I select the "DPCsAideManageRoster" option from "Classes" subtab in Manage Student Page
Then I should see the "Add User" popup
When I create a new "DPCsAideManageRoster" user in Coursespace
Then I should see the successfull message "User has been created successfully." in Manage Students page
When I close the "Manage Students" window
And I close the "Manage Organization" window

#Purpose: Student Bulk upload in the Manage organization popup by CS Organization Admin
Scenario: Student Bulk upload in the Manage organization popup by CS Organization Admin
When I enter in to the 'Organization level' in Admin Home page
And I click on the "Users" tab in Manage Organization page
And I select the Bulk user upload option and Import a bulk users file in "Users" subtab
Then I should see the successfull message "Bulk Registration- 0 of 1 Files in progress" in Users subtab
When I click on the "Enrollment" tab in Manage Organization page
And I select the Bulk user upload option and Import a bulk users file in "Enrollment" subtab
Then I should see the successfull message "Bulk Registration- 0 of 1 Files in progress" in Users subtab
When I click on the "Classes" tab in Manage Organization page
And I select the "Manage Roster" from "DigitalPathMasterLibrary" cmenu options
Then I should be on the 'Manage Students' page
When I delete the Older uploaded files
And I select the "Import Students" option from the 'Create New' drop down option
And I Import a bulk users file 
Then I should see the successfull message "Bulk Registration- 0 of 1 Files in progress" in 'Manage Students' window
When I close the "Manage Students" window
And I close the "Manage Organization" window
