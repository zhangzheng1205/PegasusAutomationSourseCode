#Purpose: Feature Description
Feature: US59275 - Course Association To Product
In order to associate course to Product 
As a CS Admin 
I want to associate Container Course and master Course to product

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CS Admin"
And  I have logged into the Course space as CSAdmin  

# Purpose: To associate ML to Product
Scenario: Master Library Association to Product 
Given It should show the 'Manage Products' page
And I select the "NovaNET" product in the right frame
And I select the "AuthoredMasterLibrary" course
When I associate the course to product 
Then It should display successful message "The course has been added successfully."

# Purpose: To associate Container to Product
Scenario: Container Course Association to Product 
Given It should show the 'Manage Products' page
And I select the "NovaNET" product in the right frame
And I select the "Container" course
When I associate the course to product 
Then It should display successful message "The course has been added successfully."
#And  I clicked on the Logout link to get logged out from the application


