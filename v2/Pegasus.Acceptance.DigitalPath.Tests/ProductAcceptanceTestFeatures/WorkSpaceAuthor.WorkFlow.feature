Feature: WorkSpaceAuthor
	                As a WorkSpace Autohor
					I want to manage all the workspace author related usecases 
					so that I would validate all the workspace author scenarios are working fine.


#This Usecase related to "MasterLibrary" course
#Purpose: UseCase To Import MGM Related Questions In Master Course
Scenario: Import MGM Question Cartridge by WS Teacher
Then I should see the defaults tabs for "WsTeacher"
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I import the MGM cartridge
Then I should see the successfull message "The import completed successfully. # links were created."
And I should see "Topic 10 Test" activity in the Content Library Frame

#This Usecase related to "MasterLibrary" course
#Purpose: UseCase To Set MGM Related Preferences In Master Course
Scenario: Set the MGM Course Preferences by WS Teacher
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I set the LTI Tools preferences in the Master Course for MGM
Then I should see the successfull message "Preferences updated successfully."
When I set the 'Allow activity to be used as a pre-test or a post-test' option for MGM Test activities
Then I should see the successfull message "Default Preferences updated successfully"
When I click on the "Standards and Skills" tab
And I set the Standards and Skills preference in the Mastercourse for MGM
Then I should see the successfull message "Preferences updated successfully."

#This Usecase will not enter inside the course
#Purpose: To View System Announcement
@ViewSystemAnnouncementByWsTeacher
Scenario: View System Announcement by WS Teacher
When I changed the WS User Time Zone to Indian GMT in MyProfile
And I click on the "WsSystem" Announcement listed in Announcement Channel
Then I should see the details of  "WsSystem" Announcement in Announcement Frame

#This Usecase will not enter inside the course
#Purpose: To Create Course Announcements
Scenario: Create Course Announcement by WS Teacher
When I create Course Announcement
Then I should see the successfull message "Announcement created successfully." in Announcements Frame

#This Usecase related to "MasterLibrary" course
#Purpose: View Default Home Tabs by WS Teacher
Scenario: View Default Tabs by WS Teacher
Then I should see the defaults tabs for "WsTeacher"

#View Tabs Navigation by WS Teacher
Scenario: View Tabs Navigation by WS Teacher
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate to the "Today's View" tab
Then I should be on the "Today's View" page

#This Usecase related to "MasterLibrary" course
#Purpose: Launch different type of activities by WS Teacher
Scenario: Launch Skill Study Plan Activity by WS Teacher
When I navigate to the "Content" tab
Then I should be on the "Content" page
Then I should see "SkillStudyPlan" activity in the MyCourse Frame
When I click on "Preview" cmenu option of activity in "WsTeacher"
And I preview the PreTest of the Skill Study Plan
Then I should see the SSP Pretest successfully launch by "WsTeacher"

#This Usecase related to "MasterLibrary" course
#Purpose : To Lauch Mgm Activity by the teacher in Ws
Scenario: Launch MGM Test Activity by WS Teacher
When I navigate to the "Content" tab
Then I should be on the "Content" page
Then I should see "Topic 10 Test" activity in the MyCourse
When I click on "Preview" cmenu option of activity in "WsTeacher"
Then I should see the Test activity successfully launched

#This Usecase related to "MasterLibrary" course
#Purpose: UseCase To Create SkillStudyplan
Scenario: Create Skill Study Plan by WS Teacher
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I click on the "Add Skill Study Plan" link
Then I should be on the "Create Skill Study Plan" page
When I create SkillStudyPlan
Then I should see the successfull message "Study Plan added successfully."

#This Usecase related to "MasterLibrary" course
#Purpose: UseCase To Associate Test Type Activity to My Course
Scenario: Associate Test Activity to My Course frame by WS Teacher
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I select the "Topic 10 Test" activity in Course Content
And I Click on the Add button
Then I should see the successfull message "Content item is added to My Course"
And I should see "Test" activity in the MyCourse Frame

#This Usecase related to "MasterLibrary" course
#Purpose: UseCase To Associate SkilSudyPlan to My Course
Scenario: Associate SkilSudyPlan to My Course frame by WS Teacher
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I select the "SkillStudyPlan" activity
And I Click on the Add button
Then I should see the successfull message "Content item is added to My Course"
And I should see "SkillStudyPlan" activity in the MyCourse Frame

#This Usecase related to "MasterLibrary" course
#Purpose : To Create Test With Basic Random Activity
Scenario: To Create Test with Basic Random Activity By WS Instructor
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I click on the 'Add Course Materials' option
And I click on the "Test" activity type
Then I should be on the "Create activity" page
When I create "Test" type activity of behavioral mode 'BasicRandom'
Then I should see the successfull message "Activity added successfully."
When I associate the "Test" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#This Usecase related to "MasterLibrary" course
#Purpose: UseCase To Create Studyplan
Scenario: Create Study Plan by WS Teacher
When I navigate to the "Content" tab
Then I should be on the "Content" page
When I click on the "Add Study Plan" link
Then I should be on the "Create Study Plan" page
When I create the "StudyPlan" asset
Then I should see the successfull message "Study Plan added successfully."
When I associate the "StudyPlan" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"