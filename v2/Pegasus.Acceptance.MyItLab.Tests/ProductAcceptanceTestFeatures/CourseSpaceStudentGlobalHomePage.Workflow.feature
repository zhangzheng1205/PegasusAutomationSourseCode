Feature: CourseSpaceStudentGlobalHomePage
	               As a CS Student 
				   I want to manage all the coursespace student related usecases 
				   so that I would validate all the coursespace student scenarios are working fine.

#Purpose: My Profile Quick links accessibility by SMS Student
# TestCase Id: HED_MIL_PWF_164
#MyItLabProgramCourse
Scenario: My Profile Quick links accessibility by SMS Student
When I click on 'My Profile' option in "CsSmsStudent"
Then I should see the "My ProfileMy Pearson accountTime zoneLocalization" in 'My Profile'

#Purpose :Feedback Quick links accessibility by SMS Student
#TestCase : HED_MIL_PWF_165
#MyItLabProgramCourse
Scenario: Feedback Quick links accessibility by SMS Student
When I click on 'Feedback' option
Then I should be on the "Feedback" page
And I should see the "General feedbackCourse Materials feedback" in the 'Feedback' window
When I close the "Feedback" window

Scenario: Validate expand and collapse functionaly of "My Courses and Testbanks" as CsSmsStudent
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I click on "Expand" icon in "My Courses and Testbanks" frame as "CsSmsStudent" user