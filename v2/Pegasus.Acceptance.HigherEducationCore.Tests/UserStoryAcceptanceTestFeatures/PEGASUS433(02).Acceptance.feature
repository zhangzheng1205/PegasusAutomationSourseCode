#Purpose: Feature Description
Feature: PEGASUS433(02) - Add preference setting to include student email addresses in gradebook export	in Work Space		
		 As an Instructor
		 I want to Check the availability of the new preference - include email addresses in Gradebook export file 
		 and its default status 
		 so that the email addresses of the students can be included in gradebook export		

Background:
#Purpose: Open Course Space Url
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Check the preference availability and the default Status in Work Space
Scenario: Check the preference availability and the default Status in work space	
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the new preference in unchecked state by default
When I check the new preference checkbox
Then I should see the check box as checked according to the user action
And I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."
	
#Purpose: Download Current Page option is selected in Work Space 
Scenario: Download Current Page option is selected in Work Space 	
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I select Current Page Option
Then I should see current pages option selected
And I should check the preference status on WS UI before download
When I should click on Download icon	
Then I should save the downloaded file
And I read the current page saved file on WS to check if the downloaded values match with the UI settings
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."	

#Purpose: Download All Pages option is selected in Work Space 
Scenario: Download All Pages option is selected in Work Space 	
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I select All Pages Option
Then I should see all pages option selected
And I should check the preference status on WS UI before download
When I should click on Download icon	
Then I should save the downloaded file
And I read the all pages saved file on WS to check if the downloaded values match with the UI settings
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Check and lock the preference status in Work Space before the course is published 
Scenario: Check and lock the preference status in Work Space before the course is published 	
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I check the new preference checkbox
Then I should see the check box as checked according to the user action
And I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Uncheck and lock the preference status in Work Space before the course is published 
Scenario: Uncheck and lock the preference status in Work Space before the course is published 	
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Uncheck and unlock the preference status in Work Space before the course is published 
Scenario: Uncheck and unlock the preference status in Work Space before the course is published	
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the new preference in unchecked state by default
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Check and unlock the preference status in Work Space before the course is published 
Scenario: Check and unlock the preference status in Work Space before the course is published 	
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I check the new preference checkbox
Then I should see the check box as checked according to the user action
And I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."
	
#Purpose: Check and lock the preference status in Work Space before the course is copied 
Scenario: Check and lock the preference status in Work Space before the course is copied	
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I check the new preference checkbox
Then I should see the check box as checked according to the user action
And I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Uncheck and lock the preference status in Work Space before the course is copied 
Scenario: Uncheck and lock the preference status in Work Space before the course is copied 	
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Uncheck and unlock the preference status in Work Space before the course is copied 
Scenario: Uncheck and unlock the preference status in Work Space before the course is copied 	
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the new preference in unchecked state by default
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Check and unlock the preference status in Work Space before the course is copied 
Scenario: Check and unlock the preference status in Work Space before the course is copied 	
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I check the new preference checkbox
Then I should see the check box as checked according to the user action
And I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."	