Feature: TestBedPreparation
			In order to preparation od bed that will takes care of particular activity 
			As a different user roles
			So that once the test bed is ready then we start executing the test cases as already documented.

# Assign Assets in My Course Frame
Scenario: Assign Content In My Course Frame
When I navigate to "Course Materials" tab
And I selected activity "Access Chapter 1: End-of-Chapter Quiz" and assigned in My Course frame
Then I should see the successfull message "Content item is added to My Course"
When I selected all activity and change status as shown  