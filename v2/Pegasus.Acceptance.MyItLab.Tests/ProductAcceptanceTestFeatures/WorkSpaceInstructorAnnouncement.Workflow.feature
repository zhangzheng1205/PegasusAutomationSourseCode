Feature: WorkSpaceInstructorAnnouncement
					As a Ws Instructor 
					I want to manage all the workspace Instructor related usecases 
					so that I would validate all the workspace Instructor scenarios are working fine.

#Purpose: To check the Default view displayed for Workspace Instructor
#TestCase Id: HED_MIL_PWF_035
#GlobalHomePage
Scenario: To check the Default view displayed By Ws Instructor 
Then I should see the "MyItLabSIM5MasterCourse" mycourse in global home
And I shold the 'Manage All' buuton in announcement channel

#Purpose: To check the Course Announcements in Filter functionality in the Announcement Light box
#TestCase Id: HED_MIL_PWF_041
#GlobalHomePage
Scenario: To check the Course Announcements in Filter functionality in the Announcement By Ws Instructor 
When I changed the WS User Time Zone to Indian GMT in MyProfile
And I create "WsCourse" course Announcement
Then I should see the successfull message "Announcement created successfully." in Announcements Frame
And I should see the displayed dropdown options
| ExpectedResult				| ActualResult          |
| All Announcements				| All Announcements     |
| System Announcements 		    | System Announcements  |
| Course Announcements			| Course Announcements  |
When I click the "Course Announcements" View By dropdown
Then I should see the details of  "WsCourse" Announcement in Announcement Frame
