Feature: CourseSpaceStudentView	
	                 As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.


#Used Instructor Course
#Purpose:Use My Profile to make changes to Student Pearson account and time
#TestCase Id: HSS_Core_PWF_394
Scenario: Use My Profile to make changes to Student Pearson account and time By SMS Student
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
When I click on 'My Profile' option in "CsSmsStudent"
And I click on 'Edit Pearson Account'
Then I should see the "Log In to your Pearson Account Profile" popup
When I change the 'My Profile' settings
Then I should be on the "Global Home" page


