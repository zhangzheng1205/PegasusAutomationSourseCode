Feature: PEGASUS-617 - Grade book data export in Course Space with default settings of Include email eddress preference status
							As an Instructor
							Verify the gradebook exported file when the preference is left with default status
							so that the email addresses of the students is not seen in gradebook export AND download

#Used HedCoreAcceptanceInstructorCourse Course
#Purpose: Leave the default values for the Email Address preference
Scenario: Leave the default values for the Email Address preference
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I select 'Grading' sub tab/Option
Then I should see the 'include email addresses in Gradebook export file' preference
And I should see the new preference in unchecked state by default

#Used HedCoreAcceptanceInstructorCourse Course
#Purpose: EmailAddress column should not be present in the GB exported file when Student ID option is selected
Scenario: EmailAddress column should not be present in the GB exported file when Student ID option is selected
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I select Student ID in the dropdown
And I should download the grade book
Then I should save the downloaded GB file
And I read the saved file to check if the EmailAddress colum is absent

#Used HedCoreAcceptanceInstructorCourse Course
#Purpose: EmailAddress column should not be present in the GB exported file when Student ID and Student NAME option is selected
Scenario: EmailAddress column should not be present in the GB exported file when Student ID and Student NAME option is selected
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I select Student ID and Student NAME in the dropdown
And I should download the grade book
Then I should save the downloaded GB file
And I read the saved file to check if the EmailAddress colum is absent

#Used HedCoreAcceptanceInstructorCourse Course
#Purpose: EmailAddress column should not be present in the GB exported file when Student NAME option is selected
Scenario: EmailAddress column should not be present in the GB exported file when Student NAME option is selected
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I select Student NAME in the dropdown
And I should download the grade book
Then I should save the downloaded GB file
And I read the saved file to check if the EmailAddress colum is absent