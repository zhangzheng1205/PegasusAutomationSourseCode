Feature: WorkSpaceContentAuthoringAndPreferenceSettings
	                As a Ws Instructor 
					I want to manage all the workspace Content Authoring and Preference Settings related usecases 
					so that I would validate all the workspace Content Authoring and Preference Settings scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully

#Purpose: To verify the functionality of authoring the content 
#for core course as workspace instructor and general navigation in the workspace course
# TestCase Id: HSS_Core_PWF_014
Scenario: Authoring the content for core course as workspace instructor and general navigation in the workspace course
Given I am on the "Global Home" page
When I enter in the "HEDGeneral" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
And I should see the following tabs
| TabName          | WindowTitle      |
| MyTest           | MyTest           |
| Gradebook        | Gradebook        |
| Enrollments      | Roster           |
| Communicate      | Course Mail      |
| Course Materials | Course Materials |
When I click on the 'Add Course Materials' option
And I click on the "Test" activity type
Then I should be on the "Create activity" page
When I create gradable asset of type "Test"
Then I should see the successfull message "Activity added successfully."
When I click on the 'Add Course Materials' option
And I click on the "Add Link" activity type
Then I should be on the "Add link" page
When I create the nonGgadable "Link" activity 
Then I should see the successfull message "Link saved successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

