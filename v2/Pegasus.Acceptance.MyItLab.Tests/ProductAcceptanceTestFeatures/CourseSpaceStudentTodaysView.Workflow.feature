Feature: CourseSpaceStudent TodaysView
	                As a CS Student 
					I want to manage all the coursespace student todaysview related usecases 
					so that I would validate all the coursespace student todaysview scenarios are working fine.

#Purpose: View submission in today's view
# TestCase Id: HED_MIL_PWF_920
#MyItLabProgramCourse
Scenario: View submission in todays view by SMS Student
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click New Grades alert option
Then I should see the successfully submitted "SIM5Activity" name of behavioral mode "SkillBased"
When I click the cmenu option 'ViewAllSubmissions' in student side
Then I should see the grade "100" in view submission page
When I close the "View Submission" window

#Purpose: To Submit Sim Activity Inside Program Course
# TestCase ID: HED_MIL_PWF_915
#MyItLabProgramCourse
Scenario: Activity Submission Inside Program Course by SMS Student
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I submit the "SIM5Activity" activity of behavioral mode "SkillBased" type
Then I should see "Passed" status of the "SIM5Activity" activity of behavioral mode "SkillBased" type
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
When I click New Grades alert option
Then I should see the successfully submitted "SIM5Activity" name of behavioral mode "SkillBased"
When I click the cmenu option 'ViewAllSubmissions' in student side
Then I should see the grade "100" in view submission page
When I close the "View Submission" window

#Purpose:C-menu option for the assets under performance channel - View submission c-menu
#TestCase ID :HED_MIL_PWF_931
#MyItLabProgramCourse
Scenario: Cmenu option for the assets under performance channel View submission cmenu
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I select 'My Progress' option
And I click on cmenu option of activity "Test"
And I select the cmenu option "View Submission" of the activity
Then I should be on the "View Submission" page
When I close the "View Submission" window
