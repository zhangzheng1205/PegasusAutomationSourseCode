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

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Help Link functionality on the home page
Scenario:CSSMSStudent validate functionality of help link in header on global home
When I click on "Help" option in "Global Home" tab of "MyItLabInstructorCourse" as "CsSmsStudent" user
Then I should be on "Home Page Help" page as "CsSmsStudent" user

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Support Link functionality on the home page
Scenario: CSSMSStudent validate Support link functionality on global home
When I click on "Support" option in "Global Home" tab of "MyItLabInstructorCourse" as "CsSmsStudent" user
Then I should be on "Pearson Education Customer Technical Support" page as "CsSmsStudent" user
When I close the "Support" window
Then I should be on the "Global Home" page

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The User name and Welcome message displayed on the home page
Scenario: Validate user name and welcome message in header of global home for CSSMSStudent
Then I should be displayed with "Hi," message for "CsSmsStudent" user

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The My Profile Link functionality on the home page
Scenario: CSSMSStudent validate  My Profile link functionality in global home
When I click on "My Profile" option in "Global Home" tab of "MyItLabInstructorCourse" as "CsSmsStudent" user
Then I should be displayed with "My Profile" lightbox

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Privacy link functionality displayed on the home page
Scenario: CSSMSStudent validate Privacy link functionality in course global home
When I click on "Privacy" option in "Global Home" tab of "MyItLabInstructorCourse" as "CsSmsStudent" user
Then I should be on the "Privacy" page
And I close the "Privacy" window

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Logout as CsSmsStudent from global home of MyItLabInstructorCourse course
Scenario: Logout of Pegasus as CsSmsStudent from global home
When I click on "Sign out" option in "Global Home" tab of "MyItLabInstructorCourse" as "CsSmsStudent" user
Then I should see the successfull message "You have been signed out of the application."