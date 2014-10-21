Feature: CourseSpaceStudent Enrollement
	                 As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: To Enroll student to Section
Scenario: Enroll student to Section by SMS Student
When I enroll SMS Student in "MyITLabOffice2013Program"
Then I should see enrolled "MyITLabOffice2013Program" Section course in Global Home Page 

#Purpose: To Enroll student to Instructor Course
Scenario: Enroll student to Instructor Course by SMS Student
When I enroll SMS Student in "MyItLabInstructorCourse"
Then I should see enrolled InstructorCourse in Global Home Page 
