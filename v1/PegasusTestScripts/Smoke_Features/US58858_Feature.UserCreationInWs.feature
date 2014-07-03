#Purpose: Feature Description
Feature: US58858 - User Creation
In order to Creation of User 
As a WS Admin
I want to create user

@initial_setup
#Purpose: Open Ws Url
Background: 
Given I have browsed url for "WS Admin"
When I have logged into the work space as WSAdmin  
Then  It should show the "Course Enrollment" page

@usercreation
#Purpose: UseCase To Create Ws User(s)
Scenario: Create the new User using create user link 
Given I am on the User Creation Page
And  I clicked on the "Create New User" link in "left" frame
Then  I should see the "Create New User" popup
When  I create the user  with user details     
| Field              | Value      |
| txtLoginName       | Teacher    |
| txtPassword        | pwd        | 
| txtFirstName       | FN         |
| txtLastName        | LN         |
| txtEmail           | Email      |
Then  It should display successful message "New user created successfully."
#And   I clicked on the Logout link to get logged out from the application
