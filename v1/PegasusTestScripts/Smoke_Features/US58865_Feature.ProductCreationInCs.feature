#Purpose: Feature Description
Feature: US58865 - Product Creation
In order to Create Product
As a Cs Admin
I want to be Create Product

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CS Admin"
When  I have logged into the Course space as CSAdmin  
#Then  It should show the 'Manage Products' page
 
#Purpose: UseCase To Create Product in Cs
Scenario: Create Product in the Course Space  
And  I navigate to the "Publishing" Tab
And  I selected the "Manage Products" sub tab
And  I Click on the 'Create New Product' link
And  I created the product 
Then It should display successful message "New product created successfully."
#And I clicked on the Logout link to get logged out from the application