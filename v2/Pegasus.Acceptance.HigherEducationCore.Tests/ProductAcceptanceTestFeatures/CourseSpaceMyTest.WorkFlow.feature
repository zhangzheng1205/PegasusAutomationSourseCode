Feature: CourseSpaceMyTest
                     As a CS Instructor 
					I want to manage all the coursespace My Test related usecases 
					so that I would validate all the My Test scenarios are working fine.

#Purpose: Login as Cs Instructor
Background:
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully

#Purpose: Create MyTest Activity By CS Instructor
Scenario: Create MyTest Activity By SMS Instructor
Given I am on the "Global Home" page 
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Calendar" page
When I navigate to the "MyTest" tab
And I click on the "Create New Test" link in Manage Your Tests and created Test using "TrueFalse" question
Then I should see the successfull message "Test saved successfully." in MyTest tab
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."
