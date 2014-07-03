#Purpose: Feature Description
Feature: US58875 - View Grades   
In order to  View Activity Grade 
As a CS Teacher and Student
I want to view grade(s) 

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CSTeacher"
When  I have logged into the course space as CS Teacher
Then  It should show the "Global Home" page

#Purpose : To View grades by the Teacher in Cs
Scenario: View Grades by the Teacher in Cs
Given Im on the "Global Home" page 
When I select the course with prefix "BDDML" as CSteacher
Then It should show the "Overview" page
When I navigate to the "Gradebook" Tab
Then It should display the grade under activity column of the submitted activity
And I select the Home button to go back on Global Home page