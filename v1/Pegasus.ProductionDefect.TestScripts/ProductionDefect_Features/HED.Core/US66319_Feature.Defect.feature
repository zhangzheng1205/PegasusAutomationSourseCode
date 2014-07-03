# Feature Description To Verify Defect US66319
Feature: US66319
In order to verify the defect #US66319
As a WS Instructor
I want to verify the expected result(s) at different access point(s) in pegasus

Background: 
# Creation of Test Data : Ws User Creation
Given User already created in the workspace if not then create the user in workspace

# Creation of Test Data : Testing Course Copy
Given  Given Testing course copy already created if not then create the Testing course copy

# Creation of Test Data : Testing Course Copy
Given Ws user is already enrolled in the Testing Course Copy if not then enroll the user in Testing Course Copy

# Verify preferences from the WS instructor
Scenario: US66319_AccessPoint_FeedbackPreferencebyWSTeacher
Given I have browsed url for "HEDTeacher"
When I have logged into the work space as HEDTeacher
Then It should show the "Global Home" page
When I click  on edit link against any of the activity under preferences column
And I click on the feedback sub-tab
Then  The 'Show Correct Answer' radio button selections should be retain
And I clicked on the Logout link to get logged out from the application



