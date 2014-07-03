#Purpose: Feature Description
Feature: US60229 - User Enrollments by Cs Teacher
In order to user enrollments by Cs Teacher
As a CS Teacher
I want to create user enrollments by Cs Teacher

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CSTeacher"
When  I have logged into the course space as CS Teacher
Then  It should show the "Global Home" page

#Purpose: UseCase to User Enrollment by Cs Teacher
Scenario: User Enrollment by Cs Teacher
Given Im on the "Global Home" page 
When I select the Template Class 
And  Enable Roaster in Preferences tab
When I navigate to the "Enrollments" Tab
And I selected the "Roster" sub tab
And I create the user as Student
| Field              | Value      |
| txtLoginName       | Student    |
| txtPassword        | pwd        | 
| txtFirstName       | FN         |
| txtLastName        | LN         |
| txtEmail           | Email      |
Then It should display successful message "User has been created successfully."
And I select the Home button to go back on Global Home page
