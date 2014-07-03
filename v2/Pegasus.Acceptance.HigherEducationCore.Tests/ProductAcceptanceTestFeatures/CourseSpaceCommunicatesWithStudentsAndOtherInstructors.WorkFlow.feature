#Purpose: Feature Description
Feature: CourseSpaceCommunicatesWithStudentsAndOtherInstructors
	                As a CsInstructor 
					I want to manage all the Usecases related to Communication With Students And Other Instructors
					so that I would validate all the Instructor related usecases for Communication With Students And Other Instructors.

#Purpose: Open CS Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully

#Purpose : View the System Announcement by CsSmsInstructor
Scenario: View System Announcement by CsSmsInstructor
Given I am on the "Global Home" page
When I change the Time Zone to Indian GMT in MyProfile by "CsSmsInstructor"
And  I select "System Announcements" in 'View by' drop down
Then I should see the details of "CsSystem" Announcement in Announcement Light box


#Purpose: To Create and Verify Course Announcement by SMS Instructor
Scenario: Create and verify Course Announcement by SMS Instructor 
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
And I navigate to the "Today's View" tab
Then I should be on the "Today's View" page
When I create "CsCourse" Announcement
Then I should see the successfull message "Announcement created successfully." in Announcements Frame
When I select "Course Announcements" in 'View by' drop down  
Then I should see the details of "CsCourse" Announcement in Announcement Light box

