Feature: CourseSpaceStudentCalendar
					As a CS Student 
					I want to manage all the coursespace student calendar related usecases 
					so that I would validate all the coursespace student calendar scenarios are working fine.

#Used Instructor Course
#Purpose : Assigned assignments listed for the students under To Do
# TestCase Id: HSS_Core_PWF_425 
Scenario: Assigned assignments listed for the students under To Do by SMS Student
When I navigate to "Assignments" tab and selected "To Do" subtab
Then I should be on the "Assignments - To Do" page	
And I should see the display of assigned asset "Link" in ToDo tab

#Used Instructor Course
#Purpose :Assigned assignments listed for the date under Calendar tab
# TestCase Id: HSS_Core_PWF_427
Scenario: Assigned assignments listed for the date under Calendar tab by SMS Student
When I navigate to "Assignments" tab and selected "Course Calendar" subtab
Then I should be on the "Course Materials" page
And I should see the calendar icon for assigned asset
When I click on the calendar icon of assigned asset
Then I should see the assigned asset "El mundo hispano 01-02. Before Viewing. Other languages of the Americas."

#Used Instructor Course
#Purpose : Assigned assignments completed for under completed tab
# TestCase Id: HSS_Core_PWF_426 
Scenario: Assigned assignments completed for under completed tab by SMS Student
When I navigate to "Assignments" tab and selected "Completed" subtab
Then I should be on the "Assignments - Done" page
And I should see the assigned completed asset "El mundo hispano 01-01. Before Viewing. Where is Spanish spoken?" in completed tab



