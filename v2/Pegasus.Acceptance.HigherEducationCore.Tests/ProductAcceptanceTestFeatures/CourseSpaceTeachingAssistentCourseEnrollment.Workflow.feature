Feature: CourseSpaceTeachingAssistentCourseEnrollment
	                As a CS Teacher Assistant
					I want to manage all the coursespace Teacher Assistant course enrollment related usecases 
					so that I would validate all the coursespace Teacher Assistant scenarios are working fine.


#Used Instructor Course
#Purpose: To verify behavior and usage of the global link-Home for TA Instructor
# TestCase Id: HSS_Core_PWF_042
Scenario: Allowing the instructor to know the behavior and usage of the global links Home By TA Instructor
When I navigate to "Assignment Calendar" tab of the "Calendar" page
Then I should be on the "Calendar" page
When I click the "Home" link in global homepage
Then I should be on the "Global Home" page
When I click the "HelpInTA" link in global homepage
Then I should be on the "Home Page Help" page
And I should see the 'Welcome' link text
When I close the "Home Page Help" window