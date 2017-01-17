Feature: CourseSpaceInstructorGlobalHomePage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Help Link functionality on the home page
Scenario: Instructor validate navigate Help link functionality on global home
When I click on "Help" option in "Global Home" tab of "MyItLabInstructorCourse" as "CsSmsInstructor" user
Then I should be on "Home Page Help" page as "CsSmsInstructor" user


#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Support Link functionality on the home page
Scenario: Instructor validate Support link functionality on global home
When I click on "Support" option in "Global Home" tab of "MyItLabInstructorCourse" as "CsSmsInstructor" user
Then I should be on "Pearson Education Customer Technical Support" page as "CsSmsInstructor" user

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The My Profile Link functionality on the home page
Scenario: Instructor validate  My Profile link functionality in global home
When I click on "My Profile" option in "Global Home" tab of "MyItLabInstructorCourse" as "CsSmsInstructor" user
Then I should be displayed with "My Profile" lightbox

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The User name and Welcome message displayed on the home page
Scenario: Validate user name and welcome message in header of global home
Then I should be on the "Global Home" page
And I should be displayed with "Hi," message for "CsSmsInstructor" user

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Privacy link functionality displayed on the home page
Scenario: Instructor validate Privacy link functionality in course global home
When I click on "Privacy" option in "Global Home" tab of "MyItLabInstructorCourse" as "CsSmsInstructor" user
Then I should be on the "Privacy" page
And I close the "Privacy" window

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Signout link functionality displayed on the home page
Scenario: Instructor validate sign out link functionality in course global home
When I click on "Sign out" option in "Global Home" tab of "MyItLabInstructorCourse" as "CsSmsInstructor" user
Then I should see the successfull message "You have been signed out of the application."


