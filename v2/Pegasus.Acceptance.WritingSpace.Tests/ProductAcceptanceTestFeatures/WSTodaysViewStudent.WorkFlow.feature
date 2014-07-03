Feature: WSTodaysViewStudent
	                As a MMND Student 
					I want to manage all the MMND Student TodaysView related usecases 
					so that I would validate all the MMND Student TodaysView scenarios are working fine.

#Purpose: To Verify Display of Writingspace Activity in Today's View 
Scenario: Verify The Display Of Writingspace Activity In Todays View by MMND Student
When I click on "Course Home" subtab
And I click the "Todays_ViewStudent" link
And I click on 'New Grades' alert option
Then I should not see the "WritingSpace" assessment for student
When I click on the "My Progress" option
Then I should not see the "WritingSpace" assessment in 'My Progress' channel

