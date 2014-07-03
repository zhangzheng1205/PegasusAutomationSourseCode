#Purpose: Feature Description
Feature: US58866 - View Reports 
In order to View Reports
As a CS Teacher and OAdmin
I want to view report

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CSTeacher"
When  I have logged into the course space as CS Teacher

#Purpose: To View Reports by CS teacher
Scenario: View Reports by the Teacher in Cs
Given Im on the "Global Home" page
When I select the course with prefix "BDDML" as CSteacher
Then It should show the "Overview" page
When I navigate to the "Gradebook" Tab
And I selected the "Reports" sub tab
When I generates the Student Activity report
Then It should display the grades under launched report
And I select the Home button to go back on Global Home page
#And  I clicked on the Logout link to get logged out from the application
