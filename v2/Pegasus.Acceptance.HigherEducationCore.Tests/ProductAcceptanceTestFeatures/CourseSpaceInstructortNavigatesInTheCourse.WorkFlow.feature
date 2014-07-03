Feature: CourseSpaceInstructortNavigatesInTheCourse
					As a CS Instructor 
					I want to manage all the coursespace instructor related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To verify behavior and usage of the global link - Support for SMS Instructor
# TestCase Id: HSS_Core_PWF_046 | Story Id: PEGASUS-3330
Scenario: To Verify Behavior And Usage Of The Global Link Support By SMS Instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Calendar" page
When I click the 'Support' link by "CsSmsInstructor" in global homepage 
Then I should see the user name of "CsSmsInstructor" in popup
And I "Sign out" from the "CsSmsInstructor"

#Purpose: To verify the user promoted as Teaching Assistent By SMS Instructor
# TestCase Id: HSS_Core_PWF_046 | Story Id: PEGASUS-3330
Scenario: User Promoted As Teaching Assistent By SMS Instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Calendar" page
When I navigate to the "Enrollments" tab
And I select the "CsSmsStudent" as promoted "HedTeacherAssistant" in SMS Instructor
Then I should see the role as "Teaching Assistant"
And I "Sign out" from the "CsSmsInstructor"

