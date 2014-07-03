Feature: PEGASUS-10479: MGM - Launching the MathXL activities
					As a WorkSpace Autohor
					I want to manage all the workspace author related usecases 
					so that I would validate all the workspace author scenarios are working fine.

#Purpose: Open Ws Url and login as WsTeacher
Background:
Given I browsed the login url for "WsTeacher"
When I login to Pegasus as "WsTeacher" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page

#Purpose : To Lauch Mgm Activity by the teacher in Ws
Scenario: Launch MGM Test Activity by WS Teacher
When I enter in the "MasterLibrary" as "WsTeacher" from the Global Home page
And I navigate to the "Content" tab
Then I should see "Test" activity in the MyCourse Frame
When I click on "Preview" cmenu option of activity in "WsTeacher"
Then I should see the Test activity successfully launched
When I "Sign out" from the "WsTeacher"
Then I should see the successfull message "You have been signed out of the application." 

#Purpose: UseCase To Associate Test Type Activity to My Course
Scenario: Associate Test Activity to My Course frame by WS Teacher
When I enter in the "MasterLibrary" as "WsTeacher" from the Global Home page
And I navigate to the "Content" tab
Then I should be on the "Content" page
When I select the "Test" activity
And I Click on the Add button
Then I should see the successfull message "Content item is added to My Course"
And I should see "Test" activity in the MyCourse Frame
When I "Sign out" from the "WsTeacher"
Then I should see the successfull message "You have been signed out of the application."