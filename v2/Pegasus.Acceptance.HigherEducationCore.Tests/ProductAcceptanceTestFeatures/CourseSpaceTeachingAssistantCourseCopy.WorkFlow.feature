Feature: CourseSpaceTeachingAssistantCourseCopy
					As a CS Teacher Assistant
					I want to manage all the coursespace Teacher Assistant Course Copy related usecases 
					so that I would validate all the coursespace Teacher Assistant Course Copy scenarios are working fine.

#Used Instructor Course
#Purpose: To check the functionality of Removing channels from Today's view and checking with  move up and move down functionality
# TestCase Id: HSS_PWF_057_03
Scenario: Performance Enhancements in TodaysView for Instructor By TA Instructor
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
When I click on "Move Down" option of calendar course channel
Then I should see the "Announcements" channel in first position
When I click on the "Move Up" option of calendar course channel
Then I should see the "Calendar" channel in first position
When I remove the Calendar channel from course channel
Then I should not see the "Calendar" channel
