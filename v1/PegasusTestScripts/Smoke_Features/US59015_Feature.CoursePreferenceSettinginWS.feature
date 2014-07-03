#Purpose: Feature Description
Feature: US59015 - Course Preference Settings
In order to Create Special Type of courses
As a WS Teacher
I want to set course preferences


#Purpose: UseCase To Publish Master Library
Scenario: Publish the Course as Master Library in order to add in Container Course
Given I have browsed url for "WS Admin"
When  I have logged into the work space as WSAdmin  
Then  It should show the "Course Enrollment" page
And   I selected the "Authored Master Library" Course
And   I Checked AssignedToCopy status for ML
And   I clicked on the Cmenu of Course
And   I clicked on the "Publish Master Library" link
Then  I should see the "Publishing Notes" popup
And   I enter the Publishing notes
And   I clicked on the 'Publish' button
Then  It should display successful message "Course published successfully."
And  I Update the publish status in DB for Authored Master Library
And I clicked on the Logout link to get logged out from the application


#Purpose: UseCase To Approve Course(s)
Scenario: Approve the Master Library course(s) in Cs
Given I have browsed url for "CS Admin"
When  I have logged into the Course space as CSAdmin  
Then  It should show the "Course Enrollment" page
And   I navigate to the "Publishing" Tab
And   I selected the "Manage Products" sub tab
And   I select the "AuthoredMasterLibrary" Course to approve
And   I clicked on the "Approve" link for the course
Then  It should display successful message "Published course marked as Approved." for the published course
And   I clicked on the Logout link to get logged out from the application

@SetPreferenceSettingsforcontainerCourse(s)
#Purpose: UseCase To Set Preference Settings for container Course(s)
Scenario Outline: Set Preference Settings for Container Course
Given I have browsed url for "WSTeacher"
When I have logged into the work space as WS Teacher
Then  It should show the "Global Home" page
When I select the course name with prefix <coursename>
Examples:
| coursename |
| BDDCC      |
Then It should show the "Overview" page
When I navigate to the "Preferences" tab
When I select the Copy Content sub tab
And I set the preferences for Copy Content
Then It should display successful message "Preferences updated successfully."
When I select the Shared Library sub tab
When I set the preferences for Shared Library 
Then It should display successful message "Shared library courses successfully added to the current course."
And  Update the preference status in DB for BDDCC
And   I clicked on the Logout link to get logged out from the application

#Purpose: UseCase To Set Preference Settings for Empty Class(s)
Scenario Outline: Set Preference Settings for Empty Class
Given I have browsed url for "WSTeacher"
When I have logged into the work space as WS Teacher
Then  It should show the "Global Home" page
When I select the course name with prefix <coursename>
Examples:
| coursename |
| BDDEC      |
Then It should show the "Overview" page
When I navigate to the "Preferences" tab
When I select the Copy Content sub tab
And I set the preferences for Copy Content
Then It should display successful message "Preferences updated successfully."
When I select the Custom Content sub tab
And I set the preferences for Custom Content
Then It should display successful message "Preferences updated successfully."
When I select the My Course sub tab
When I set the preferences for My Course
Then It should display successful message "Preferences updated successfully."
When I select the Content sub tab
When I set the preferences for Content
Then It should display successful message "Preferences updated successfully."
And  Update the preference status in DB for BDDEC
And   I clicked on the Logout link to get logged out from the application