Feature: CourseSpaceAssignsContent
                    As a CS Instructor 
					I want to manage all the coursespace assign content usecases 
					so that I would validate all the assign content scenarios are working fine.

#Purpose: To drag and drop a folder in assignment calendar.
#Test case ID : peg-21948.
#PEGASUS-28902
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Instructor drag and drop a folder in assignment calendar by Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "Chapter 1: The Science of Psychology" asset
And I should see the current date highlighted in the calendar frame
When I drag and drop the "Chapter 1: The Science of Psychology" folder to the current date
Then I should see due date icon displayed in current date
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : To validate Assign more than one content using Assign/Unassign link
#Test Case Id :peg-21979 -Assign more than one content using Assign/Unassign link
#PEGASUS-28905
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Assign more than one content using Assign Unassign link by Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "Take the Chapter 2 Exam" in "Calendar" by "HSSCsSmsInstructor"
And I select the check box of any 2 activities in "Chapter 2: The Biological Perspective"
Then I should see Assign/Unassign link in active state on the content frame header
When I click on assign/Unassign link displayed in content frame header
Then I should see the check mark in assigned status column next to the assets
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page


#Purpose : To validate Assign one content using Assign/Unassign link
#Test Case Id :peg-21971 -Assign one content using Assign/Unassign link
#PEGASUS-28903
#Test case ID :peg-21971 
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Assign one content using Assign Unassign link by Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "Take the Chapter 3 Exam" in "Calendar" by "HSSCsSmsInstructor"
And I select the check box of any 1 activities in "Chapter 3: Sensation and Perception"
Then I should see Assign/Unassign link in active state on the content frame header
When I click on assign/Unassign link displayed in content frame header
Then I should see the check mark in assigned status column next to the assets
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose: To drag and drop multiple assets in assignment calendar.
#Test case ID : peg-21981.
#PEGASUS-28906
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Drag and drop the more than one assets to current date in Assignment calendar
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see the current date highlighted in the calendar frame
When I select "Review the Chapter 5 Learning Objectives" in "Calendar" by "HSSCsSmsInstructor"
And I select the check box of any 2 activities in "Chapter 5: Learning"
And I should drag and drop multiple assets along with "Review the Chapter 5 Learning Objectives" to the current date
Then I should see due date icon displayed in current date
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page


#Purpose: To validate the current date assigned content in calendar frame by Coursespace Instructor
#Test Case Id: peg-21985
#PEGASUS-28907
Scenario: To check the current date assigned content in the calendar by Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "Chapter 1: The Science of Psychology" asset
And I should see the current date highlighted in the calendar frame
When I select the current date 
Then I should see the assigned content "Complete the Chapter 1 Study Plan" in the day view
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose: Assign a content to display start date icon
#PEGASUS-29283
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: To validate the display of start date icon in calendar frame by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "Read the eText: Chapter 5" in "Calendar" by "HSSCsSmsInstructor"
And I select cmenu "Assignment Properties" of activity "Read the eText: Chapter 5" 
Then I should see the "Assign" popup
When I assign the asset for current date in the properties popup
Then I should be on the "Calendar" page
And I should see the current date highlighted in the calendar frame
And I should see the startdate Icon in calendar frame
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page

#Purpose :Instructor assign the asset with duedate in Managecoursework
#TestCase Id: peg-22221
#PEGASUS-29795
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Instructor assign the asset with duedate in Managecoursework
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I navigate to "Review the Chapter 1 Learning Objectives" asset in "Course Materials" tab as "HSSCsSmsInstructor"
And I click on "Properties" option in c menu of "Review the Chapter 1 Learning Objectives" asset
Then I should be on the "Properties" page
When I assign asset with due date and save
Then I should see the successfull message "Properties updated successfully."
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page


#Purpose: To assign the content to currentdate
#MyPsychLab for Ciccarelli, Psychology, 3/e
#PEGASUS-29796
#peg-22220
Scenario: Instructor assign the content with assign the content with due date ,startdate and endate
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I navigate to "Read the eText: Chapter 1" asset in "Course Materials" tab as "HSSCsSmsInstructor"
And I click on "Properties" option in c menu of "Read the eText: Chapter 1" asset
Then I should be on the "Properties" page
When I assign and schedule the asset and save
Then I should see the successfull message "Properties updated successfully."
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page






 



