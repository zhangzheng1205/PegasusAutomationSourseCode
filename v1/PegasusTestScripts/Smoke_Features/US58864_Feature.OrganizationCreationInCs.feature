#Purpose: Feature Description
Feature: US58864 - Organization Creation
In order to Create Organisation 
As a CS Admin 
I want to create a multiple level organization

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CS Admin"
When  I have logged into the Course space as CSAdmin  

#Purpose: UseCase To Create District Level of Organization in Cs
Scenario: Create District Level of Organization in Cs
And   I navigate to the "Organization Admin" Tab
Given It should show the 'Organization Admin' page
And   I Click on the 'Create New Organisation' button
And   I create District as root level of organization
Then  It should display successful message "Organization created successfully."

#Purpose: UseCase To Create School Level of Organization in Cs
Scenario: Create School Level of Organization in Cs  
Given It should show the 'Organization Admin' page
And   I selected the District Level of Organization.
And   I Create School level of Organization
Then  It should display successful message "Organization created successfully."
#And   I clicked on the Logout link to get logged out from the application
  
