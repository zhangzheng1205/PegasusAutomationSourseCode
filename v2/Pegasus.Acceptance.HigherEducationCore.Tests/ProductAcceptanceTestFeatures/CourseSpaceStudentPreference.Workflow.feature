Feature: CourseSpaceStudentPreference
					As a CS Student 
					I want to manage all the Preference related usecases 
					so that I would validate all the coursespace student Preference scenarios are working fine.

#Used Instructor Course
#Purpose: To verify the Reflection of activity type in Gradebook
# TestCase Id: HSS_PWF_144
Scenario: To verify the Reflection of activity type in Gradebook By SMS Student
When I navigate to "Grades" tab and selected "Grades" subtab
Then I should be on the "Gradebook" page
When I click on the "Test" activity type in filter dropdown
Then I should see the "Test" activity in Gradebook 
