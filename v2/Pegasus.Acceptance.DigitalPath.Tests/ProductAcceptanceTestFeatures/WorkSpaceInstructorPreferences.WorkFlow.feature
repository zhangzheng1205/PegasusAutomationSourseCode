Feature: WorkSpaceInstructorPreferences
					As a WorkSpace Autohor
					I want to manage all the workspace author related usecases 
					so that I would validate all the workspace author scenarios are working fine.

#This Usecase related to "EmptyClass" course
#Purpose: UseCase To Set Preferences for Empty Course
Scenario: Set Preferences for Empty Course by Ws Teacher
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I set the preferences for Copy Content
Then I should see the successfull message "Preferences updated successfully."
When I set the preferences for Custom Content
Then I should see the successfull message "Preferences updated successfully."
When I set the preferences for My Course
Then I should see the successfull message "Preferences updated successfully." 