Feature: CourseSpaceStudentGlobalHomePage
	               As a CS Student 
				   I want to manage all the coursespace student related usecases 
				   so that I would validate all the coursespace student scenarios are working fine.

#Purpose: Open Student Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully

#Purpose: My Profile Quick links accessibility by SMS Student
# TestCase Id: HED_MIL_PWF_164
Scenario: My Profile Quick links accessibility by SMS Student
Given I am on the "Global Home" page
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsStudent"
And I click on 'My Profile' option in "CsSmsStudent"
Then I should see the "My ProfileMy Pearson accountTime zoneLocalization" in 'My Profile'
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."


#Purpose :Feedback Quick links accessibility by SMS Student
#TestCase : HED_MIL_PWF_165
Scenario: Feedback Quick links accessibility by SMS Student
Given I am on the "Global Home" page
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsStudent"
And I click on 'Feedback' option
Then I should be on the "Feedback" page
And I should see the "General feedbackCourse Materials feedback" in the 'Feedback' window
When I close the "Feedback" window
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."