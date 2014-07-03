#Purpose: Feature Description
Feature: US61717 - Course Copy Creation 
In order to Course Copy Creation
As a Ws Admin
I want to create copy of authored course(s) by Ws Admin

#Purpose: Open Ws Url
Background: 
Given I have browsed url for "WS Admin"
When I have logged into the work space as WSAdmin  
Then  It should show the "Course Enrollment" page

#Purpose: UseCase To Course Copy Creation
Scenario: Create the Course Copy
Given I am on the Course Creation page
And   I selected the "AuthoredCourse" Course
And   I clicked on the Cmenu of Course
And   I clicked on the "Copy as Master Course" link
Then  I should see the "Copy as Master Course" popup
And   I Copy the Course to Same Workspace
Then  It should display successful message "Copied as master course."

#Purpose: UseCase to Perform assigned to copy function on the Master library
Scenario: Perform assigned to copy function on the Master library
Given I am on the Course Creation page
And  I Wait for the course out from Assign To Copy State