#Purpose: Feature Description
Feature:  US60230 - Calendar Creation by Cs Teacher
In order to Calendar Creation
As a CS Teacher
I want to create calendar activitie(s) by Cs Teacher

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CSTeacher"
When  I have logged into the course space as CS Teacher
Then  It should show the "Global Home" page

#Purpose : To assign activity by CS Teacher through assignment calendar
Scenario: Calendar Creation by Cs Teacher
Given Im on the "Global Home" page 
When I select the class name as CSteacher
When I navigate to the "Content" Tab
And I move to the Calendar Tab
And I Setup the view calendar format
And  I drag and drop the activity to the calendar
Then Activity should be successfully assigned to the calendar
And I select the Home button to go back from Calendar page
