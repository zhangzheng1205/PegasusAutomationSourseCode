Feature: CourseSpaceInstructorPreference
					As a CS Instructor 
					I want to manage all the coursespace course preference related usecases 
					so that I would validate that all the coursespace course preference scenarios are working fine.

#Purpose:Necessary preference setting for creating a new Activity Type
Scenario: CourseSpace Instructor Sets preference settings to create a new activity type
When I click on "Preferences" button in "Today's View"
Then I should be on the "Preferences" page
When I click on the "Activities" tab
And I click on the "Add Activity Name" tab
When I enter "Test1" as new activity type name
And I click on Save Preferences button on Preferences page
Then I should see the successfull message "Preferences updated successfully."
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option in Content Library
Then I should see the "Test1" activity type in the Add Course Materials menu
And I should be on the "Course Materials" page

#Purpose:CourseSpace Instructor Functionality of 'Save' button when Messages are created in Main Preference
Scenario: CourseSpace Instructor Functionality of 'Save' button when Messages are created in Main Preference
When I click on "Preferences" button in "Today's View"
Then I should be on the "Preferences" page
When I click on the "Activities" tab
And I click on the Edit Preferences link
Then I should be on the "Default preferences" page
When I click on the "Messages" sub-tab
And I enter Beginning of activity Default and Instructor messages
And I enter End of activity Default and Instructor messages
And I click on the "Save" button
Then I should see the successfull message "Preference settings updated for selected activity type."
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option in Content Library
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I enter the necessary details begin creation of Assignment behavioral type
Then I should be on the "Create Assignment activity" page
When I click on the Messages activity subtab
Then I should see the activity Beginning and End messages set in Main Course Preferences
