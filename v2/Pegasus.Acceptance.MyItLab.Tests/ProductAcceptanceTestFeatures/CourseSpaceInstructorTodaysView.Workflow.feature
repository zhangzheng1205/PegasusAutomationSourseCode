Feature: CourseSpaceInstructorTodaysView
					As a CS Instructor 
					I want to manage all the Coursespace Instructor Today's View related usecases 
					so that I would validate all the coursespace instructor Today's View related scenarios are working fine.

#Purpose : To verify the functionality of alert listed in New Grades channel when logs out and login again to the course
#Test Case Id : HED_MIL_PWF_590
#MyItLabInstructorCourse
Scenario: To verify the functionality of alert listed in New Grades By SMS Instructor
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
And I should successfully see the alert for New Grades
When I click New Grades alert option

#Purpose : To Create Test With Basic Random Activity
#Test Case Id : HED_MIL_PWF_424
#MyItLabInstructorCourse
Scenario: To Create Test with Basic Random Activity By SMS Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Test" activity type
Then I should be on the "Create activity" page
When I create "Test" type activity of behavioral mode 'BasicRandom'
Then I should see the successfull message "Activity added successfully."

#Purpose : To Create Homework with Basic Random Activity
#Test Case Id : HED_MIL_PWF_434
#MyItLabInstructorCourse
Scenario: To Create Homework with Basic Random Activity By SMS Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "HomeWork" type activity of behavioral mode 'BasicRandom'
Then I should see the successfull message "Activity added successfully."

#Purpose : To Set Feedback Preference for Homework with Basic Random Activity
#Test Case Id : HED_MIL_PWF_495
#MyItLabInstructorCourse
Scenario: To Set Feedback Preference for Homework with Basic Random Activity By SMS Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see "HomeWork" activity in the Content Library Frame
When I click on "Edit" cmenu option of activity in "CsSmsInstructor"
And I set the feedback preference
Then I should see the successfull message "Activity updated successfully."

#Purpose : To Create Quiz with Manual Gradable Activity
#Test Case Id : HED_MIL_PWF_509
#MyItLabInstructorCourse
Scenario: To Create Quiz with Manual Gradable Activity By SMS Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Quiz" activity type
Then I should be on the "Create activity" page
When I create "Quiz" activity of behavioral mode "BasicRandom" type using Essay question
Then I should see the successfull message "Activity added successfully."

#Purpose : As a instructor i should be notified with alert counts and student details in Idle students Channel, when students have not accessed course.
#Test case ID : peg-16740.
#Products : MyItLab, HSS and World Languages.
#Pre condition : Student should have not accessed course.
#Dependency : One time dependent(This scenario can be run against existing data).
Scenario: Instructor views Alert update in idle students channel of Todays View page
When I navigate to "Today's View" tab
Then I should see the "Notifications" channels in 'Todays view' page
And I should see the alert count updated as "1" in "Idle Students" channel
When I click on the "Idle Students" option
Then I should see "1" Idle Student "CsSmsStudent" of type "IdleScore" in "Idle Students" channel

#Purpose : To validate display of alert counts and contents in Not Passed alert channel
#Test case ID : peg-16736
#Products : MyItLab, World Languages
#Pre condition : Student should not meet the threshold of the activity
#Dependency : One time dependent(This scenario can be run against existing data)
Scenario: Instructor views Alert update in Not Passed channel of Todays View page for Activity
When I navigate to "Today's View" tab
Then I should see the "Notifications" channels in 'Todays view' page
And I should see the alert count updated as "8" in "Not Passed" channel
When I click on the "Not Passed" option
Then I should see "8" activity in the "Not Passed" channel

#Purpose : As a instructor i should be notified with alert counts and contents when student does not submits Past due activity.
#Test case ID : peg-16742.
#Products : MyItLab, World Languages.
#Pre condition : Assigned activity should be past due and student should not submit the activity even after past due date.
#Dependency : One time dependent(This scenario can be run against existing data).
Scenario: Instructor views Alert update in Past Due Not Submitted channel
When I navigate to "Today's View" tab
Then I should see the "Notifications" channels in 'Todays view' page
And I should see the alert count updated as "0" in "Past Due: Not Submitted" channel
When I click on the "Past Due: Not Submitted" option
Then I should see "0" activity in the Past Due: Not Submitted channel

#Purpose : As a instructor i should see the calculation done for the submited activity in "Student Performance".
#Test case ID : peg-16750.
#Products : MyItLab, World Languages and HSS.
#Pre condition : Student should submit the actvity and GTD/WM job should run.
#Dependency : One time dependent(This scenario can be run against existing data).
Scenario: Instructor validates grade display in Student performance channel
When I navigate to "Today's View" tab
Then I should see the "Notifications" channels in 'Todays view' page
When I click on the "Student Performance" option
Then I should see "50%" as overall Grade in "Student Performance" alert channel

#Purpose : As a instructor i should be notified with alert counts and contents when student submits Past due activity
#Test case ID : peg-16762.
#Products : MyItLab, World Languages and HSS.
#Pre condition : Student should submit the assigned activities post due date.
#Dependency : One time dependent(This scenario can be run against existing data).
Scenario: Instructor views Alert update in Past Due Submitted channel
When I navigate to "Today's View" tab
Then I should see the "Notifications" channels in 'Todays view' page
And I should see the alert count updated as "4" in "Past Due: Submitted" channel
When I click on the "Past Due: Submitted" option
Then I should see the First, Last name in Past Due: Submitted channel
When I click on the expand icon of student
Then I should see the activity name "Exam [Skill-Based]: Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page

#Purpose : Instructor accepts past due submission from Past due: Submitted channel.
#Test case ID : peg-21949.
#Products : MyItLab, HSS and World Language.
#Pre condition : Assigned activity should be past due and student should not submit the activity even after past due date.
#Dependency : Instructor should assign activity with due date and Student should submit the activity post due date.
Scenario: Instructor accepts past due submission from past due submitted channel of activity
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on the "Past Due: Submitted" option
Then I should see the First, Last name in Past Due: Submitted channel
When I click on the expand icon of student
Then I should see "Exam [Skill-Based]: Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity name and due date and time and submitted date and time which is submitted post due date
When I selected the check box of the "Exam [Skill-Based]: Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" past due activity submitted
And I click on "Accept" activities past due date
Then I should see the 'Accept' success message
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page

#Test case ID : peg-21953.
#Products : MyItLab, HSS and World Language.
#Pre condition : Assigned activity should be past due and student should not submit the activity even after past due date.
#Dependency : Instructor should assign activity with due date and Student should submit the activity post due date.
Scenario: Instructor decline past due submission from past due submitted channel of activity
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on the "Past Due: Submitted" option
Then I should see the First, Last name in Past Due: Submitted channel
When I click on the expand icon of student
Then I should see "Training [Skill-Based]: PowerPoint Chapter 1 Skill-Based Training" activity name and due date and time and submitted date and time which is submitted post due date
When I selected the check box of the "Training [Skill-Based]: PowerPoint Chapter 1 Skill-Based Training" past due activity submitted
When I click on "Decline" activities past due date
Then I should see the 'Decline' success message

#Test case ID : peg-16749.
#Products : MyItLab, HSS and World Language.
#Pre condition : 1. Student should submit the activity. 2. GTD Job should be run(Frequency is every 2 Hour).
#Dependency : Instructor should assign activity and Student should submit the activity.
Scenario: Display of activities and update of Grades in Course Performance channel
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on the "Course Performance" link in notifications channel
And I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "TodaysView" by "CsSmsInstructor"
Then I should see the "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" having "Grade" as "50%"
And I should see the "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" having "Content Completed" as "66.67%"

#-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Home Link functionality inside the course
#Pre condition : Instructor should be navigated inside the course
Scenario: Instructor validate navigate Home link functionality in course header
When I click on "Home" option in "Today's View" tab of "MyItLabInstructorCourse" as "CsSmsInstructor" user
Then I should be on the "Global Home" page

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Help Link functionality on the home page
Scenario: Instructor validate navigate Help link functionality in course header
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on "Help" option in "Today's View" tab of "MyItLabInstructorCourse" as "CsSmsInstructor" user
Then I should be on "MyTest Testbank Help" page as "CsSmsInstructor" user


#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Support Link functionality on the home page
Scenario: Instructor validate Support link functionality in course header
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on "Support" option in "Today's View" tab of "MyItLabInstructorCourse" as "CsSmsInstructor" user
Then I should be on "Pearson Education Customer Technical Support" page as "CsSmsInstructor" user

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The My Profile Link functionality on the home page
Scenario: Instructor validate  My Profile link functionality in course header
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on "My Profile" option in "Today's View" tab of "MyItLabInstructorCourse" as "CsSmsInstructor" user
Then I should be displayed with "My Profile" lightbox

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The User name and Welcome message displayed on the home page
Scenario: Validate user name and welcome message in header
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
And I should be displayed with "Hi," message for "CsSmsInstructor" user

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Privacy link functionality displayed on the home page
Scenario: Instructor validate Privacy link functionality in course header
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on "Privacy" option in "Today's View" tab of "MyItLabInstructorCourse" as "CsSmsInstructor" user
Then I should be on the "Privacy" page
And I close the "Privacy" window


#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The Signout link functionality displayed on the home page
Scenario: Instructor validate  Sign out link functionality in course header
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on "Sign out" option in "Today's View" tab of "MyItLabInstructorCourse" as "CsSmsInstructor" user
Then I should see the successfull message "You have been signed out of the application."

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The course title and ID displayed in the course header
Scenario: Verify the course title and ID display in the course header
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
And I should be displayed with "MyItLabInstructorCourse" course information for "CsSmsInstructor" user

#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The functionality of Prefernece option in the course header
Scenario: Verify the display and functionaly to "Preference" option in course header
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
And I should be displayed with "Preferences" option
When I click on "Preferences" option
Then I should be on the "Preferences" page


#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Purpose:Verify The functionality of 'Go To Student  option in the course header
Scenario: Verify the display and functionaly to "Go to Student View" option in course header
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
And I should be displayed with "Go to Student View" option
When I click on "Go to Student View" option
Then I should be displayed with "Return to Instructor View" option
When I click on "Return to Instructor View" option
Then I should be on the "Today's View" page
And I should be displayed with "Go to Student View" option


#Purpose:Validate the display of Notifications channels dispalyed in Today's view tab of CsSmsInstructor.
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre condition : Notification channel should be added by the Instructor in Today's view tab.
Scenario: Display of Notifications channel in Today's View page of Instructor
When I navigate to "Today's View" tab
Then I should be displayed with "Notifications" channel  on "Today's View" page as "CsSmsInstructor" user 

#Purpose:Validate the display of Announcements channels dispalyed in Today's view tab of CsSmsInstructor.
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre condition : Announcements channel should be added by the Instructor in Today's view tab.
Scenario: Display of Announcements channel in Today's View page of Instructor
When I navigate to "Today's View" tab
Then I should be displayed with "Announcements" channel  on "Today's View" page as "CsSmsInstructor" user 

#Purpose:Validate the display of Calendar channels dispalyed in Today's view tab of CsSmsStudent.
#Test case ID : 
#Products : MyItLab, HSS and World Language.
#Pre condition : Calendar channel should be added by the Instructor in Today's view tab
Scenario: Display of Calendar channel in Today's View page of Instructor
When I navigate to "Today's View" tab
Then I should be displayed with "Calendar" channel  on "Today's View" page as "CsSmsInstructor" user 

#Purpose:Validate the functionality of Maximizing and minimizing Notifications channel in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Minmize and Minmize Notifications  channel in Today's View page of Instructor
When I "Minimize" the "Notifications" channel on "Today's View" tab as "CsSmsInstructor"
Then I should be displayed with "Maximize" icon in "Notifications" channel of "Today's View" page 
When I "Maximize" the "Notifications" channel on "Today's View" tab as "CsSmsInstructor"
Then I should be displayed with "Minmize" icon in "Notifications" channel of "Today's View" page 

#Purpose:Validate the functionality of Moving Announcements channel in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Move Announcements channel in Today's View page of Instructor
When I "Move Up" the "Announcements" channel on "Today's View" tab as "CsSmsInstructor"
Then I should be displayed with "Move Down" icon in "Announcements" channel of "Today's View" page 
When I "Move Down" the "Announcements" channel on "Today's View" tab as "CsSmsInstructor"
Then I should be displayed with "Move Up" icon in "Announcements" channel of "Today's View" page 

#Purpose:Validate the functionality of Maximizing and minimizing Notifications channel in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Minmize and Minmize Announcements channel in Today's View page of Instructor
When I "Minimize" the "Announcements" channel on "Today's View" tab as "CsSmsInstructor"
Then I should be displayed with "Maximize" icon in "Announcements" channel of "Today's View" page 
When I "Maximize" the "Announcements" channel on "Today's View" tab as "CsSmsInstructor"
Then I should be displayed with "Minmize" icon in "Announcements" channel of "Today's View" page

#Purpose:Validate the functionality of Moving Calendar channel in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Move Calendar channel in Today's View page of Instructor
When I "Move Down" the "Calendar" channel on "Today's View" tab as "CsSmsInstructor"
Then I should be displayed with "Move Down" icon in "Calendar" channel of "Today's View" page 
When I "Move Up" the "Calendar" channel on "Today's View" tab as "CsSmsInstructor"
Then I should be displayed with "Move Up" icon in "Calendar" channel of "Today's View" page 
 
#Purpose:Validate the functionality of Maximizing and minimizing Calendar channel in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Minmize and Minmize Calendar channel in Today's View page of Instructor
When I "Minimize" the "Calendar" channel on "Today's View" tab as "CsSmsInstructor"
Then I should be displayed with "Maximize" icon in "Calendar" channel of "Today's View" page 
When I "Maximize" the "Calendar" channel on "Today's View" tab as "CsSmsInstructor"
Then I should be displayed with "Minmize" icon in "Calendar" channel of "Today's View" page


Scenario: Todays view subchannel validation of notification channel
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
And I navigate to "Today's View" tab
Then I should see "About This Course" in "Notifications" channel
Then I should see "Welcome Message" in "Notifications" channel
Then I should see "Alerts" in "Notifications" channel
Then I should see "Action Items" in "Notifications" channel
Then I should see "Performance" in "Notifications" channel

Scenario: Validate About This Course channel display
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
And I navigate to "Today's View" tab
Then I should see "About This Course" in "Notifications" channel
When I expand "About This Course" channel
Then I should be displayed with "You and your students can view this message. To create or edit this message, click Customize." message


Scenario: Validate Welcome Message channel display
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
And I navigate to "Today's View" tab
Then I should see "Welcome Message" in "Notifications" channel
When I expand "Welcome Message" channel
Then I should be displayed with "RegTVInsWelcomeMsg" welcome message


Scenario: Validate NotPassedAlertCount in Alert channel
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
And I navigate to "Today's View" tab
Then I should see "Alerts" in "Notifications" channel
When I expand "Alerts" channel
Then I should be displayed with "RegNotPassedAlertCount" count
Then I should be displayed with "RegNewGradesAlertCount" count
Then I should be displayed with "RegIdleStudentCount" count
Then I should be displayed with "RegPastDueSubmittedCount" count
Then I should be displayed with "RegPastDueNotSubmittedCount" count
Then I should be displayed with "RegUnreadCommentsCount" count
Then I should be displayed with "RegAlertsCount" count

Scenario: Validate IdleStudentCount and display of Idle Student
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
And I navigate to "Today's View" tab
Then I should see "Alerts" in "Notifications" channel
When I expand "Alerts" channel
Then I should be displayed with "RegIdleStudentCount" count
When I click on "Idle Students" alert option
Then I should see 'Zero' "CsSmsStudent"
And I should be displayed with the "Students listed here have not entered the course" message 

