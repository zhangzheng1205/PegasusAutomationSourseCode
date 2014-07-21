Feature: CourseSpaceInstructorCourseCopy
	                As a CS Instructor 
					I want to manage all the coursespace instructor Course Copy related usecases 
					so that I would validate all the coursespace instructor Course Copy scenarios are working fine.

#Used Instructor Course
#Purpose: To check the functionality of Removing channels from Today's view and checking with  move up and move down functionality
# TestCase Id: HSS_PWF_057_03
Scenario: Performance Enhancements in TodaysView for Instructor by SMS Instructor
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I navigate to the "Course Channels" tab in Preferences Page
Then I should be on the "Preferences" page
When I enable the 'Instructors can customize their Home Page' option
Then I should see the successfull message "Preferences updated successfully."
When I navigate to the "Today's View" tab
And I click on "Move Down" option of calendar course channel
Then I should see the "Announcements" channel in first position
When I click on the "Move Up" option of calendar course channel
Then I should see the "Calendar" channel in first position
When I remove the Calendar channel from course channel
Then I should not see the "Calendar" channel