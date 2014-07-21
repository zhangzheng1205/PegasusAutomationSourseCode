Feature: WorkSpaceInstructorPreferences
	                As a  HedWsInstructor 
					I want to manage all the workspace Teacher preferences related usecases 
					so that I would validate all the workspace Teacher preferences scenarios are working fine.

#MySpanishLabMaster Course Scenario
#Purpose: General preference settings for MySpanishLabMaster Course
Scenario: General preference settings for MySpanishLabMaster Course
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I click on the "General" tab
And I enable necessary general preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "MyTest" tab
And I enable necessary MyTest preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "Catalog" tab
And I enable necessary catalog preference settings
Then I should see the successfull message "preferences updated successfully"

#Empty Course Scenario
#Purpose: UseCase To Set Preferences for Empty Course
Scenario: Set Preferences for Empty Course by Ws Teacher
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I set the preferences for Copy Content
Then I should see the successfull message "Preferences updated successfully."
