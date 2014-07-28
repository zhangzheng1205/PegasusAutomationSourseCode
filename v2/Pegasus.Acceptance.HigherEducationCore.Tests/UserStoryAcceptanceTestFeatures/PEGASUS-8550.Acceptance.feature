Feature: Pegasus-8550 : MMND Sidedoor: Create a publisher branding preference for MMND backdoor login page
	In order to Login when MMND Portal down
	As a ctgPublisherAdmin
	I want to set "Welcome Text" preferene for Backdoor and check the same on Login Page.


# Used CTG Publisher Admin
#Purpose : Uploading The Welcome Text In Preference by CTG Publisheradmin
Scenario: Uploading The Welcome Text In Preference by CTG Publisheradmin
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
And I should see all the backdoor signin section in the 'Preferences' page
When I enter the Backdoor Welcome text
And I click on the Save button
Then I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HEDCSCTGPPublisherAdmin"
And I browsed the login url for "HedBackdoorLoginInstructor"
Then I should see the Welcome text displayed in login page