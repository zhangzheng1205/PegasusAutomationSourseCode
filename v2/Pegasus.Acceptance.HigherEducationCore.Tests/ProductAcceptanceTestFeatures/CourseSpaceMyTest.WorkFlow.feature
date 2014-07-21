Feature: CourseSpaceMyTest
                     As a CS Instructor 
					I want to manage all the coursespace My Test related usecases 
					so that I would validate all the My Test scenarios are working fine.

#Used Instructor Course
#Purpose: Create MyTest Activity By CS Instructor
Scenario: Create MyTest Activity By SMS Instructor
When I navigate to "MyTest" tab and selected "MyTest" subtab
Then I should be on the "MyTest" page
When I click on the "Create New Test" link in Manage Your Tests and created Test using "TrueFalse" question
Then I should see the successfull message "Test saved successfully." in MyTest tab
