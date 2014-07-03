Feature: CourseSpaceStudentView	
	                 As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully

#Purpose:Use My Profile to make changes to Student Pearson account and time
#TestCase Id: HSS_Core_PWF_394
Scenario: Use My Profile to make changes to Student Pearson account and time By SMS Student
Given I am on the "Global Home" page 
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I click on 'My Profile' option in "CsSmsStudent"
And I click on 'Edit Pearson Account'
Then I should see the "Log In to your Pearson Account Profile" popup
When I change the 'My Profile' settings
Then I should be on the "Global Home" page


