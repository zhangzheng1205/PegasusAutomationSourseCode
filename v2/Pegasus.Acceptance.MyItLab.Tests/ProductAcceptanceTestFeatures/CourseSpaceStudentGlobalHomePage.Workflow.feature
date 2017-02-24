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
When I click on "Expand" icon in "My Courses and Testbanks" frame as "CsSmsStudent" user

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The enrolled course in "My Courses and Testbanks" channel on the home page
Scenario: Validate enrolled course in "My Courses and Testbanks" channel for SMS Student
Then I should be displayed with "RegMyITLabNewCourseForEnrollment" course as "CsSmsStudent" in "My Courses and Testbanks" channel
When I click on Open button of "RegMyITLabNewCourseForEnrollment" as "CsSmsStudent" user

#-----------------------------------------------------------------------------------------------------#
#Scripts to validate course Header Links#
#-----------------------------------------------------------------------------------------------------#
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Help Link functionality on the home page
Scenario:CSSMSStudent validate functionality of help link in header on global home
When I click on "Help" option in "Global Home" tab of "MyItLabAuthoredCourse" as "CsSmsStudent" user
Then I should be on "Home Page Help" page as "CsSmsStudent" user
And I close the "Home Page Help" window

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Support Link functionality on the home page
Scenario: CSSMSStudent validate Support link functionality on global home
When I click on "Support" option in "Global Home" tab of "MyItLabAuthoredCourse" as "CsSmsStudent" user
Then I should be on "Pearson Education Customer Technical Support" page as "CsSmsStudent" user
When I close the "Support" window


#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The User name and Welcome message displayed on the home page
Scenario: Validate user name and welcome message in header of global home for CSSMSStudent
Then I should be displayed with "Hi," message for "CsSmsStudent" user

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The My Profile Link functionality on the home page
Scenario: CSSMSStudent validate  My Profile link functionality in global home
When I click on "My Profile" option in "Global Home" tab of "MyItLabAuthoredCourse" as "CsSmsStudent" user
Then I should be displayed with "My Pearson account" lightbox

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Privacy link functionality displayed on the home page
Scenario: CSSMSStudent validate Privacy link functionality in course global home
When I click on "Privacy" option in "Global Home" tab of "MyItLabAuthoredCourse" as "CsSmsStudent" user
Then I should be on the "Privacy" page
And I close the "Privacy" window

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Logout as CsSmsStudent from global home of MyItLabInstructorCourse course
Scenario: Logout of Pegasus as CsSmsStudent from global home
Given I am on the "Global Home" page
When I click on "Sign out" option in "Global Home" tab of "MyItLabAuthoredCourse" as "CsSmsStudent" user
Then I should see the successfull message "You have been signed out of the application."

#-----------------------------------------------------------------------------------------------------#
#Scripts to validate Create Course and Enroll in a course buttons#
#-----------------------------------------------------------------------------------------------------#
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The course enrollment for SMS student
Scenario:Validate self enrollment for student
When I click on "Enroll in a Course" button in "My Courses and Testbanks" channel as "CsSmsStudent" user
Then I should be displayed with "Enroll in a Course" lightbox
And I should be displayed step "1" with "Course ID" in "Enroll in a Course" popup as "CsSmsStudent" user
When I enter "MyItLabAuthoredCourse" ID and click submit
Then I should be displayed step "2" with "Confirm Course" in "Enroll in a Course" popup as "CsSmsStudent" user
And I should be displayed with message "The Course ID you entered matched the following instructor and course."
And I should be displayed with the course name "MyItLabAuthoredCourse"
When I click "Confirm" button
Then I should be displayed with "MyItLabAuthoredCourse" course as "CsSmsInstructor" in "My Courses and Testbanks" channel

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The open button of the course for student
Scenario: Validate open button functionallity for course as CsSmsStudent
When I click on Open button of "MyItLabAuthoredCourse" as "CsSmsStudent" user
Then I should be displayed with "MyItLabAuthoredCourse" course information for "CsSmsStudent" user

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#PreCondition : Course should be in marked for deletion by CsSMSInstructor
#Purpose:Verify "Mark for Deletion" ststus for CsSMSStudent
Scenario:Validate mark for deletion status for CsSMSStudent
Then I should see the "Marked for Deletion" status updated for the "MyItLabAuthoredCourse" course as "CsSmsStudent"

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#PreCondition : Course should be in inactivated by CsSMSInstructor
#Purpose:Verify "Course is Inactive" ststus for CsSMSStudent
Scenario:Validate course inactive status for CsSMSStudent
Then I should see the "Course is Inactive" status updated for the "MyItLabAuthoredCourse" course as "CsSmsStudent"

