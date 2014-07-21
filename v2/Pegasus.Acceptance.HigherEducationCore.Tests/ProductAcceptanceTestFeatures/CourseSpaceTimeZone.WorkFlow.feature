Feature: CourseSpaceTimeZone
	     As a CsSMSInstructor
	     I want to change the user profile settings
	     so that I would be able to validate the user profile settings.

#Used Instructor Course
#Purpose:Use My Profile to make changes to Instructor Pearson account and time
Scenario: Use My Profile to make changes to Instructor Pearson account and time By SMS Instructor
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
When I click on 'My Profile' option in "CsSmsInstructor"
And I click on 'Edit Pearson Account'
Then I should see the "Log In to your Pearson Account Profile" popup
When I change the 'My Profile' settings
Then I should be on the "Global Home" page

