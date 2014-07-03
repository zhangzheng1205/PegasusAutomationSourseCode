Feature: CourseSpaceStudentGradebook
	                As a CS Student 
					I want to manage all the Gradebook related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: Open Student Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To check the display of contents in student side Grades tab 
# TestCase Id: HSS_Core_PWF_580
Scenario: To check the display of contents in student side Grades tab By SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Grades" tab
Then I should see columns and filter options displayed in gradebook
And I should see folder navigation frame and filter dropdown
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."
