Feature: WSGradebookStudent
	                As a MMND Student 
					I want to manage all the MMND Student Gradebook related usecases 
					so that I would validate all the MMND Student Gradebook scenarios are working fine.


#Purpose: To verify Display of Writingspace Activity in Gradebook
Scenario: Verify Display of Writingspace Activity in Gradebook by MMND Student
When I click the "Grades_Student" link
Then I should see the "WritingSpace" activity with score "80"

#Purpose: To Verify The Display of Writingspace Activity Cmenu in Gradebook
Scenario: Verify The Display of Writingspace Activity Cmenu in Gradebook by MMND Student
When I click on "WritingSpace" activity cmenu option
Then I should be able to see "View Report" cmenu

#Purpose: To Verify the functionality of "Hide For Student" Cmenu Option
Scenario: Verify The Functionality of Hide for Student cmenu option reflect In Gradebook by MMND Student
When I click the "Grades_Student" link
Then I should not see the "WritingSpace" activity in gradebook



