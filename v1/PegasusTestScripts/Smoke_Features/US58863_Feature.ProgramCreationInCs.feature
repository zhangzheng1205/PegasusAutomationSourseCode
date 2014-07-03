#Purpose: Feature Description
Feature: US58863 - Program Creation
In order to Create Program
As a Cs Admin
I want to be Create Program
	
@initial_setup
#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CS Admin"
When  I have logged into the Course space as CSAdmin  
#Then  It should show the 'Manage Programs' page
  
@CreateProgram
#Purpose: UseCase To Create Program
Scenario: Create Program in the Course Space  
And  I navigate to the "Publishing" Tab
And  I selected the "Manage Programs" sub tab
And  I click the 'Create New Program' link
And  I created the program 
Then It should display successful message "Program created successfully."
#And  I clicked on the Logout link to get logged out from the application

