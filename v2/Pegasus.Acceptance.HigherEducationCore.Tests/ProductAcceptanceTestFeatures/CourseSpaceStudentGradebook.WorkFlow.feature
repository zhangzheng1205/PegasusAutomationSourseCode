Feature: CourseSpaceStudentGradebook
	                As a CS Student 
					I want to manage all the Gradebook related usecases 
					so that I would validate all the coursespace student scenarios are working fine.
					
#Used Instructor Course
#Purpose: To check the display of contents in student side Grades tab 
# TestCase Id: HSS_Core_PWF_580
Scenario: To check the display of contents in student side Grades tab By SMS Student
When I navigate to "Grades" tab and selected "Grades" subtab
Then I should be on the "Gradebook" page
And I should see columns and filter options displayed in gradebook
And I should see folder navigation frame and filter dropdown
