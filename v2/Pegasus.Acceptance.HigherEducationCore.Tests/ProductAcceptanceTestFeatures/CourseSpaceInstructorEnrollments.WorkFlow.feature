Feature: CourseSpaceInstructorEnrollments
	                As a CS Instructor 
					I want to manage all the coursespace instructor enrollment related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To verify the functionality to promote student to Teaching Assistant
# TestCase Id: HSS_Core_PWF_068
Scenario: Promoting the Student as Teaching assistance by PADMIN
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I select the "Enrollments" tab
And I search the "CsSmsStudent" in the Users frame
Then I should see the searched "CsSmsStudent" in the Users frame
When I Select the searched User in the Users frame
And I search the Section1 in the Sections frame
Then I should see the searched section in section frame
When I entered into the searched section
And I Enroll user to section using "Add as TA" option
Then I should see the student promoted as Teaching Assistant in section
When I "Sign out" from the "HedProgramAdmin"
Then I should see the successfull message "You have been signed out of the application."