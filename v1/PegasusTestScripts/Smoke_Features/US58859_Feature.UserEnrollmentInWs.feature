#Purpose: Feature Description
Feature: US58859 - User Enrollment
In order to Enroll User
As a WS Admin
I want to be enroll user to Empty Course, Container Course, Master Library and Master Course

@initial_setup
#Purpose: Open Ws Url
Background: 
Given I have browsed url for "WS Admin"
When  I have logged into the work space as WSAdmin  
Then  It should show the "Course Enrollment" page

#Purpose: UseCase To Enroll User(s) To Empty Type Course
Scenario: Enroll the users to the Empty Course
Given I am on the User Enrollment Page
And   I selected the created "Empty" Course
When  I select the WsUser
And   I enrolled the user as Teacher in the Empty course
Then  It should display successful message "Teachers enrolled successfully."
Then  I should see the enrolled "Teacher" should present in Right frame as a Role Name as ''Teacher"

@ignore 
#Purpose: UseCase To Enroll User(s) To Master Library Type Course
Scenario: Enroll the users to the Master Library Course
Given I am on the User Enrollment Page
And   I selected the created "AuthoredMasterLibrary" Course
When  I select the WsUser
And   I enrolled the user as Teacher in the Master Library course
Then  It should display successful message "Teachers enrolled successfully."
Then  I should see the enrolled "Teacher" should present in Right frame as a Role Name as ''Teacher"

#Purpose: UseCase To Enroll User(s) To Container Type Course
Scenario: Enroll the users to the Container Course
Given I am on the User Enrollment Page
And   I selected the created "Container" Course
When  I select the WsUser
And   I enrolled the user as Teacher in the Container course
Then  It should display successful message "Teachers enrolled successfully."
Then  I should see the enrolled "Teacher" should present in Right frame as a Role Name as ''Teacher"
And   I clicked on the Logout link to get logged out from the application
