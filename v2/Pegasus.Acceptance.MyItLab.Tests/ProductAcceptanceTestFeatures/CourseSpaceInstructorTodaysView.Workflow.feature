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
Then I should see "1" Idle Student "Stud , Mail" in "Idle Students" channel

#Purpose : To validate display of alert counts and contents in Not Passed alert channel
#Test case ID : peg-16736
#Products : MyItLab, World Languages
#Pre condition : Student should not meet the threshold of the activity
#Dependency : One time dependent(This scenario can be run against existing data)
Scenario: Instructor views Alert update in Not Passed channel of Todays View page for Activity
When I navigate to "Today's View" tab
Then I should see the "Notifications" channels in 'Todays view' page
And I should see the alert count updated as "1" in "Not Passed" channel
When I click on the "Not Passed" option
Then I should see "1" activity in the "Not Passed" channel

#Purpose : As a instructor i should be notified with alert counts and contents when student does not submits Past due activity.
#Test case ID : peg-16742.
#Products : MyItLab, World Languages.
#Pre condition : Assigned activity should be past due and student should not submit the activity even after past due date.
#Dependency : One time dependent(This scenario can be run against existing data).
Scenario: Instructor views Alert update in Past Due Not Submitted channel
When I navigate to "Today's View" tab
Then I should see the "Notifications" channels in 'Todays view' page
And I should see the alert count updated as "69" in "Past Due: Not Submitted" channel
When I click on the "Past Due: Not Submitted" option
Then I should see "69" activity in the Past Due: Not Submitted channel

#Purpose : As a instructor i should see the calculation done for the submited activity in "Student Performance".
#Test case ID : peg-16750.
#Products : MyItLab, World Languages and HSS.
#Pre condition : Student should submit the actvity and GTD/WM job should run.
#Dependency : One time dependent(This scenario can be run against existing data).
Scenario: Instructor validates grade display in Student performance channel
When I navigate to "Today's View" tab
Then I should see the "Notifications" channels in 'Todays view' page
When I click on the "Student Performance" option
Then I should see "6.57%" as overall Grade in "Student Performance" alert channel

#Purpose : As a instructor i should be notified with alert counts and contents when student submits Past due activity
#Test case ID : peg-16762.
#Products : MyItLab, World Languages and HSS.
#Pre condition : Student should submit the assigned activities post due date.
#Dependency : One time dependent(This scenario can be run against existing data).
Scenario: Instructor views Alert update in Past Due Submitted channel
When I navigate to "Today's View" tab
Then I should see the "Notifications" channels in 'Todays view' page
And I should see the alert count updated as "1" in "Past Due: Submitted" channel
When I click on the "Past Due: Submitted" option
Then I should see student First, Last name "ln, fn" in Past Due: Submitted channel
When I click on the expand icon of student
Then I should see the activity name "Training [Skill-Based]: Word Chapter 1 Skill-Based Training"

#Purpose : Instructor accepts past due submission from Past due: Submitted channel.
#Test case ID : peg-21949.
#Products : MyItLab, HSS and World Language.
#Pre condition : Assigned activity should be past due and student should not submit the activity even after past due date.
#Dependency : Instructor should assign activity with due date and Student should submit the activity post due date.
Scenario: Instructor accepts past due submission from past due submitted channel of activity
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on the "Past Due: Submitted" link in notifications channel
Then I should see First name, Last name of "CsSmsStudent" who has submitted the past due activity in the right frame along with expand icon
When I click on expand icon displayed against student name
And I selected the check box of the past due activity submitted
Then I should see "CsSmsStudent" name and "Training [Skill-Based]: Excel Chapter 1 Skill-Based Training" activity name and due date and time and submitted date and time which is submitted post due date
And I should be able to select the past due activity
When I click on "Accept" activities past due date
Then I should see the successfull message "All of the late submissions have been accepted. The grades for these submissions will now appear in the Gradebook."

#Test case ID : peg-21953.
#Products : MyItLab, HSS and World Language.
#Pre condition : Assigned activity should be past due and student should not submit the activity even after past due date.
#Dependency : Instructor should assign activity with due date and Student should submit the activity post due date.
Scenario: Instructor decline past due submission from past due submitted channel of activity
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on the "Past Due: Submitted" link in notifications channel
Then I should see First name, Last name of "CsSmsStudent" who has submitted the past due activity in the right frame along with expand icon
When I click on expand icon displayed against student name
And I selected the check box of the past due activity submitted
Then I should see "CsSmsStudent" name and "Training [Skill-Based]: Excel Chapter 1 Skill-Based Training" activity name and due date and time and submitted date and time which is submitted post due date
And I should be able to select the past due activity
When I click on "Accept" activities past due date
Then I should see the successfull message "All of the late submissions have been declined. These submissions will receive a zero in the Gradebook."