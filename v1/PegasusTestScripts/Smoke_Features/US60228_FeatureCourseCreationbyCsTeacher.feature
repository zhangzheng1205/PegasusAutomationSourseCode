#Purpose: Feature Description
Feature: US60228 - Course Creation by Cs Teacher
In order to course creation by Cs Teacher
As a CS Teacher
I want to create course by Cs Teacher

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CSTeacher"
When  I have logged into the course space as CS Teacher
Then  It should show the "Global Home" page

#Purpose: to create course by Cs Teacher
Scenario: Course Creation by Cs Teacher
Given Im on the "Global Home" page 
When  I navigate to the "Classes" tab
And   I select the 'Create Course' option in 'Classes' Page
And  I created the course using ML's
Then  It should display successful message "Item created successfully."
#And  I clicked on the Logout link to get logged out from the application