Feature: CourseSpaceStudentCalendar
					As a CS Student 
					I want to manage all the coursespace student calendar related usecases 
					so that I would validate all the coursespace student calendar scenarios are working fine.

Purpose: Open Student Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose : Assigned assignments listed for the students under To Do
# TestCase Id: HSS_Core_PWF_425 
Scenario: Assigned assignments listed for the students under To Do by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Assignments" tab
And I navigate to the "To Do" tab	
Then I should see the display of assigned asset "Link" in ToDo tab
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose :Assigned assignments listed for the date under Calendar tab
# TestCase Id: HSS_Core_PWF_427
Scenario: Assigned assignments listed for the date under Calendar tab by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Assignments" tab
Then I should see the calendar icon for assigned asset
When I click on the calendar icon of assigned asset
Then I should see the assigned asset "El mundo hispano 01-02. Before Viewing. Other languages of the Americas."
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Assigned assignments completed for under completed tab
# TestCase Id: HSS_Core_PWF_426 
Scenario: Assigned assignments completed for under completed tab by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Assignments" tab
And I navigate to the "Completed" tab
Then I should see the assigned completed asset "El mundo hispano 01-01. Before Viewing. Where is Spanish spoken?" in completed tab
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."


