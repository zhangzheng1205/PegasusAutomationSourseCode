Feature: CourseSpaceStudentGradebook
	                As a Student 
					I want to manage all the coursespace Gradebook related usecases 
					so that I would validate all the coursespace Student Gradebook scenarios are working fine.

					
#Purpose: :Student validating the display of Custom View subtab
#TestCase Id: 
#MyItLabProgramCourse, MySpanishLabCourse
Scenario: Validate the CustomView subtab as CsSmsStudent
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsStudent"
When I click on "Custom View" subtab in "Grades" tab as "CsSmsStudent" user
Then I should be able to see "Custom View" submenu text with "Activity" and "Grade" columns as "CsSmsStudent" user


#Purpose: :Students validating the functionality of saving an activity to custom view
#TestCase Id: 
#MyItLabProgramCourse, MySpanishLabCourse
#Pre Condition: Activity should be submitted by the student
Scenario: Saving an activity to custom view tab from Grades tab
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsStudent"
And I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I click on "Custom View" subtab in "Grades" tab as "CsSmsStudent" user
Then I should see "RegCustomViewActivity1" with "ActivityIcon" having "0" grade for "ZeroScore" as "CsSmsStudent" user


