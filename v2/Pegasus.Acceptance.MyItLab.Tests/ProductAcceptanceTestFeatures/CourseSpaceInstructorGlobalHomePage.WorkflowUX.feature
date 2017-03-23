Feature: CourseSpaceInstructorGlobalHomePage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

#-----------------------------------------------------------------------------------------------------#
							#Scripts to validate course Header Links#
#-----------------------------------------------------------------------------------------------------#
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Help Link functionality on the home page
Scenario: Instructor validate navigate Help link functionality on global home
When I click on "Help" option in "Global Home" tab of "MyItLabAuthoredCourse" as "CsSmsInstructor" user
Then I should be on "Home Page Help" page as "CsSmsInstructor" user
And I close the "Home Page Help" window

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Support Link functionality on the home page
Scenario: Instructor validate Support link functionality on global home
Given I am on the "Global Home" page
When I click on "Support" option in "Global Home" tab of "MyItLabAuthoredCourse" as "CsSmsInstructor" user
Then I should be on "Pearson Education Customer Technical Support" page as "CsSmsInstructor" user
And I close the "Pearson Education Customer Technical Support" window

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The User name and Welcome message displayed on the home page
Scenario: Validate user name and welcome message in header of global home
Then I should be displayed with "Hi," message for "CsSmsInstructor" user

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The My Profile Link functionality on the home page
Scenario: Instructor validate  My Profile link functionality in global home
When I click on "My Profile" option in "Global Home" tab of "MyItLabAuthoredCourse" as "CsSmsInstructor" user
Then I should be displayed with "My Pearson account" lightbox

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Privacy link functionality displayed on the home page
Scenario: Instructor validate Privacy link functionality in course global home
When I click on "Privacy" option in "Global Home" tab of "MyItLabAuthoredCourse" as "CsSmsInstructor" user
Then I should be on the "Privacy" page
And I close the "Privacy" window

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Signout link functionality displayed on the home page
Scenario: Instructor validate sign out link functionality in course global home
When I click on "Sign out" option in "Global Home" tab of "MyItLabAuthoredCourse" as "CsSmsInstructor" user
Then I should see the successfull message "You have been signed out of the application."

#-----------------------------------------------------------------------------------------------------#
							#Scripts to validate Create Course and Enroll in a course buttons#
#-----------------------------------------------------------------------------------------------------#
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The My Courses and Testbanks displayed on the home page
Scenario:Validate Channels in home page as CsSmsInstructor
Given I am on the "Global Home" page
Then I should be displayed with "My Courses and Testbanks" channel  on "Global Home" page as "CsSmsInstructor" user
And I should be displayed with "Create a Course" button in "My Courses and Testbanks" channel on "Global Home" page
And I should be displayed with "Enroll in a Course" button in "My Courses and Testbanks" channel on "Global Home" page

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify self enrollment of CsSmsInstructor to the course
Scenario:Validate self enrollment in home page as CsSmsInstructor
When I click on "Enroll in a Course" button in "My Courses and Testbanks" channel as "CsSmsInstructor" user 
Then I should be displayed with "Enroll in a Course" lightbox
And I should be displayed step "1" with "Course ID" in "Enroll in a Course" popup as "CsSmsInstructor" user 
When I enter "RegMyITLabNewCourseForEnrollment" ID and click submit
Then I should be displayed step "2" with "Confirm Course" in "Enroll in a Course" popup as "CsSmsInstructor" user
And I should be displayed with message "The Course ID you entered matched the following instructor and course."
And I should be displayed with the course name "RegMyITLabNewCourseForEnrollment"
When I click "Confirm" button
Then I should be displayed with "RegMyITLabNewCourseForEnrollment" course as "CsSmsInstructor" in "My Courses and Testbanks" channel

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The enrolled course in "My Courses and Testbanks" channel on the home page
Scenario: Validate open button functionallity for course as CsSmsInstructor
Given I am on the "Global Home" page
When I click on Open button of "MyItLabAuthoredCourse" as "CsSmsInstructor" user
Then I should be displayed with "MyItLabAuthoredCourse" course information for "CsSmsInstructor" user

#---------------------------------------------------------------------------------------------------------#
		#Scripts to validate Instructor,MyTest and Program course creation based on ISBN and Decipline#
#---------------------------------------------------------------------------------------------------------#
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The course creation by CsSmsInstructor using course ISBN number
Scenario:Validate course creation from Create a Course catlog based on course ISBN
When I click on "Create a Course" button in "My Courses and Testbanks" channel as "CsSmsInstructor" user 
Then I should be displayed with "Create a Course" lightbox
And I should be displayed step "1" with "Search Catalog" in "Create a Course" popup as "CsSmsInstructor" user
When I click on next button with "RegMyITLabNewlyCreatedCourse" course ISBN as search criteria
Then I should be displayed step "2" with "Select Course" in "Create a Course" popup as "CsSmsInstructor" user
When I click on "Select Course" button of "RegMyITLabNewlyCreatedCourse" course

Scenario: Validate the display of newly created course
Then I should be displayed with "RegMyITLabNewlyCreatedCourse" Instructor course as "CsSmsInstructor" in "My Courses and Testbanks" channel

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre-Condition : Master Course should be specified in the in memory
#Purpose:Verify The course creation by CsSmsInstructor using course discipline
Scenario:Validate course creation from Create a Course catlog based on course decipline
When I click on "Create a Course" button in "My Courses and Testbanks" channel as "CsSmsInstructor" user 
Then I should be displayed with "Create a Course" lightbox
And I should be displayed step "1" with "Search Catalog" in "Create a Course" popup as "CsSmsInstructor" user
When I select "All Disciplines" option in 'Browse by Discipline' dropdown
Then I should be displayed step "2" with "Select Course" in "Create a Course" popup as "CsSmsInstructor" user
When I click on "Select Course" button of "MyItLabAuthoredCourse" using course descipline
Then I should be displayed with "MyItLabAuthoredCourse" Instructor course as "CsSmsInstructor" in "My Courses and Testbanks" channel

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre-Condition : Master Course should be specified in the in memory
#Purpose:Verify The MyTest course creation by CsSmsInstructor using course discipline
Scenario:Validate MyTest course creation from Create a Course catlog based on course decipline
When I click on "Create a Course" button in "My Courses and Testbanks" channel as "CsSmsInstructor" user 
Then I should be displayed with "Create a Course" lightbox
And I should be displayed step "1" with "Search Catalog" in "Create a Course" popup as "CsSmsInstructor" user
When I select "All Disciplines" option in 'Browse by Discipline' dropdown
Then I should be displayed step "2" with "Select Course" in "Create a Course" popup as "CsSmsInstructor" user
When I click on "Select Testbank" button of "MyTestAuthoredCourse" using course descipline
Then I should be displayed with "MyTestAuthoredCourse" MyTest course as "CsSmsInstructor" in "My Courses and Testbanks" channel

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre-Condition : Master Course should be specified in the in memory
#Purpose:Verify The Program course creation by CsSmsInstructor using course discipline
Scenario: Validate Program course creation from Create a Course catlog based on course decipline
When I click on "Create a Course" button in "My Courses and Testbanks" channel as "CsSmsInstructor" user 
Then I should be displayed with "Create a Course" lightbox
And I should be displayed step "1" with "Search Catalog" in "Create a Course" popup as "CsSmsInstructor" user
When I select "All Disciplines" option in 'Browse by Discipline' dropdown
Then I should be displayed step "2" with "Select Course" in "Create a Course" popup as "CsSmsInstructor" user
When I click on "Select Program" button of "MyITLabOffice2013Program" using course descipline
Then I should see the program "MyITLabOffice2013Program" created as "CsSmsInstructor" user

#-----------------------------------------------------------------------------------------------------#
							#Scripts to validate context menu option of the course#
#-----------------------------------------------------------------------------------------------------#
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre-Condition : Course should be created
#Purpose:Verify "Edit Course Info" cmenu option on home page
Scenario:Validate course information update on CsSmsInstructor home page
Given I am on the "Global Home" page
When I select cmenu "Edit Course Info" option of Instructor course "MyItLabAuthoredCourse" for "CsSmsInstructor"
Then I should be displayed with "Update Course" lightbox
When I click on "Update" button for course "MyItLabAuthoredCourse" created
Then I should see successfull message "Course updated successfully." on "Global Home" page
 
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre-Condition : Course should be created
#Purpose:Verify "Mark for Deletion" cmenu option on home page
Scenario:Validate mark for delete cmenu option of IC course on CsSmsInstructor home page
Given I am on the "Global Home" page
When I select cmenu "Mark for Deletion" option of Instructor course "MyItLabAuthoredCourse" for "CsSmsInstructor"
Then I should see the "Marked for Deletion" status updated for the "MyItLabAuthoredCourse" course as "CsSmsInstructor" user
And I should see successfull message "Course marked for deletion." on "Global Home" page

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre-Condition : Course should be created
#Purpose:Verify " Copy as Instructor Course" cmenu option on home page
Scenario:Validate copy as instructor Course cmenu option of IC course
Given I am on the "Global Home" page
When I select cmenu "Copy as Instructor Course" option of Instructor course "MyItLabInstructorCourse" for "CsSmsInstructor"
Then I should be displayed with "MyItLabInstructorCourse" MyTest course as "CsSmsInstructor" in "My Courses and Testbanks" channel
And I should see successfull message "Copied as instructor course." on "Global Home" page

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre-Condition : Course should be created
#Purpose:Verify "Unmark for Deletion" cmenu option on home page
Scenario:Validate Unmark for deletion cmenu option of IC course on CsSmsInstructor home page
Given I am on the "Global Home" page
When I select cmenu "Unmark for Deletion" option of Instructor course "MyItLabAuthoredCourse" for "CsSmsInstructor"
Then I should see successfull message "Course removed from the deletion list." on "Global Home" page





