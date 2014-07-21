Feature: CourseSpaceInstructortNavigatesInTheCourse
					As a CS Instructor 
					I want to manage all the coursespace instructor related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.

#Used Instructor Course
#Purpose: To verify behavior and usage of the global link - Support for SMS Instructor
# TestCase Id: HSS_Core_PWF_046 | Story Id: PEGASUS-3330
Scenario: To Verify Behavior And Usage Of The Global Link Support By SMS Instructor
When I navigate to "Assignment Calendar" tab of the "Calendar" page
Then I should be on the "Calendar" page
When I click the 'Support' link by "CsSmsInstructor" in global homepage 
Then I should see the user name of "CsSmsInstructor" in popup

#Used Instructor Course
#Purpose: To verify the user promoted as Teaching Assistent By SMS Instructor
# TestCase Id: HSS_Core_PWF_046 | Story Id: PEGASUS-3330
Scenario: User Promoted As Teaching Assistent By SMS Instructor
When I navigate to "Enrollments" tab and selected "Manage Roster" subtab
Then I should be on the "Roster" page
When I select the "CsSmsStudent" as promoted "HedTeacherAssistant" in SMS Instructor
Then I should see the role as "Teaching Assistant"

