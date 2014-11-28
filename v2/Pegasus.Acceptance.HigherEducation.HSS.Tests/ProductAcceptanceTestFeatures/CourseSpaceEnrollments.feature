Feature: CourseSpaceInstructor Enrollement
	                 As a CS Instructor or CS Student
					I want to manage all the coursespace Enrollment related usecases 
					so that I would validate all the coursespace Enrollment scenarios are working fine.


#Purpose: To Enroll Instructor to Section
Scenario: Enroll Instructor to Section by SMS Instructor
When I enroll SMS Instructor in "HSSMyPsychLabProgram"
Then I should see enrolled "HSSMyPsychLabProgram" Section in Global Home Page 

#Purpose: To Enroll student to Section
Scenario: Enroll student to Section by SMS Student
When I enroll SMS Student in "HSSMyPsychLabProgram"
Then I should see enrolled "HSSMyPsychLabProgram" Section course in Global Home Page 
