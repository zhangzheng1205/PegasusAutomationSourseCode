Feature: PEGASUS-617 - Grade book data export in Course Space with Include email eddress preference status checked
							As an Instructor
							Verify the gradebook exported file when the preference is checked 
							so that the email addresses of the students is not seen in gradebook export and download

#Purpose: Open Course Space Url
Background: 
Given I browsed the login url for "HedCoreAcceptanceInstructor"
When I logged into the Pegasus as "HedCoreAcceptanceInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Check the Email Address preference
Scenario: Check the Email Address preference by CsSmsInstructor
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

#Purpose: EmailAddress column should be present in the SECOND Column of the GB exported file when Student ID option is selected
Scenario: EmailAddress column should be present in the SECOND Column of the GB exported file when Student ID option is selected
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I select Student ID in the dropdown
And I should download the grade book
Then I should save the downloaded GB file
And I read the saved file to check if the EmailAddress column is present in the SECOND column
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: EmailAddress column should be present in the FOURTH column of the GB exported file when Student ID and Student NAME option is selected
Scenario: EmailAddress column should be present in the FOURTH column of the GB exported file when Student ID and Student NAME option is selected
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I select Student ID and Student NAME in the dropdown
And I should download the grade book
Then I should save the downloaded GB file
And I read the saved file to check if the EmailAddress column is present in the FOURTH column
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: EmailAddress column should be present in the THIRD column of the GB exported file when Student NAME option is selected
Scenario: EmailAddress column should be present in the THIRD column of the GB exported file when Student NAME option is selected
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I select Student NAME in the dropdown
And I should download the grade book
Then I should save the downloaded GB file
And I read the saved file to check if the EmailAddress column is present in the THIRD column
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Check if the Import Grades functionality works as expected and displays the grades imported in the Grade Book
Scenario: Check if the Import Grades functionality works as expected and displays the grades imported in the Grade Book 
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedCoreAcceptanceInstructor"
And I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I click on create column dropdown to select Import Grades option
Then I should select the file to be uploaded
And I should provide the Column Name 
And I should indicate the Column Number 
And I should click on OK button
When I "Sign out" from the "HedCoreAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."