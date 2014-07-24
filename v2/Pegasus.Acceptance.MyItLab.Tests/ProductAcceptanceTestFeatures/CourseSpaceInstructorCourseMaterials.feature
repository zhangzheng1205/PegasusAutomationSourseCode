Feature: CourseSpaceInstructorCourseMaterials
	                As a CS Instructor 
					I want to manage all the course materials workflow related usecases 
					so that I would validate all the coursespace course materials instructor workflow related scenarios are working fine.

# Assign Assets in My Course Frame
Scenario: Assign Content In My Course Frame
When I navigate to "Course Materials" tab
And I selected activity "Access Chapter 1: End-of-Chapter Quiz" and assigned in My Course frame
Then I should see the successfull message "Content item is added to My Course"