Feature: CourseSpaceStudentEnrollment
					As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: Open Student Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To Enroll student to Section
Scenario: Enroll student to Section by SMS Student
When I enroll SMS Student in "MyItLabProgramCourse"
Then I should see enrolled Section in Global Home Page 
Then I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Enroll student to Instructor Course
Scenario: Enroll student to Instructor Course by SMS Student
When I enroll SMS Student in "MyItLabInstructorCourse"
Then I should see enrolled InstructorCourse in Global Home Page 
Then I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."
