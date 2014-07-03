#Purpose: Feature Description
Feature: PEGASUS433(01) - Add preference setting to include student email addresses in gradebook export	in Course Space	
		 As an Instructor
		 I want to Check the availability of the new preference - include email addresses in Gradebook export file 
		 and its default status 
		 so that the email addresses of the students can be included in gradebook export
		
Background:
#Purpose: Open Course Space Url
Given I browsed the login url for "HedCoreAcceptanceInstructor"
When I logged into the Pegasus as "HedCoreAcceptanceInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Check the preference availability and the default Status in Course Space
Scenario: Check the preference availability and the default Status in course space
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the new preference in unchecked state by default	
When I check the new preference checkbox
Then I should see the check box as checked according to the user action
And I should see the successfull message "Preferences updated successfully."
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."
			
#Purpose: Check the preference status in Course Space after the course is published with checked and locked preference 
Scenario: Check the preference status in Course Space after the course is published with checked and locked preference
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see that the preference as not available in the published course 
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Check the preference status in Course Space after the course is published with unchecked and locked preference 
Scenario: Check the preference status in Course Space after the course is published with unchecked and locked preference 
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see that the preference as not available in the published course 
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."
	
#Purpose: Check the preference status in Course Space after the course is published with checked and unlocked preference 
Scenario: Check the preference status in Course Space after the course is published with checked and unlocked preference
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the check box as checked according to the user action 
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Check the preference status in Course Space after the course is published with unchecked and unlocked preference 
Scenario: Check the preference status in Course Space after the course is published with unchecked and unlocked preference 
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the check box as unchecked according to the user action
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Check the preference status in Course Space after the course is copied with checked and locked preference 
Scenario: Check the preference status in Course Space after the course is copied with checked and locked preference 
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the check box as checked according to the user action 
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Check the preference status in Course Space after the course is copied with unchecked and locked preference 
Scenario: Check the preference status in Course Space after the course is copied with unchecked and locked preference
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the check box as unchecked according to the user action 
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."
	
#Purpose: Check the preference status in Course Space after the course is copied with checked and unlocked preference 
Scenario: Check the preference status in Course Space after the course is copied with checked and unlocked preference 
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the check box as checked according to the user action 
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Check the preference status in Course Space after the course is copied with unchecked and unlocked preference 
Scenario: Check the preference status in Course Space after the course is copied with unchecked and unlocked preference 
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the check box as unchecked according to the user action
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."