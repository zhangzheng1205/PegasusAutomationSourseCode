Feature: CourseSpaceAssignsContent
                    As a CS Instructor 
					I want to manage all the coursespace assign content usecases 
					so that I would validate all the assign content scenarios are working fine.

#Purpose: Open Cs Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully

#Purpose: Calendar SetUp by CS Instructor
@CalendarSetup
Scenario: Calendar SetUp by SMS Instructor
Given I am on the "Global Home" page 
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Calendar" page
When I search the "Homework"
Then I should see the searched "Homework"
When I 'Drag and Drop' the "Homework" on current day
Then I should see the "Homework" assigned by 'Drag and Drop'
When I search the "Quiz"
And I Assign the Activity by the Activity Cmenu options
Then I should see the "Quiz" assigned by Cmenu options 


#Purpose: Calendar SetUp For Multiple Assets by CS Instructor
# TestCase Id: HSS_Core_PWF_310 | 
Scenario: :Calendar SetUp For Multiple Assets by CS Instructor
Given I am on the "Global Home" page 
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
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
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
And I navigate to the "Assignments" tab
And I click on calendar icon
Then I should see the assigned asset "Quiz"

