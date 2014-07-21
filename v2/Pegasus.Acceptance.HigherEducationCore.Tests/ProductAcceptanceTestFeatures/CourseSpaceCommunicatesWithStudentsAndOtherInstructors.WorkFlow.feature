#Purpose: Feature Description
Feature: CourseSpaceCommunicatesWithStudentsAndOtherInstructors
	                As a CsInstructor 
					I want to manage all the Usecases related to Communication With Students And Other Instructors
					so that I would validate all the Instructor related usecases for Communication With Students And Other Instructors.

#Verify in global home
#Purpose : View the System Announcement by CsSmsInstructor
Scenario: View System Announcement by CsSmsInstructor
When I change the Time Zone to Indian GMT in MyProfile by "CsSmsInstructor"
And  I select "System Announcements" in 'View by' drop down
Then I should see the details of "CsSystem" Announcement in Announcement Light box

#Verify the usecase in InstructorCourse
#Purpose: To Create and Verify Course Announcement by SMS Instructor
Scenario: Create and verify Course Announcement by SMS Instructor 
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
When I create "CsCourse" Announcement
Then I should see the successfull message "Announcement created successfully." in Announcements Frame
When I select "Course Announcements" in 'View by' drop down  
Then I should see the details of "CsCourse" Announcement in Announcement Light box

