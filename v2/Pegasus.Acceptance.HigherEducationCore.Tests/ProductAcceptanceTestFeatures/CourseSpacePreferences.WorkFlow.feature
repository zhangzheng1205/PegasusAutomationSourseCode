Feature: CourseSpacePreferences
	                As a CS Instructor 
					I want to set the Preferences for the course
					so that I would be able to see all the options for the content of the course.

#Used Instructor Course
#Purpose: 'Apply Grade Schema' option should be displayed for all the contents cmenu in Gradebook By Cs Instructor
# TestCase Id: HSS_Core_PWF_147 | Story Id: 
Scenario: 'Apply Grade Schema' option should be displayed for all the contents cmenu in Gradebook By Cs Instructor
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I navigate to the "Grading" tab in Preferences Page
Then I should be on the "Grading" subtab
When I enable the 'Apply Grade Schema' option
And I save the Preferences
Then I should see the successfull message "Preferences updated successfully."
When I navigate to the "Gradebook" tab
And I click on the content cmenu icon
Then I should see the "Apply Grade Schema" in the cmenu options

#Used Instructor Course
#Purpose: Enable embedded reporting option in Preference Tab By SMS Instructor
#General Preference Should have Enable embedded reporting option in the InstructorCourse
Scenario: Enable embedded reporting option in Preference tab By SMS Instructor
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I enable the 'Enable Embedded Reporting' option
And I save the Preferences
Then I should see the successfull message "Preferences updated successfully."

#Used Instructor Course
#Purpose: Default preferences pop-up-Edit 
#TestCase Id:HSS_Core_PWF_142
Scenario: Default preferences pop up Edit 
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I navigate to the "Activities" tab in Preferences Page
And I select the 'Edit' link option of activity in the preferences column 'Customize Activity Type'
Then I should be on the "Default preferences" page
And I should see default option of the activity "Number of attempts"
When I close the "Default preferences" window

#Used Instructor Course
#Purpose: To verify the functionality to grant or deny permission to the user
#TestCase Id: HSS_Core_PWF_138
Scenario: Instructor sets permission in course preference By SMS Instructor
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I navigate to the "Permissions" tab in Preferences Page
Then I should be on the "Permissions" subtab
When I enable desired permissions for teaching assistant
Then I should see the successfull message "Preferences updated successfully."

#Used Instructor Course
#Purpose : Enable character palate in course preference
#TestCase Id :HSS_Core_PWF_145
Scenario: Enable character palate in course preference
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I check the preference option for 'character palate'
Then I should see the successfull message "Preferences updated successfully."


