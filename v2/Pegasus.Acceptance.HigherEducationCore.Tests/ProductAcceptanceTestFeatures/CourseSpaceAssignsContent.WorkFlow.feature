Feature: CourseSpaceAssignsContent
                    As a CS Instructor 
					I want to manage all the coursespace assign content usecases 
					so that I would validate all the assign content scenarios are working fine.

#Verify the usecase in InstructorCourse
#Purpose: Calendar SetUp by CS Instructor
@CalendarSetup
Scenario: Calendar SetUp by SMS Instructor
When I navigate to "Assignment Calendar" tab of the "Calendar" page
Then I should be on the "Calendar" page
When I search the "Homework"
Then I should see the searched "Homework"
When I 'Drag and Drop' the "Homework" on current day
Then I should see the "Homework" assigned by 'Drag and Drop'
When I search the "Quiz"
And I Assign the Activity by the Activity Cmenu options
Then I should see the "Quiz" assigned by Cmenu options 

#Verify the usecase in InstructorCourse
#Purpose: Calendar SetUp For Multiple Assets by CS Instructor
# TestCase Id: HSS_Core_PWF_310 | 
Scenario: :Calendar SetUp For Multiple Assets by CS Instructor
When I navigate to "Assignment Calendar" tab of the "Calendar" page
Then I should be on the "Calendar" page
When I drag and drop 'Multiple Assets'
Then I should see the "Link" assigned by 'Drag and Drop'
And I should see the "Quiz" assigned by 'Drag and Drop'
When I search the "Link"
Then I should see the searched "Link"
And I should see the status of the activity
When I select the cmenu option 'Assignment Properties' of activity
Then I should see the due date of activity
When I search the "Quiz"
Then I should see the searched "Quiz"
And I should see the status of the activity
When I select the cmenu option 'Assignment Properties' of activity
Then I should see the due date of activity

#Purpose :Instructor assign the asset with duedate in Managecoursework
#TestCase Id: peg-22221
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Instructor assign the asset with duedate in Managecoursework
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I navigate to "Review the Chapter 04 Learning Objectives" asset in "Course Materials" tab as "CsSmsInstructor"
And I click on "Properties" option in c menu of "Review the Chapter 04 Learning Objectives" asset
Then I should be on the "Properties" page
When I assign asset with due date and save
Then I should see the successfull message "Properties updated successfully."
And I should see assigned icon for "Review the Chapter 04 Learning Objectives" 

