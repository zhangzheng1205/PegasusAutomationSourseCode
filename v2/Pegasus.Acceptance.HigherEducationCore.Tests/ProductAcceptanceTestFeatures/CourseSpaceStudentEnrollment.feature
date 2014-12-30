Feature: CourseSpaceStudent Enrollement
	                 As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: To Enroll student to Section
Scenario: Enroll student to Section by SMS Student to WL Course
When I enroll SMS Student in "MySpanishLabProgram"
Then I should see enrolled "MySpanishLabProgram" Section in Global Home Page 