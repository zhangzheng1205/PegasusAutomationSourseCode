Feature: WorkSpacePreferences
					As a Ws Instructor 
					I want to manage all the workspace Instructor Preferences related usecases 
					so that I would validate all the workspace Instructor Preferences scenarios are working fine.


Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

Scenario: General preference settings
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Preferences" tab
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

#Purpose: UseCase To Set Preferences for Empty Course
Scenario: Set Preferences for Empty Course by Ws Teacher
When I enter in the "HedEmptyClass" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I set the preferences for Copy Content
Then I should see the successfull message "Preferences updated successfully."

#Purpose: UseCase To Enable Blackboard Collaborate Voice Authoring in course preference To Use Learnosity
#PEGASUS-26115 : Learnosity Automation - Enable Blackboard IM in course preference to enable voice tool in a course
Scenario: Enable Blackboard Collaborate Voice Authoring by Ws Teacher
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I 'Enable Blackboard Collaborate Voice Authoring' preference option
Then I should see the successfull message "Preferences updated successfully."
