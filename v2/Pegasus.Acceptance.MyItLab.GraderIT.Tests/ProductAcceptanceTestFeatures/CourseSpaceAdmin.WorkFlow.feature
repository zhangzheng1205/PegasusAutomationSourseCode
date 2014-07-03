Feature: CourseSpaceAdmin
					As a CS Admin 
					I want to manage all the coursespace admin related usecases 
					so that I would validate all the coursespace admin scenarios are working fine.

#Purpose: Open CS Url
Background: 
Given I browsed the login url for "HedCsAdmin"
When I logged into the Pegasus as "HedCsAdmin" in "CourseSpace"
Then I should logged in successfully

#Purpose: Approve master course in Course space
Scenario: Approve Master Course by Cs Admin
Given I am on the "Course Enrollment" page
When I navigate to the "Publishing" tab
And I select the "Manage Products" tab
Then I should be on the "Manage Products" page
When I search the "GraderITSIM5Course" course in coursespace
Then I should be able to see the searched "GraderITSIM5Course" course in the left frame
When I click on "Approve" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To create Program in course space
Scenario: Program Creation In CourseSpace by Cs Admin
Given I am on the 'Manage Programs' Page
When I click on the Create New Program  Link
And I create the "HedMil" Program in coursespace
Then I should see the successfull message "Program created successfully."

#Purpose: Create Program Product
Scenario: Create Program Product by Cs Admin
Given I am on the 'Manage Products' Page
When I click on the 'Create New Product' Link
And I create "HedMilProgram" type product using "HedMil" program type 
Then I should see the successfull message "New product created successfully."

#Purpose: Create General Product
Scenario: Create General Product by Cs Admin
Given I am on the 'Manage Products' Page
When I click on the 'Create New Product' Link
And I create "HedMilGeneral" type product using "HedMil" program type 
Then I should see the successfull message "New product created successfully."

#Purpose: To associate courses to the Program Type Product
Scenario: Associate Course to the Program Type Product by Cs Admin
Given I am on the 'Manage Products' Page
When I search the "GraderITSIM5Course" course in coursespace
Then I should be able to see the searched "GraderITSIM5Course" course in the left frame
When I select course in left frame
And I select product type "HedMilProgram" in right frame
When I associate the course to Pegasus product
Then I should see the successfull message "Approved courses programmed successfully."

#Purpose: To associate courses to the General Product
Scenario: Associate Course to the General Product by Cs Admin
Given I am on the 'Manage Products' Page
When I search the "GraderITSIM5Course" course in coursespace
Then I should be able to see the searched "GraderITSIM5Course" course in the left frame
When I select course in left frame
And I select product type "HedMilGeneral" in right frame
When I associate the course to Pegasus product
Then I should see the successfull message "Approved courses programmed successfully."

#Purpose : Delete the Created General Type Product
Scenario: Delete the Created General Type Product by CS Admin
Given I am on the "Course Enrollment" page
When I navigate to the "Publishing" tab
And I select the "Manage Products" tab
Then I should be on the "Manage Products" page
When I search the product type "HedMilGeneral" in right frame
And I click on "Delete" cmenu option of product in coursespace
Then I should see the successfull message "Products deleted successfully."
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Delete the Created Program Type Product
Scenario: Delete the Created Program Type Product by CS Admin
Given I am on the "Course Enrollment" page
When I navigate to the "Publishing" tab
And I select the "Manage Products" tab
Then I should be on the "Manage Products" page
When I search the product type "HedMilProgram" in right frame
And I click on "Delete" cmenu option of product in coursespace
Then I should see the successfull message "Products deleted successfully."
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Approve Empty Course in Course space
Scenario: Approve Empty Course by Cs Admin
Given I am on the "Course Enrollment" page
When I navigate to the "Publishing" tab
And I select the "Manage Products" tab
Then I should be on the "Manage Products" page
When I search the "HedEmptyClass" course in coursespace
Then I should be able to see the searched "HedEmptyClass" course in the left frame
When I click on "Approve as Empty Class" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."
