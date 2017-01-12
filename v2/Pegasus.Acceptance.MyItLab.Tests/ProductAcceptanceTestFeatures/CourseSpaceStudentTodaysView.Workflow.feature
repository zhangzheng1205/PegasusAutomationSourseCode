Feature: CourseSpaceStudent TodaysView
	                As a CS Student 
					I want to manage all the coursespace student todaysview related usecases 
					so that I would validate all the coursespace student todaysview scenarios are working fine.

#Purpose: View submission in today's view
# TestCase Id: HED_MIL_PWF_920
#MyItLabProgramCourse
Scenario: View submission in todays view by SMS Student
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click New Grades alert option
Then I should see the successfully submitted "SIM5Activity" name of behavioral mode "SkillBased"
When I click the cmenu option 'ViewAllSubmissions' in student side
Then I should see the grade "100" in view submission page
When I close the "View Submission" window

#Purpose: To Submit Sim Activity Inside Program Course
# TestCase ID: HED_MIL_PWF_915
#MyItLabProgramCourse
Scenario: Activity Submission Inside Program Course by SMS Student
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I submit the "SIM5Activity" activity of behavioral mode "SkillBased" type
Then I should see "Passed" status of the "SIM5Activity" activity of behavioral mode "SkillBased" type
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
When I click New Grades alert option
Then I should see the successfully submitted "SIM5Activity" name of behavioral mode "SkillBased"
When I click the cmenu option 'ViewAllSubmissions' in student side
Then I should see the grade "100" in view submission page
When I close the "View Submission" window

#Purpose:C-menu option for the assets under performance channel - View submission c-menu
#TestCase ID :HED_MIL_PWF_931
#MyItLabProgramCourse
Scenario: Cmenu option for the assets under performance channel View submission cmenu
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I select 'My Progress' option
And I click on cmenu option of activity "Test"
And I select the cmenu option "View Submission" of the activity
Then I should be on the "View Submission" page
When I close the "View Submission" window

#Purpose : As a student i should see the calculation done for the submited activity in "My Progress" channel of Notifications
#Test case ID : peg-16752.
#Products : MyItLab, World Languages and HSS.
#Pre condition : Student should submit the actvity and GTD/WM job should run.
#Dependency : One time dependent(This scenario can be run against existing data).
Scenario: Student validates grade display in My progress channel
When I navigate to "Today's View" tab
Then I should see the "Notifications" channels in 'Todays view' page
When I click on the "My Progress" option
Then I should see "100%" as overall Grade in "My Progress" alert channel

#Purpose : As a Student i should be notified with alert count in "Unread Discussions" channel when instructor posts reply to Discussion topic
#Test case ID : peg-16746.
#Products : MyItLab.
#Pre condition : Instructor should post response to the Discussion topic.
#Dependency : Always dependent.
Scenario: Student views Alert update in Unread Discussions channel of Todays View page
When I navigate to "Today's View" tab
Then I should see the "Notifications" channels in 'Todays view' page
And I should see the alert count updated as "1" in "Unread Discussion" channel
When I click on the "Unread Discussion" option
Then I should see "1" activity in the "Unread Discussion" channel
When I click on cmenu icon of Discussion topic "Critical Thinking Question: Password Protection"
And I select the cmenu option "Open" of the activity
Then I should see the "Discussion" frame
When I click on cmenu of response "Re:Critical Thinking Question: Password Protection" posted 
And I select the cmenu option "Open" of the response posted
Then I should see the "Discussion: Critical Thinking Question: Password Protection" popup
When I switch to ReadResponse pop up
And I click on the close button in ReadResponse pop up
Then I should see the "Discussion" frame
When I click on cancel button in Discussion Page
Then I should be on the "Today's View" page
#-------------------------------------------------------------------------------------------------


#Purpose:Verify The Home Link functionality inside the course for CsSmsStudent
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre condition : Instructor should be navigated inside the course
Scenario: Student validate navigate Home link functionality in course header
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on "Home" option in "Today's View" tab of "MyItLabInstructorCourse" as "CsSmsStudent" user
Then I should be on the "Global Home" page

#Purpose:Validate the display of Notifications channels dispalyed in Today's view tab of CsSmsStudent.
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre condition : Notification channel should be added by the student in Today's view tab.
Scenario: Display of Notifications channel in Today's View page of Student
When I navigate to "Today's View" tab
Then I should be displayed with "Notifications" channel  on "Today's View" page as "CsSmsStudent" user 

#Purpose:Validate the display of Announcements channels dispalyed in Today's view tab of CsSmsStudent.
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre condition : Announcements channel should be added by the student in Today's view tab.
Scenario: Display of Announcements channel in Today's View page of Student
When I navigate to "Today's View" tab
Then I should be displayed with "Announcements" channel  on "Today's View" page as "CsSmsStudent" user 

#Purpose:Validate the display of Calendar channels dispalyed in Today's view tab of CsSmsStudent.
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre condition : Calendar channel should be added by the student in Today's view tab
Scenario: Display of Calendar channel in Today's View page of Student
When I navigate to "Today's View" tab
Then I should be displayed with "Calendar" channel  on "Today's View" page as "CsSmsStudent" user 

#Purpose:Validate the functionality of Maximizing and minimizing Notifications channel in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Minmize and Minmize Notifications  channel in Today's View page of Student
When I "Minimize" the "Notifications" channel on "Today's View" tab as "CsSmsStudent"
Then I should be displayed with "Maximize" icon in "Notifications" channel of "Today's View" page 
When I "Maximize" the "Notifications" channel on "Today's View" tab as "CsSmsStudent"
Then I should be displayed with "Minmize" icon in "Notifications" channel of "Today's View" page 

#Purpose:Validate the functionality of Moving Announcements channel in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Move Announcements channel in Today's View page of Student
When I "Move Up" the "Announcements" channel on "Today's View" tab as "CsSmsStudent"
Then I should be displayed with "Move Down" icon in "Announcements" channel of "Today's View" page 
When I "Move Down" the "Announcements" channel on "Today's View" tab as "CsSmsStudent"
Then I should be displayed with "Move Up" icon in "Announcements" channel of "Today's View" page 

#Purpose:Validate the functionality of Maximizing and minimizing Notifications channel in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Minmize and Minmize Announcements channel in Today's View page of Student
When I "Minimize" the "Announcements" channel on "Today's View" tab as "CsSmsStudent"
Then I should be displayed with "Maximize" icon in "Announcements" channel of "Today's View" page 
When I "Maximize" the "Announcements" channel on "Today's View" tab as "CsSmsStudent"
Then I should be displayed with "Minmize" icon in "Announcements" channel of "Today's View" page

#Purpose:Validate the functionality of Moving Calendar channel in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Move Calendar channel in Today's View page of Student
When I "Move Down" the "Calendar" channel on "Today's View" tab as "CsSmsStudent"
Then I should be displayed with "Move Down" icon in "Calendar" channel of "Today's View" page 
When I "Move Up" the "Calendar" channel on "Today's View" tab as "CsSmsStudent"
Then I should be displayed with "Move Up" icon in "Calendar" channel of "Today's View" page 
 
#Purpose:Validate the functionality of Maximizing and minimizing Calendar channel in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Minmize and Minmize Calendar channel in Today's View page of Student
When I "Minimize" the "Calendar" channel on "Today's View" tab as "CsSmsStudent"
Then I should be displayed with "Maximize" icon in "Calendar" channel of "Today's View" page 
When I "Maximize" the "Calendar" channel on "Today's View" tab as "CsSmsStudent"
Then I should be displayed with "Minmize" icon in "Calendar" channel of "Today's View" page

