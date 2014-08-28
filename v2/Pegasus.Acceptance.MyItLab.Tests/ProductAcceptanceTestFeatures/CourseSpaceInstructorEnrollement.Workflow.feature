Feature: CourseSpaceInstructor Enrollement
	                 As a CS Instructor 
					I want to manage all the coursespace Instructor related usecases 
					so that I would validate all the coursespace Instructor scenarios are working fine.


#Purpose: To Enroll Instructor to Section
Scenario: Enroll Instructor to Section by SMS Instructor
When I enroll SMS Instructor in "MyITLabOffice2013Program"
Then I should see enrolled "MyITLabOffice2013Program" Section in Global Home Page 

