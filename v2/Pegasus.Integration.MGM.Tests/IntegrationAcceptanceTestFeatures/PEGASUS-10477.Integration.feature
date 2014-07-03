Feature: PEGASUS-10477: Enabling the Skills & Standards & adding the skill framework for the course
	As an Ws Instructor
	I want to enable MGM preference in work space
	so that MGM can be launched successfully.

Background:
#Purpose: Open Work Space Instructor Url
Given I browsed the login url for "WsTeacher"
When I login to Pegasus as "WsTeacher" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page

#Purpose: UseCase To Set Skills & Standard Related Preferences In Master Course
Scenario: To Set Skills & Standard Related Preferences In Master Course
When I enter in the "MasterLibrary" as "WsTeacher" from the Global Home page
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I set the Standards and Skills preference in the Mastercourse for MGM
Then I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "WsTeacher"
Then I should see the successfull message "You have been signed out of the application."
