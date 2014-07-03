#Purpose: Feature Description
Feature: US58877 - Teacher Dashboard  
In order to View Activity Alert
As a CS Teacher
I want to view activity alerts on the  teacher homepage

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CSTeacher"
When I have logged into the course space as CS Teacher
Then  It should show the "Global Home" page

#Purpose: To View Activity Alerts by CS teacher
Scenario:  View Activity Alerts by CS teacher
Given Im on the "Global Home" page 
When I select the course with prefix "BDDML" as CSteacher
Then It should show the "Overview" page
Then It should display alert for New Grades
When I select 'New Grades' 
Then It should display the name of submitted activity
And I select the Home button to go back on Global Home page
#And  I clicked on the Logout link to get logged out from the application
