Feature: CourseSpaceTeachingAssistantCourseCopy
					As a CS Teacher Assistant
					I want to manage all the coursespace Teacher Assistant Course Copy related usecases 
					so that I would validate all the coursespace Teacher Assistant Course Copy scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "HedTeacherAssistant"
When I logged into the Pegasus as "HedTeacherAssistant" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To check the functionality of Removing channels from Today's view and checking with  move up and move down functionality
# TestCase Id: HSS_PWF_057_03
Scenario: Performance Enhancements in TodaysView for Instructor By TA Instructor
When I enter in the "InstructorCourse" from the Global Home page as "HedTeacherAssistant"
Then I should be on the "Calendar" page
When I navigate to the "Today's View" tab
And I click on "Move Down" option of calendar course channel
Then I should see the "Announcements" channel in first position
When I click on the "Move Up" option of calendar course channel
Then I should see the "Calendar" channel in first position
When I remove the Calendar channel from course channel
Then I should not see the "Calendar" channel
When I "Sign out" from the "HedTeacherAssistant"
Then I should see the successfull message "You have been signed out of the application."
