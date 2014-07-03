Feature: CourseSpaceTimeZone
	     As a CsSMSInstructor
	     I want to change the user profile settings
	     so that I would be able to validate the user profile settings.


#Purpose: Open CS Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully

#Purpose:Use My Profile to make changes to Instructor Pearson account and time
Scenario: Use My Profile to make changes to Instructor Pearson account and time By SMS Instructor
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
And I click on 'My Profile' option in "CsSmsInstructor"
And I click on 'Edit Pearson Account'
Then I should see the "Log In to your Pearson Account Profile" popup
When I change the 'My Profile' settings
Then I should be on the "Global Home" page

