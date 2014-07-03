#Purpose: Feature Description
Feature: US58867 - License Creation 
In order to  of Create License 
As a Pearson Admin 
I want to create a product license

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CS Admin"
When  I have logged into the Course space as CSAdmin 
And I navigate to the "Course Enrollment" tab 

@ProductLicensing
#Purpose: UseCase To license products
Scenario: Create License for the Organization
Given I am on the "Course Enrollment" page
When I navigate to the "Organization Admin" tab
When I search the "District" level organization
And  I select the Organization
Then It should show the "Manage Organization" page 
And  I select the Licenses Tab
When I create the "NovaNET" product License 
#And  I clicked on the Logout link to get logged out from the application
