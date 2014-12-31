Feature: CourseSpaceInstructorEnrollments
	                As a CS Instructor 
					I want to manage all the coursespace instructor enrollment related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.

#Used Program Course
#Purpose: To verify the functionality to promote student to Teaching Assistant
# TestCase Id: HSS_Core_PWF_068
Scenario: Promoting the Student as Teaching assistance by PADMIN
When I navigate to "Enrollments" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "CsSmsStudent" in the Users frame
Then I should see the searched "CsSmsStudent" in the Users frame
When I Select the searched User in the Users frame
And I search the Section1 in the Sections frame
Then I should see the searched section in section frame
When I entered into the searched section
And I Enroll user to section using "Add as TA" option
Then I should see the student promoted as Teaching Assistant in section

#Purpose: To Enroll Instructor to Section
Scenario: Enroll Instructor to Section by SMS Instructor
When I enroll SMS Instructor in "MySpanishLabProgram"
Then I should see enrolled "MySpanishLabProgram" Section in Global Home Page 