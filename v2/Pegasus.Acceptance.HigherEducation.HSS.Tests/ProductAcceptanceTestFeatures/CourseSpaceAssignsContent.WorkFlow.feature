Feature: CourseSpaceAssignsContent
                    As a CS Instructor 
					I want to manage all the coursespace assign content usecases 
					so that I would validate all the assign content scenarios are working fine.

#Purpose: To drag and drop a folder in assignment calendar.
#Test case ID : peg-21948.
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Instructor drag and drop a folder in assignment calendar by Instructor
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsInstructor"
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "Chapter 1: The Science of Psychology" asset
And I should see the current date highlighted in the calendar frame
When I drag and drop the "Chapter 1: The Science of Psychology" folder to the current date
Then I should see due date icon displayed in current date

#Purpose : To validate Assign more than one content using Assign/Unassign link
#Test Case Id :peg-21979 -Assign more than one content using Assign/Unassign link
#PEGASUS-28905
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Assign more than one content using Assign Unassign link by Instructor
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsInstructor"
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "Take the Chapter 2 Exam" in "Calendar" by "HSSCsSmsInstructor"
And I select the check box of any 2 activities in "Chapter 2: The Biological Perspective"
Then I should see Assign/Unassign link in active state on the content frame header
When I click on assign/Unassign link displayed in content frame header
Then I should see the check mark in assigned status column next to the assets

#PEGASUS-21971
#Purpose : To validate Assign one content using Assign/Unassign link
#Test Case Id :peg-21971 -Assign one content using Assign/Unassign link
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Assign one content using Assign Unassign link by Instructor
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsInstructor"
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "Take the Chapter 3 Exam" in "Calendar" by "HSSCsSmsInstructor"
And I select the check box of any 1 activities in "Chapter 3: Sensation and Perception"
Then I should see Assign/Unassign link in active state on the content frame header
When I click on assign/Unassign link displayed in content frame header
Then I should see the check mark in assigned status column next to the assets

#Purpose: To drag and drop multiple assets in assignment calendar.
#Test case ID : peg-21981.
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Drag and drop the more than one assets to current date in Assignment calendar
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsInstructor"
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "Chapter 4: Consciousness: Sleep, Dreams, Hypnosis, and Drugs" asset
And I should see the current date highlighted in the calendar frame
When I select "Review the Chapter 4 Learning Objectives" in "Calendar" by "HSSCsSmsInstructor"
And I select the check box of any 2 activities in "Chapter 4: Consciousness: Sleep, Dreams, Hypnosis, and Drugs"
And I should drag and drop multiple assets along with "Review the Chapter 4 Learning Objectives" to the current date
Then I should see due date icon displayed in current date

#PEGASUS-21987
#Purpose : As Instructor for HED Product,I need to validate the display of start date icon in calendar frame
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: To validate the display of start date icon in calendar frame by Instructor
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsInstructor"
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsInstructor"
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "Chapter 1: The Science of Psychology" asset
And I should see the current date highlighted in the calendar frame
And I should see the startdate Icon in calendar frame

#Purpose: To validate the current date assigned content in calendar frame by Coursespace Instructor
#Test Case Id: peg-21985
Scenario: To check the current date assigned content in the calendar by Instructor
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsInstructor"
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "Chapter 1: The Science of Psychology" asset
And I should see the current date highlighted in the calendar frame
When I select the current date 
Then I should see the assigned content "Complete the Chapter 1 Study Plan" in the day view

#Purpose :Instructor assign the asset with duedate in Managecoursework
#TestCase Id: peg-22221
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Instructor assign the asset with duedate in Managecoursework
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I select "Review the Chapter 4 Learning Objectives" in "Course Materials" by "HSSCsSmsInstructor"
And I click on "Properties" option in c menu of "Review the Chapter 4 Learning Objectives" asset
Then I should be on the "Properties" page
When I assign asset with due date and save
Then I should see the successfull message "Properties updated successfully."
And I should see assigned icon for "Review the Chapter 4 Learning Objectives" 

#Purpose: To assign the content to currentdate
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Instructor assign the content with assign the content with due date ,startdate and endate
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsInstructor"
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select "Complete the Chapter 1 Study Plan" in "Calendar" by "HSSCsSmsInstructor"
And I select cmenu "Assignment Properties" of activity "Complete the Chapter 1 Study Plan" 
Then I should see the "Assign" popup
And I assign the asset for current date in the properties popup



 



