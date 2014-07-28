#Purpose: Feature Description
Feature: PEGASUS433(02) - Add preference setting to include student email addresses in gradebook export	in Work Space		
		 As an Instructor
		 I want to Check the availability of the new preference - include email addresses in Gradebook export file 
		 and its default status 
		 so that the email addresses of the students can be included in gradebook export		

# Used MySpanishLabMaster Course
#Purpose: Check the preference availability and the default Status in Work Space
Scenario: Check the preference availability and the default Status in work space	
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the new preference in unchecked state by default
When I check the new preference checkbox
Then I should see the check box as checked according to the user action
And I should see the successfull message "Preferences updated successfully."

# Used MySpanishLabMaster Course	
#Purpose: Download Current Page option is selected in Work Space 
Scenario: Download Current Page option is selected in Work Space 	
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I select Current Page Option
Then I should see current pages option selected
And I should check the preference status on WS UI before download
When I should click on Download icon	
Then I should save the downloaded file
And I read the current page saved file on WS to check if the downloaded values match with the UI settings

# Used MySpanishLabMaster Course
#Purpose: Download All Pages option is selected in Work Space 
Scenario: Download All Pages option is selected in Work Space 	
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I select All Pages Option
Then I should see all pages option selected
And I should check the preference status on WS UI before download
When I should click on Download icon	
Then I should save the downloaded file
And I read the all pages saved file on WS to check if the downloaded values match with the UI settings

#Purpose: Check and lock the preference status in Work Space before the course is published 
Scenario: Check and lock the preference status in Work Space before the course is published 	
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I check the new preference checkbox
Then I should see the check box as checked according to the user action
And I should see the successfull message "Preferences updated successfully."

#Purpose: Uncheck and lock the preference status in Work Space before the course is published 
Scenario: Uncheck and lock the preference status in Work Space before the course is published 	
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the successfull message "Preferences updated successfully."

#Purpose: Uncheck and unlock the preference status in Work Space before the course is published 
Scenario: Uncheck and unlock the preference status in Work Space before the course is published	
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the new preference in unchecked state by default

#Purpose: Check and unlock the preference status in Work Space before the course is published 
Scenario: Check and unlock the preference status in Work Space before the course is published 	
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I check the new preference checkbox
Then I should see the check box as checked according to the user action
And I should see the successfull message "Preferences updated successfully."
	
#Purpose: Check and lock the preference status in Work Space before the course is copied 
Scenario: Check and lock the preference status in Work Space before the course is copied	
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I check the new preference checkbox
Then I should see the check box as checked according to the user action
And I should see the successfull message "Preferences updated successfully."

#Purpose: Uncheck and lock the preference status in Work Space before the course is copied 
Scenario: Uncheck and lock the preference status in Work Space before the course is copied 	
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the successfull message "Preferences updated successfully."

#Purpose: Uncheck and unlock the preference status in Work Space before the course is copied 
Scenario: Uncheck and unlock the preference status in Work Space before the course is copied 	
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the new preference in unchecked state by default

#Purpose: Check and unlock the preference status in Work Space before the course is copied 
Scenario: Check and unlock the preference status in Work Space before the course is copied 	
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
When I check the new preference checkbox
Then I should see the check box as checked according to the user action
And I should see the successfull message "Preferences updated successfully."