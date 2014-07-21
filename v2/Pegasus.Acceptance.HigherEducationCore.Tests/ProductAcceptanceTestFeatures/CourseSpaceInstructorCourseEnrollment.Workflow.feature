Feature: CourseSpaceInstructorCourseEnrollment
	                As a CS Instructor 
					I want to manage all the coursespace instructor course enrollment related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.

#Used Instructor Course
#Purpose: To verify behavior and usage of the global link-Home for SMS Instructor
# TestCase Id: HSS_Core_PWF_042
Scenario: Allowing the instructor to know the behavior and usage of the global links Home By SMS Instructor
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
When I click the "Home" link in global homepage
Then I should be on the "Global Home" page
When I click the "Help" link in global homepage 
Then I should be on the "Home Page Help" page
And I should see the 'Welcome' link text
When I close the "Home Page Help" window


