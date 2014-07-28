#Purpose: Feature Description
Feature: PEGASUS-8437 - Add new badging preference to master course
	                    As a Master Course Author
	                    I want to enable the checkbox 'Enable Badge'
						So that I can validate other fields and save the preference option

# Used MySpanishLabMaster course
#Purpose: Enable Badge Preference option and validate for Single Activity
Scenario: Enable Badge Preference Option for Single Activity for HedWsInstructor 
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I click on the "Home" tab
Then I should see the "Course Listing Options" in the page
When I select the Enable Badge checkbox
Then I should see the Select Content button enabled
When I enter the TemplateID and Badge Threshold textbox fields
And I click on Select Content button
Then I should be on the "Badge Assignment Selection" page
When I select the checkbox of activity "Test1"
And I should click on Add and Close button
Then I should see the 'Test1' in the select content textbox field       
When I save the Preferences
Then I should see the successfull message "Preferences updated successfully."

# Used MySpanishLabMaster course
#Purpose: Enable Badge Preference option and validate for Single Activity
Scenario:  Enable Badge Preference Option for Multiple Activity for HedWsInstructor
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I click on the "Home" tab
Then I should see the "Course Listing Options" in the page
When I click on Select Content button
Then I should be on the "Badge Assignment Selection" page
When I select the checkbox of activities "Test Sco" and "Test_mac1"
And I should click on Add and Close button
Then I should see the 'Multiple Selected (2)' in the select content textbox field
When I save the Preferences
Then I should see the successfull message "Preferences updated successfully."

