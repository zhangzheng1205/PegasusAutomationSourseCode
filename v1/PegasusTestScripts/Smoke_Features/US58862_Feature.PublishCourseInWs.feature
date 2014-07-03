#Purpose: Feature Description
Feature: US58862 - Publish Course
In order to Publish Course 
As a WS Admin
I want to be Publish Empty Course, Container Course, Master Library and Master Course
	
@PublishEmptyCourse
#Purpose: UseCase To Publish Empty Course
Scenario: Publish the Empty Course
Given I have browsed url for "WS Admin"
When  I have logged into the work space as WSAdmin  
Then  It should show the "Course Enrollment" page
And   I selected the "Empty" Course
And   I clicked on the Cmenu of Course
And   I clicked on the "Publish Master Course" link
Then  I should see the "Publishing Notes" popup
And   I enter the Publishing notes
And   I clicked on the 'Publish' button
Then  It should display successful message "Course published successfully."
And  I Update the publish status in DB for BDDEC
#And I clicked on the Logout link to get logged out from the application

@PublishContainerCourse
#Purpose: UseCase To Publish Container Course
Scenario: Publish the Container Course
Given I have browsed url for "WS Admin"
When  I have logged into the work space as WSAdmin  
Then  It should show the "Course Enrollment" page
And   I selected the "Container" Course
And   I clicked on the Cmenu of Course
And   I clicked on the "Publish Master Course" link
Then  I should see the "Publishing Notes" popup for Container Course
And   I enter the Publishing notes
And   I clicked on the 'Publish' button
Then  It should display successful message "Course published successfully." for Container Course
And  I Update the publish status in DB for BDDCC
And I clicked on the Logout link to get logged out from the application

@ApproveCourse
#Purpose: UseCase To Approve Empty Course(s)
Scenario: Approve the Empty Course in Cs
Given I have browsed url for "CS Admin"
When  I have logged into the Course space as CSAdmin  
Then  It should show the "Course Enrollment" page
And   I navigate to the "Publishing" Tab
And   I selected the "Manage Products" sub tab
And   I select the "Empty" Course to approve
And   I clicked on the "Approve as Empty Class" link for the course
Then  It should display successful message "Published course marked as Approved." for the published course
#And I clicked on the Logout link to get logged out from the application

#Purpose: UseCase To Approve Container Course(s)
Scenario: Approve the Container Course in Cs
Given I have browsed url for "CS Admin"
When  I have logged into the Course space as CSAdmin
And   I navigate to the "Publishing" Tab
And   I selected the "Manage Products" sub tab
Then It should show the 'Manage Products' page
And   I select the "Container" Course to approve
And   I clicked on the "Approve" link for the course
Then  It should display successful message "Published course marked as Approved." for the published course
# And I clicked on the Logout link to get logged out from the application





