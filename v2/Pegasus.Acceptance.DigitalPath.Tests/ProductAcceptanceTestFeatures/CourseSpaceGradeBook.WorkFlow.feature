Feature: CourseSpaceGradeBook
	                As a CS Teacher 
					I want to manage all the coursespace gradebook related usecases 
					so that I would validate all the gradebook scenarios are working fine.

#This Usecase will not navigate inside the course
#Purpose: Digital path teacher selects Apply Grade Schema c-menu option of column / Cell in Grade book
Scenario: Digital path teacher selects Apply Grade Schema cmenu option of column or Cell in Grade book by CS Teacher
When I navigate to the "Classes" tab
Then I should be on the "Classes" page
When I select the "Grades" link
Then I should be on the "Classes" page
When I click on view grade of "StudyPlan" in Gradebook 
And I select "ApplyGradeSchema" cmenu of studyplan "PreTest"
Then I should see the "PreTest" activity status "A" in Gradebook for the enrollled "DPCsStudent"
