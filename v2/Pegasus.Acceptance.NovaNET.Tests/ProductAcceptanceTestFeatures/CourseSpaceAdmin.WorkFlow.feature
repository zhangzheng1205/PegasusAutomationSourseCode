Feature: CourseSpaceAdmin
	                 As a CS Admin 
					I want to manage all the coursespace admin related usecases 
					so that I would validate all the coursespace admin scenarios are working fine.


#Purpose: Approve Empty Course in Course space
Scenario: Approve Empty Course by CS Admin
When I navigate to the "Publishing" tab
And I select the "Manage Products" tab
Then I should be on the "Manage Products" page
When I search the "EmptyClass" course in coursespace
Then I should be able to see the searched "EmptyClass" course in the left frame
When I click on "Approve as Empty Class" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."

#Purpose: Approve Empty Course in Course space
Scenario: Approve Container Course by CS Admin
When I navigate to the "Publishing" tab
And I select the "Manage Products" tab
Then I should be on the "Manage Products" page
When I search the "Container" course in coursespace
Then I should be able to see the searched "Container" course in the left frame
When I click on "Approve" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."

#Purpose: Approve Master Library in Course space
Scenario: Approve Master Library by CS Admin
When I navigate to the "Publishing" tab
And I select the "Manage Products" tab
Then I should be on the "Manage Products" page
When I search the "NovaNETMasterLibrary" course in coursespace
Then I should be able to see the searched "NovaNETMasterLibrary" course in the left frame
When I click on "Approve" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."

#Purpose: UseCase To create Program in course space
Scenario: Create Program by CS Admin
Given I am on the 'Manage Programs' Page
When I create the "NovaNET" Program in coursespace
Then I should see the successfull message "Program created successfully."

#Purpose: Creation of State Level Organization
Scenario: Create State Level NovaNET Organization by CS Admin
When I navigate to "Organization Admin" tab of the "Organization Management" page
Then I should be on the "Organization Management" page
When I click on the Create New Organization link 
Then I should see the "Create Organization" popup
When I create the "State" level organization "Hierarchical" in "NovaNET"
Then I should see the successfull message "Organization created successfully."

#Given  I am on the 'Organization Management' page
#Purpose: Creation of Region Level Organization
Scenario: Create Region Level NovaNET Organization by CS Admin
When I navigate to "Organization Admin" tab of the "Organization Management" page
Then I should be on the "Organization Management" page
When I search the "State" level Organization in "NovaNET"
Then I should see the "State" level organization name in "NovaNET"
When I create the "Region" level organization "Hierarchical" in "NovaNET"
Then I should see the successfull message "Organization created successfully."
When I click on the Select Organization link
Then I should be on the "Organization Management" page

#Purpose: Creation of District Level Organization
Scenario: Create District Level NovaNET Organization by CS Admin 
When I navigate to "Organization Admin" tab of the "Organization Management" page
Then I should be on the "Organization Management" page
When I search the "Region" level Organization in "NovaNET"
Then I should see the "Region" level organization name in "NovaNET"
When I create the "District" level organization "Hierarchical" in "NovaNET"
Then I should see the successfull message "Organization created successfully."
When I click on the Select Organization link
Then I should be on the "Organization Management" page

#Purpose: Creation of School Level Organization
Scenario: Create School Level NovaNET Organization by CS Admin
When I navigate to "Organization Admin" tab of the "Organization Management" page
Then I should be on the "Organization Management" page
When I search the "District" level Organization in "NovaNET"
Then I should see the "District" level organization name in "NovaNET"
When I create the "School" level organization "Hierarchical" in "NovaNET"
Then I should see the successfull message "Organization created successfully."
When I create the multiple "Schools"
And I search the "School" level Organization in "NovaNET"
Then I should see the "School" level organization name in "NovaNET"

#Purpose: Create NovaNET Product
Scenario: Create Product by CS Admin
Given I am on the 'Manage Products' Page
When I create the "NovaNET" Product in coursespace using "NovaNET" Program
Then I should see the successfull message "New product created successfully."

#Purpose: UseCase To license products
Scenario: Create License for the NovaNET Organization by CS Admin
Given I am on the 'Manage Organization' page of "State" level in the "NovaNET"
And I enter into the organization
And I navigate to the "Licenses" tab
When I click on the Add Products Option
Then I should see the "Product Selection" popup
When I create license for the "NovaNET" product
And I search "Pegasus" licensed product in Coursespace
Then I should be able to see the searched "Pegasus" licensed product in the frame
And I close the "Manage Organization" window

#Purpose: UseCase To license DigitalPath Demo products
Scenario: Create License for the DigitalPath Demo Organization by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "DigitalPathDemo"
And I navigate to the "Licenses" tab
When I click on the Add Products Option
Then I should see the "Product Selection" popup
When I create 3 license for the "DigitalPathDemo" product
And I search "Pegasus" licensed product in Coursespace
Then I should be able to see the searched "Pegasus" licensed product in the frame
And I close the "Manage Organization" window

#Purpose: UseCase To license Multiple DigitalPath Demo products with same AccessCode
Scenario: Create Multiple License for the DigitalPath Demo Organization by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "DigitalPathDemo"
And I navigate to the "Licenses" tab
When I click on the Add Products Option
Then I should see the "Product Selection" popup
When I create 3 licenses for different "DigitalPathDemo" product
And I search "Pegasus" licensed product in Coursespace
Then I should be able to see the searched "Pegasus" licensed product in the frame
And I close the "Manage Organization" window

#Purpose: UseCase To View student activity report by Organization Admin
Scenario: View student activity report by Organization Admin
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
When I navigate to the "Reports" tab 
And I generate the "StudentActivityReport" in Organization Admin of student "NovaNETCsStudent" 
And It Should display the grades under launched report
Then It Should display the 'Score' under launched report
When I click on the Close button in launched report
And I close the "Manage Organization" window

#Purpose: UseCase To View Custom Report by Organization Admin
Scenario: View Custom Report by Organization Admin
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
When I navigate to the "Reports" tab
And I generate the "CustomActivityReport" in Organization Admin of student "NovaNETCsStudent" 
And I select the 'DownloadReport' in Report tab
Then I should see the "NovaNETTemplate" class 
And I close the "Manage Organization" window

#Purpose: Create Template for the Organization 
Scenario: Create Template by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
When I navigate to the "Libraries" tab
And I create the Template using "Container" course
Then I should see the successfull message "Template created successfully." in "Manage Organization" window
When I search the created Template in the frame
Then I should see the created Template in the frame
And I verifiy the Template for Assigned to Copy State 
Then I should see the created Template out of Assigned to Copy State
And I close the "Manage Organization" window

#Purpose: Creation of Class Using Master Library Added to the Basal product
Scenario: Create Class using Template by CS Admin
Given I am on the 'Manage Organization' page of "school" level in the "NovaNET"
When I navigate to the "Classes" tab
And I click on the Add Classes Option
Then I should see the "Create Class" popup
When I create the class using "Container" template
And I search "NovaNETTemplate" class in Coursespace
And I wait for class "NovaNETTemplate" to copy
Then I should be able to see the searched "NovaNETTemplate" class
And I close the "Manage Organization" window

#Purpose:To verify that CS Admin Creates the Class using Master Library Course
#TestCase ID: NN_PWF_202
Scenario: To verify the Admin Creates the Class using Master Library Course by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
When I navigate to the "Classes" tab
And I click on the Add Classes Option
Then I should see the "Create Class" popup
When I create class using "NovaNETMasterLibrary" course
And I select the user from create class window
Then I should see the "Add User" popup
When I create new "DPCsTeacher" user in CourseSpace admin
Then I should see the successfull message "New users added successfully." in Create Class Popup
When I search "NovaNETTemplate" class in Coursespace
And I wait for class "NovaNETTemplate" to copy
Then I should be able to see the searched "NovaNETTemplate" class
And I close the "Manage Organization" window

#Purpose:UseCase To add course in the class 
Scenario: Enter Class as Teacher to move the Master Library by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
When I navigate to the "Classes" tab
And I search "NovaNETTemplate" class in Coursespace
Then I should be able to see the searched "NovaNETTemplate" class
When I click on Enter Class as Teacher cmenu option of class in coursespace
Then I should be on the "Overview" page
When I navigate to the "Content" tab
And I move the ML to right frame
Then I should see the successfull message "Done! Your content" in "Content" window
And I wait for the class to get in available state
And I close the "Content" window

#Purpose: To create Teacher from Users subtab
Scenario: Create Teacher in Users Tab by CS Admin 
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
When I click on the "Users" tab in Manage Organization page
And I select the "NovaNETCsTeacher" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "NovaNETCsTeacher" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "NovaNETCsTeacher" in "Users" subtab
Then I should see the "NovaNETCsTeacher" in "Users" subtab
And I close the "Manage Organization" window

#Purpose: To create Student from Users subtab
Scenario: Create Student in Users Tab by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
Then I should be on the "Manage Organization" page
When I click on the "Users" tab in Manage Organization page
And I select the "NovaNETCsStudent" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "NovaNETCsStudent" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "NovaNETCsStudent" in "Users" subtab
Then I should see the "NovaNETCsStudent" in "Users" subtab
And I close the "Manage Organization" window

#Purpose: To create Aide from Users subtab
Scenario: Create Aide in Users Tab by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
When I click on the "Users" tab in Manage Organization page
And I select the "NovaNETCsAide" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "NovaNETCsAide" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "NovaNETCsAide" in "Users" subtab
Then I should see the "NovaNETCsAide" in "Users" subtab
And I close the "Manage Organization" window

#Purpose: To create Organization Admin from Users subtab
Scenario: Create Organization Admin in Users Tab by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
When I click on the "Users" tab in Manage Organization page
And I select the "NovaNETCsOrganizationAdmin" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "NovaNETCsOrganizationAdmin" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "NovaNETCsOrganizationAdmin" in "Users" subtab
Then I should see the "NovaNETCsOrganizationAdmin" in "Users" subtab
And I close the "Manage Organization" window

#Purpose: To Create Bulk Users from Users subtab
Scenario: Upload Bulk User in Users Tab by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
When I click on the "Users" tab in Manage Organization page
And I select the Bulk user upload option and Import a bulk users file in "Users" subtab
Then I should see the successfull message "Bulk Registration- 0 of 1 Files in progress" in Users subtab
And I close the "Manage Organization" window

#Purpose: Enroll Teacher to class
Scenario: Teacher Enrollment in Class by CS Admin 
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
When I navigate to the "Enrollment" tab
And I select the "NovaNETTemplate" class
And I select the "NovaNETCsTeacher" under User Frame
And I select the Enroll button
Then I should see the successfull message 'Users enrolled successfully'
And I close the "Manage Organization" window

#Purpose: Enroll Student to class
Scenario: Student Enrollment in Class by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "NovaNET"
When I navigate to the "Enrollment" tab
And I select the "NovaNETTemplate" class
When  I select the "NovaNETCsStudent" under User Frame
And I select the Enroll button
Then I should see the successfull message 'Users enrolled successfully'
And I close the "Manage Organization" window

#Purpose: To associate Master Library to the NovaNET Product
Scenario: Associate Master Library to the Product by CS Admin
Given I am on the 'Manage Products' Page
When I search the "NovaNETMasterLibrary" course in coursespace
Then I should be able to see the searched "NovaNETMasterLibrary" course in the left frame
When I select course in left frame
And I select product type "NovaNET" in right frame
When I associate the course to Pegasus product
Then I should see the successfull message "The course has been added successfully."

#Purpose: To associate Container Course to the NovaNET Product
Scenario: Associate Container Course to the Product by CS Admin
Given I am on the 'Manage Products' Page
When I search the "Container" course in coursespace
Then I should be able to see the searched "Container" course in the left frame
When I select course in left frame
And I select product type "NovaNET" in right frame
When I associate the course to Pegasus product
Then I should see the successfull message "The course has been added successfully."

#Purpose: To Restrict Access to Product 
Scenario: Restrict Access to Product by CS Admin
Given I am on the 'Manage Products' Page
When I select product type "NovaNET" in right frame
And I select "Preferences" cmenu of "NovaNETMasterLibrary" course
And I disable the course in product
Then I should see the successfull message "Course updated successfully."

#Purpose: Context C-Menu Options of the Product
Scenario: Display of Context CMenu Options of the Product by CS Admin
Given I am on the 'Manage Products' Page
When I search the product type "NovaNET" in right frame
And I click the product cmenu option
Then I should able to see the Display of c-menu options for product
| ExpectedResult  | ActualResult    |
| Open            | Open            |
| Edit            | Edit            |
| Product History | Product History |

#Purpose: Delete the created Organization
Scenario: Delete the created Organization by CS Admin
Given I am on the 'Organization Management' page
When I create the "School" level organization "Independent" in "NovaNET"
Then I should see the successfull message "Organization created successfully."
When I search the "School" level Organization in "NovaNET"
Then I should see the "School" level organization name in "NovaNET"
When I delete the organization
Then I should see the successfull message "Organization was successfully removed."
When I search the "School" level Organization in "NovaNET"
Then I should see the message "No records found."
