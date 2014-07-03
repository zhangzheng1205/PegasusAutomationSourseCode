Feature: WorkSpaceInstructorPreferences
					As a WorkSpace Autohor
					I want to manage all the workspace author related usecases 
					so that I would validate all the workspace author scenarios are working fine.

#Purpose: Open Ws Url and login as WsTeacher
Background:
Given I browsed the login url for "WsTeacher"
When I login to Pegasus as "WsTeacher" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page

#Purpose: UseCase To Set Preferences for Empty Course
Scenario: Set Preferences for Empty Course by Ws Teacher
When I enter in the "EmptyClass" as "WsTeacher" from the Global Home page
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I set the preferences for Copy Content
Then I should see the successfull message "Preferences updated successfully."
When I set the preferences for Custom Content
Then I should see the successfull message "Preferences updated successfully."
When I set the preferences for My Course
Then I should see the successfull message "Preferences updated successfully." 