Feature: WSCopyContentStudent
	                As a MMND Student 
					I want to manage all the MMND Student related usecases 
					so that I would validate all the MMND Student scenarios are working fine.

#Purpose: Verify The Display Of Writingspace Activity In Course Materials
Scenario: Verify The Display Of Writingspace Activity In Course Materials by MMND Student
When I click on "Course Home" subtab
And I click the "View_All_Content" link
Then I should not see the "WritingSpace" activity in View All Content