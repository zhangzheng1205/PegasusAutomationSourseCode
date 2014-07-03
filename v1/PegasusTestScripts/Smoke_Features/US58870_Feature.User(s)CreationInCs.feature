#Purpose: Feature Description
Feature: US58870 - User Creation In Cs
In order to Create User in Cs 
As a Pearson Admin 
I want to create user(s)

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CS Admin"
When  I have logged into the Course space as CSAdmin  
#And   I go to the 'Organization Management' page

#Purpose: UseCase To Create Cs Student
Scenario: Create Student for the Organization 
Given I am on the 'Manage Organization' page 
And I navigate to the "Users" Tab
When I created the CsUser as Student
| Field              | Value      |
| txtLoginName       | Student    |
| txtPassword        | pwd        | 
| txtFirstName       | FN         |
| txtLastName        | LN         |
| txtEmail           | Email      |
Then It should display successful message "New users added successfully." in "Manage Organization" page

#Purpose: UseCase To Create Cs Teacher
Scenario: Create Teacher for the Organization 
Given I am on the 'Manage Organization' page 
And I navigate to the "Users" Tab
When I created the CsUser as Teacher
| Field              | Value      |
| txtLoginName       | Teacher    |
| txtPassword        | pwd        | 
| txtFirstName       | FN         |
| txtLastName        | LN         |
| txtEmail           | Email      |
Then It should display successful message "New users added successfully." in "Manage Organization" page

#Purpose: UseCase To Create Cs Org Admin
Scenario: Create OA for the Organization 
Given I am on the 'Manage Organization' page 
And I navigate to the "Users" Tab
When I created the CsUser as OrgAdmin
| Field              | Value      |
| txtLoginName       | OrgAdmin   |
| txtPassword        | pwd        | 
| txtFirstName       | FN         |
| txtLastName        | LN         |
| txtEmail           | Email      |
Then It should display successful message "New users added successfully." in "Manage Organization" page
# And I close the Manage Organization Window and log out from the application

#Purpose: UseCase To Create Cs Bulk User
Scenario: Bulk User for the Organization 
Given I am on the 'Manage Organization' page 
And   I navigate to the "Users" Tab
When  I select the Bulk user upload option
And   I Import a bulk user(s) file
Then  It should successfully upload the users
# And I close the Manage Organization Window and log out from the application

