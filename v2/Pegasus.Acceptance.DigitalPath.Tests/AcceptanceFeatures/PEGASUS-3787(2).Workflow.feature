Feature: Pegasus-3787(2) - Create Product and Association of Master Library By CS Admin
						As a CS Admin 
						I want to create Product
						so that I can associate courses within this product.

#Purpose: Open CS Url
Background: 
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully

#Purpose: Approve Master Course in Course Space as Test Data
Scenario: Approve Pegasus Master Library by CS Admin
Given I am on the "Course Enrollment" page
When I navigate to the "Publishing" tab
And I select the "Manage Products" tab
Then I should be on the "Manage Products" page
When I search the course "MasterLibrary" in coursespace
Then I should be able to see the searched "MasterLibrary" course in the left frame
When I click on "Approve" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."
When I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Create DigitalPath Product
Scenario: Create Pegasus Product at PSN+ by CS Admin
Given I am on the 'Manage Products' Page
When I create the "DigitalPath" Product in coursespace using "DigitalPath" Program
Then I should see the successfull message "New product created successfully."
When I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Associate Master Library To Product 
Scenario: Addition of Master library to Pegasus Product by CS Admin
Given I am on the 'Manage Products' Page
When I search the course "MasterLibrary" in coursespace
Then I should be able to see the searched "MasterLibrary" course in the left frame
When I select course in left frame
And I select product type "DigitalPath" in right frame
When I associate the course to Pegasus product
Then I should see the successfull message "The course has been added successfully."
When I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."