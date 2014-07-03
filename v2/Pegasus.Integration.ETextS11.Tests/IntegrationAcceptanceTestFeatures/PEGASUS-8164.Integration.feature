Feature: PEGASUS-8164: Launch eText in Section Course
					As a CS Instructor 
					I want to manage all the coursespace instructor related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When I login to Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page

#Purpose: Launch eText in Section Course for Instructor
Scenario: Launch eText in Section Course by SMS Instructor
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor" 
Then I should be on the "Calendar" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see "eText" Activity in the MyCourse Frame
When I "Open" the Activity 
Then I should see the 'etext' launched successfully
When I close etext "Pearson eText" presentation window
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Launch eText in Section Course for Demo User
Scenario: Launch eText in Section Course for DemoUser by SMS Instructor
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor" 
Then I should be on the "Calendar" page
When I select the "Go to Student View" link in Global Home page
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When  I open the "eText" Activity 
Then I should see the 'etext' launched successfully
When I close etext "Pearson eText" presentation window
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."
