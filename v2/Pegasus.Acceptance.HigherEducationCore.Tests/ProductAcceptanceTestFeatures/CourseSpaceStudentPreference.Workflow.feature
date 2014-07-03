Feature: CourseSpaceStudentPreference
					As a CS Student 
					I want to manage all the Preference related usecases 
					so that I would validate all the coursespace student Preference scenarios are working fine.

#Purpose: Open Student Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To verify the Reflection of activity type in Gradebook
# TestCase Id: HSS_PWF_144
Scenario: To verify the Reflection of activity type in Gradebook By SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Grades" tab
And I click on the "Test" activity type in filter dropdown
Then I should see the "Test" activity in Gradebook 
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."