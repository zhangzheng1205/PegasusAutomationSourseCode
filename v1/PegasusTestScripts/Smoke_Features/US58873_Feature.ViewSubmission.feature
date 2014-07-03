#Purpose: Feature Description
Feature: US58873_View Submission  
In order to View Submitted Activity 
As a CS Student
I want to verify  activity submission in the class

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CsStudent"
When  I have logged into the course space as CS Student  
Then  It should show the "Global Home" page

#Purpose : To Lauch Activity by the Student in Cs
Scenario: Lauch Activity by the Student in Cs
Given I am on the "Global Home" page 
When I select the course with prefix "BDDML" as CSstudent
Then  It should show the "Overview" page
And   I navigate to the Practice Tab
When  I open the 'Activity' 
Then  It should launch the activity successfully
And I select the Home button to go back on Global Home page

#Purpose : To Activity Submission by the Student in Cs
Scenario: Activity Submission by the Student in Cs
Given I am on the "Global Home" page 
When I select the course with prefix "BDDML" as CSstudent
Then  It should show the "Overview" page
And   I navigate to the Grades Tab
And   I open the 'Activity' in Grades Tab
When  I submit the activity
Then  It should successfully submit the activity for grading
And I select the Home button to go back on Global Home page

#Purpose : To View Activity Submission by the Student in Cs
Scenario: View Activity Submission by the Student in Cs
Given I am on the "Global Home" page 
When I select the course with prefix "BDDML" as CSstudent
Then  It should show the "Overview" page
When  I navigate to the Grades Tab
Then  It should display the grade under grade column of the submitted activity
And   I clicked on the Logout link to get logged out from the application 