Feature: CourseSpaceGradeBook
	                As a CS Teacher 
					I want to manage all the coursespace gradebook related usecases 
					so that I would validate all the gradebook scenarios are working fine.

#This Usecase will not navigate inside the course
#Purpose: Digital path teacher selects Apply Grade Schema c-menu option of column / Cell in Grade book
Scenario: Digital path teacher selects Apply Grade Schema cmenu option of column or Cell in Grade book by CS Teacher
Given I browsed the login url for "DPCsTeacher"
When I login to Pegasus as "DPCsTeacher" in "CourseSpace"
Then I should be logged in successfully
When I navigate to the "Classes" tab
Then I should be on the "Classes" page
When I select the "Grades" link
Then I should be on the "Classes" page
When I click on view grade of "StudyPlan" in Gradebook 
And I select "ApplyGradeSchema" cmenu of studyplan "PreTest"
Then I should see the "PreTest" activity status "A" in Gradebook for the enrollled "DPCsStudent"
When I select "EditGrades" cmenu of "PreTest"
And I edit the grade with user score "8" and maximum score "10"
Then I should see the "PreTest" activity status "B" in Gradebook for the enrollled "DPCsStudent"
When I select "EditGrades" cmenu of "PreTest"
And I edit the grade with user score "7" and maximum score "10"
Then I should see the "PreTest" activity status "C" in Gradebook for the enrollled "DPCsStudent"
When I select "EditGrades" cmenu of "PreTest"
And I edit the grade with user score "6" and maximum score "10"
Then I should see the "PreTest" activity status "D" in Gradebook for the enrollled "DPCsStudent"
When I select "EditGrades" cmenu of "PreTest"
And I edit the grade with user score "5" and maximum score "10"
Then I should see the "PreTest" activity status "F" in Gradebook for the enrollled "DPCsStudent"
When I select "EditGrades" cmenu of "PreTest"
And I edit the grade with user score "10" and maximum score "10"
And I select "RemoveGradeSchema" cmenu of "PreTest"
