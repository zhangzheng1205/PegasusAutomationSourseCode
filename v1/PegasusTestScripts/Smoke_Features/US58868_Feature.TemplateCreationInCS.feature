#Purpose: Feature Description
Feature: US58868 - Template Creation 
In order to Create Template 
As a Pearson Admin 
I want to create a organisation template

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CS Admin"
When  I have logged into the Course space as CSAdmin  
And I navigate to the "Course Enrollment" tab 


#Purpose: Create Template for the Organization 
Scenario: Create Template for the Organization 
When I navigate to the "Organization Admin" tab
When I search the "School" level organization
Then I should see the "Manage Organization" popup 
And  I select the Libraries Tab
When I created the Template using Container Course
Then  It should display successful message "Template created successfully." in "Manage Organization" page
When I Wait for the template out from Assign To Copy State
#And   I clicked on the Logout link to get logged out from the application