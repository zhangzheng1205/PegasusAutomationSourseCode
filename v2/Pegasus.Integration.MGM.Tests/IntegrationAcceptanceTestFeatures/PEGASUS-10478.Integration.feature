Feature: PEGASUS-10478: MGM - Import MGM Cartridge
					As a WorkSpace Autohor
					I want to manage all the workspace author related usecases 
					so that I would validate all the workspace author scenarios are working fine.

#Purpose: Open Ws Url and login as WsTeacher
Background:
Given I browsed the login url for "WsTeacher"
When I login to Pegasus as "WsTeacher" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page

#Purpose: UseCase To Import MGM Related Questions In Master Course
Scenario: Import MGM Question Cartridge by WS Teacher
When I enter in the "MasterLibrary" as "WsTeacher" from the Global Home page
Then I should see the defaults tabs for "WsTeacher"
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I import the MGM cartridge
Then I should see the successfull message "The import completed successfully. # links were created."
And I should see  activity in the Content Library Frame
| ActivityType |
|Test|
|SkillStudyPlan|
When I "Sign out" from the "WsTeacher"
Then I should see the successfull message "You have been signed out of the application."
