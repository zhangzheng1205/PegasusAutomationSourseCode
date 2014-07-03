Feature: CourseSpaceStudent TodaysView
	                As a CS Student 
					I want to manage all the coursespace student todaysview related usecases 
					so that I would validate all the coursespace student todaysview scenarios are working fine.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: View submission in today's view
# TestCase Id: HED_MIL_PWF_920
Scenario: View submission in todays view by SMS Student
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I click New Grades alert option
Then I should see the successfully submitted "SIM5Activity" name of behavioral mode "SkillBased"
When I click the cmenu option 'ViewAllSubmissions' in student side
Then I should see the grade "100" in view submission page
When I close the "View Submission" window
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Submit Sim Activity Inside Program Course
# TestCase ID: HED_MIL_PWF_915
Scenario: Activity Submission Inside Program Course by SMS Student
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I submit the "SIM5Activity" activity of behavioral mode "SkillBased" type
Then I should see "Passed" status of the "SIM5Activity" activity of behavioral mode "SkillBased" type
When I navigate to the "Today's View" tab
Then I should be on the "Today's View" page
When I click New Grades alert option
Then I should see the successfully submitted "SIM5Activity" name of behavioral mode "SkillBased"
When I click the cmenu option 'ViewAllSubmissions' in student side
Then I should see the grade "100" in view submission page
When I close the "View Submission" window
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."


#Purpose:C-menu option for the assets under performance channel - View submission c-menu
#TestCase ID :HED_MIL_PWF_931
Scenario: Cmenu option for the assets under performance channel View submission cmenu
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I select 'My Progress' option
And I click on cmenu option of activity "Test"
And I select the cmenu option "View Submission" of the activity
Then I should be on the "View Submission" page
When I close the "View Submission" window
And I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."
