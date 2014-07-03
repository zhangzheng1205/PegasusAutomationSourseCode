Feature: CourseSpaceStudent
					As a CS Student 
					I want to manage all the Student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: Open Student Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To Enroll student to Instructor Course
@EnrollStudentToInsCourse
Scenario: Enroll student to Instructor Course by SMS Student
When I enroll SMS Student in "MyTestInstructorCourse"
Then I should see enrolled InstructorCourse in Global Home Page 
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To check the Saved Preferences changes to the activity
#TestCase Id: HED_MYTest_PWF_076
Scenario: To check the Saved Preferences changes to the activity By SMS Student
When I enter in the "MyTestInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the "MyTest" activity in Course Materials

#Purpose: To check the grade schema functionality for the Test activity
#TestCase Id: HED_MYTest_PWF_077
Scenario: To check the grade schema functionality for the Test activity By SMS Student
When I enter in the "MyTestInstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Grades" tab
Then I should be on the "Gradebook" page
And I should see the 'MyTest' activity score in Gradebook
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."










