Feature: CourseSpaceStudentGradebook
	                As a Student 
					I want to manage all the coursespace Gradebook related usecases 
					so that I would validate all the coursespace Student Gradebook scenarios are working fine.

					
#Purpose: :Student validating the display of Custom View subtab
#TestCase Id: 
#MyItLabProgramCourse, MySpanishLabCourse
Scenario: Validate the CustomView subtab as CsSmsStudent
When I click on "Custom View" subtab in "Grades" tab as "CsSmsStudent" user
Then I should be able to see "Custom View" submenu text with "Activity" and "Grade" columns as "CsSmsStudent" user

#Purpose: :Students validating the Activity and Grade saved to custom view
#TestCase Id: 
#MyItLabProgramCourse
#Pre Condition: Activity should be submitted by the student
Scenario: Validate the activity saved to custom view by Zero score student
When I click on "Custom View" subtab in "Grades" tab as "CsSmsStudent" user
Then I should see "RegCustomViewActivity1" with "ActivityIcon" having "0" grade for "ZeroScore" as "CsSmsStudent" user

#Purpose: Students validating the Activity and Grade saved to custom view                                    
#TestCase Id: 
#MyItLabProgramCourse
#Pre Condition: Activity should be submitted by the student
Scenario: Validate the activity saved to custom view by 100 score student
When I click on "Custom View" subtab in "Grades" tab as "CsSmsStudent" user
Then I should see "RegCustomViewActivity1" with the "ActivityIcon" having "100" grade for "CsSmsStudent" user

#Purpose: Student validating the functionality of sorting 'Activity' colum in Custom view tab
#TestCase Id: 
#MyItLabProgramCourse
#Pre Condition: Activity should be submitted by the student
Scenario: Sorting the activity column in Custom View tab
When I click on "Custom View" subtab in "Grades" tab as "CsSmsStudent" user
And I sort the "Activity" in 'Descending' order
Then I should see "Descending" icon for the sorted column
And I should see "RegCustomViewActivity1","RegCustomViewActivity2" activity in "Descending" order
When I sort the "Activity" in 'Ascending' order
Then I should see "Ascending" icon for the sorted column
And I should see "RegCustomViewActivity1","RegCustomViewActivity2" activity in "Ascending" order

#Purpose: Student validating the functionality of sorting 'Grade' colum in Custom view tab
#TestCase Id: 
#MyItLabProgramCourse
#Pre Condition: Activity should be submitted by the student and Grades should be displayed
Scenario: Sorting the Grade column in Custom View tab
When I click on "Custom View" subtab in "Grades" tab as "CsSmsStudent" user
And I sort the "Activity" in 'Descending' order
Then I should see "Descending" icon for the sorted column
And I should see "RegCustomViewActivity1","RegCustomViewActivity2" activity in "Descending" order
When I sort the "Grade" in 'Ascending' order
Then I should see "Ascending" icon for the sorted column
And I should see "RegCustomViewActivity1","RegCustomViewActivity2" activity in "Ascending" order

#Purpose : Folder Navigation in Grades tab
#Test case ID :
#Products : MyItLab.
#Pre condition : 
Scenario: Folder Navigation in Grades tab of coursespace student
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsStudent"
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I navigate to "RegCustomViewActivity1" activity in "Grades" by "CsSmsStudent"
Then I should see "RegCustomViewActivity1" activity in Grades tab with "100" grade
When I click on "view submission" cmenu option of "RegCustomViewActivity1" as "CsSmsStudent" user
Then I should be on the "View Submission" page
And I should see "RegCustomViewActivity1" activity name 
And I should see "Attempts" grid with "Date" "Grade" columns having "2" entries
When I click on attempt having "100" grade as "CsSmsStudent"
Then I should see "CsSmsStudent" with "100%" score 
