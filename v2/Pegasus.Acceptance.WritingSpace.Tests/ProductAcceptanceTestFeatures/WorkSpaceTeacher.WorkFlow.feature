Feature: WorkSpaceTeacher
	                As a Ws Instructor 
					I want to manage all the workspace Instructor related usecases 
					so that I would validate all the workspace Instructor scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully

#Purpose: Writing space - Course preference to enable/disable writing space
Scenario: Writingspace Course preference to enable/disable writing space
Given I am on the "Global Home" page
When I enter in the "HEDGeneral" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I click on the "Writing Assistant" tab
And I enable the necessary writing assistant preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "Grading" tab
And I enable the necessary grading preference settings
Then I should see the successfull message "preferences updated successfully"
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."