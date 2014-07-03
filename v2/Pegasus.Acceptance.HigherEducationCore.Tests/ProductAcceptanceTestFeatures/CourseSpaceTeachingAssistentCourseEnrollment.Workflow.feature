Feature: CourseSpaceTeachingAssistentCourseEnrollment
	                As a CS Teacher Assistant
					I want to manage all the coursespace Teacher Assistant course enrollment related usecases 
					so that I would validate all the coursespace Teacher Assistant scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "HedTeacherAssistant"
When I logged into the Pegasus as "HedTeacherAssistant" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To verify behavior and usage of the global link-Home for TA Instructor
# TestCase Id: HSS_Core_PWF_042
Scenario: Allowing the instructor to know the behavior and usage of the global links Home By TA Instructor
When I enter in the "InstructorCourse" from the Global Home page as "HedTeacherAssistant"
Then I should be on the "Calendar" page
When I click the "Home" link in global homepage
Then I should be on the "Global Home" page
When I click the "HelpInTA" link in global homepage
Then I should be on the "Home Page Help" page
And I should see the 'Welcome' link text
When I close the "Home Page Help" window
And I "Sign out" from the "HedTeacherAssistant"
Then I should see the successfull message "You have been signed out of the application."
