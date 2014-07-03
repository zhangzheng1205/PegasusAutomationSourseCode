Feature: Pegasus-3788 - Create Pegasus Program at PSN+
						As a CS Admin 
						I want to create Program
						so that I can associate it within a Product

#Purpose: Open CS Url
Background: 
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully

#Purpose: UseCase To create Program in course space
Scenario: Create Pegasus Program at PSN+ by CS Admin
Given I am on the 'Manage Programs' Page
When I create the "DigitalPath" Program in coursespace
Then I should see the successfull message "Program created successfully."
When I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."
