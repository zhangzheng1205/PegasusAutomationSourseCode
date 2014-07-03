#Purpose: Feature Description
Feature: US58869 - Class Creation 
In order to Create Class 
As a Pearson Admin 
I want to create a Class

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CS Admin"
When  I have logged into the Course space as CSAdmin

#Purpose: UseCase To Create Class using template
Scenario: Create Class for the Organization using Template 
When I navigate to the "Organization Admin" tab
And I search the "School" level organization
Then I should see the "Manage Organization" popup 
And  I select the Classes Tab
And I select the Add Classes button
When I create the Class using Template option
Then  It should display successful message "Done!" in "Manage Organization" page
And I wait to get out of assigned to copy state
#And I close the Manage Organization Window and log out from the application

@ignore
#Purpose: UseCase To Create Class using ML
Scenario: Create Class for the Organization using ML
Given I am on the 'Manage Organization' page
And I navigate to the "Classes" Tab
And I select the Add Classes button
When I create the Class using ML option

@ignore
#Purpose: UseCase To add course in the class 
Scenario: Add Course to the class in an Organization
Given I am on the 'Manage Organization' page
And I navigate to the "Classes" Tab
And I search the Class in order to add courses
When I add the course in the class

#Purpose: UseCase To unhide ML in the class 
Scenario: Enter Class as Teacher to move the ML
Given I am on the 'Manage Organization' page
And I navigate to the "Classes" Tab
And I search the Class in order to add courses
When I enter the class as teacher
And I navigate to the "Content" tab
When I move the ML to right frame
And I Click on the Add button
Then It should display successful message "Done! Your content has been added, but may take some time before it is available." in "Content" page
And I wait for the class to get in available state
And I select the Home button
#And I close the Manage Organization Window and log out from the application

