#Purpose: Feature Description
Feature: PEGASUS-656 - Add weights in the create total column page
	                  As a instructor 
	                  I want to add the weights to the weight fields
	                 So that I can calculate the totol weight by doing sum operation

#Purpose : Open HEDWsInstructor Url
Background: 
Given I browsed the login url for "WsTeacher"
When I login to Pegasus as "WsTeacher" in "WorkSpace"
Then I should be logged in successfully

#Purpose : Validate Weight fields for 'Create Total Column' page by WsTeacher
Scenario: Validate Weight fields for 'Create Total Column' page by WsTeacher
Given I am on the "Global Home" page
When I enter in the "MasterLibrary" as "WsTeacher" from the Global Home page
And I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I click on the 'Create Column' drop down 
Then I should be on the "Create Total Column" page
When I select checkbox of activities "Test2" and "Test3" 
And I should be click the on Add button 
When I have entered "50" and "30" into weight box
Then I should able to see the result in Total Weight Textbox
When I "Sign out" from the "WsTeacher"
Then I should see the successfull message "you have been signed out of the application."