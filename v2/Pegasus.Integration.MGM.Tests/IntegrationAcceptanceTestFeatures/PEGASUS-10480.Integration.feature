Feature: PEGASUS-10480 : Course Creation in Math XL
					As a CS Admin 
					I want to manage all the coursespace admin related usecases 
					so that I would validate all the coursespace admin scenarios are working fine.

#Purpose: Open CS Url
Background: 
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully

#Purpose: To create Teacher from Users subtab
Scenario: Create Teacher in Users Tab by CS Admin 
Given I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
When I click on the "Users" tab in Manage Organization page
And I select the "DPCsTeacher" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "DPCsTeacher" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsTeacher" in "Users" subtab
Then I should see the "DPCsTeacher" in "Users" subtab
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To create Student from Users subtab
Scenario: Create Student in Users Tab by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
Then I should be on the "Manage Organization" page
When I click on the "Users" tab in Manage Organization page
And I select the "DPCsStudent" option from "Users" subtab
Then I should see the "Add User" popup
When I create a new "DPCsStudent" user in Coursespace
Then I should see the successfull message "New users added successfully." in "Manage Organization" window
When I search the created "DPCsStudent" in "Users" subtab
Then I should see the "DPCsStudent" in "Users" subtab
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."
	
#Purpose: Creation of Class Using Master Library Added to the Basal product
Scenario: Create Class Using Master Library by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
When I navigate to the "Classes" tab
And I click on the Add Classes Option
Then I should see the "Create Class" popup
When I create the class using "MasterLibrary" course
And I search "DigitalPathMasterLibrary" class in Coursespace
And I wait for class "DigitalPathMasterLibrary" to copy
Then I should be able to see the searched "DigitalPathMasterLibrary" class
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Enroll Teacher to class
Scenario: Teacher Enrollment in Class by CS Admin 
Given I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
When I navigate to the "Enrollment" tab
And I select the "DigitalPathMasterLibrary" class
And I select the "DPCsTeacher" under User Frame
And I select the Enroll button
Then I should see the successfull message 'Users enrolled successfully'
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Enroll Student to class
Scenario: Student Enrollment in Class by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
When I navigate to the "Enrollment" tab
And I select the "DigitalPathMasterLibrary" class
When  I select the "DPCsStudent" under User Frame
And I select the Enroll button
Then I should see the successfull message 'Users enrolled successfully'
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."
