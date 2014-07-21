Feature: WorkSpacePreferences
					As a Ws Instructor 
					I want to manage all the workspace Instructor Preferences related usecases 
					so that I would validate all the workspace Instructor Preferences scenarios are working fine.

#Used Master Course
Scenario: General preference settings
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I click on the "General" tab
And I enable necessary general preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "Roster" tab
And I enable necessary Roster preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "Grading" tab
And I enable necessary grades preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "Course Tools" tab
And I enable necessary course tools preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "Activities" tab
And I enable necessary activities preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "Catalog" tab
And I enable necessary catalog preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "Standards and Skills" tab
And I enable necessary Standards and Skills preference settings
Then I should see the successfull message "preferences updated successfully"

#Used Empty Course
#Purpose: UseCase To Set Preferences for Empty Course
Scenario: Set Preferences for Empty Course by Ws Teacher
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I set the preferences for Copy Content
Then I should see the successfull message "Preferences updated successfully."
