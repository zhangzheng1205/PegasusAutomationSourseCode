Feature: CourseSpaceInstructorCopyContent
	                As a Cs Instructor 
					I want to manage all the coursespace copy content related usecases 
					so that I would validate all the coursespace Instructor scenarios are working fine.

#Purpose: Copying the assets using the "Add to Multiple Section" c-menu add the content across different section
# TestCase Id: HED_MIL_PWF_161
#MyItLabProgramCourse
Scenario: Copying the assets using the "Add to Multiple Section" c-menu add the content across different section
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "MyItLabProgramCourse" second section
And I click the "Enter Section as Instructor" 
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I search the "SIM5Activity" in Course Materials Library
And I select the Cmenu option "Add to Multiple Sections"
Then I should be on the "Add to Multiple Sections" page
When I select the 'Multiple Sections'
And I select 'Home' option
Then I should be on the "Program Administration" page
When I search the "MyItLabProgramCourse" first section
And I click the "Enter Section as Instructor" 
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I search the "SIM5Activity" in My Course frame
Then I should see the "SIM5Activity" in 'My Course'
When I click the activity cmenu option in MyCourse Frame
And I click on "Preview" cmenu option
Then I should be on the "Skill-Based Assessment Text Preview" page
When I close the "Skill-Based Assessment Text Preview" window
And I select 'Home' option
Then I should be on the "Program Administration" page

#Purpose: To check the functionality that ensures the availability and not availability of assets between the date range
# TestCase Id: HED_MIL_PWF_1013
#MyItLabInstructorCourse
Scenario: To check the functionality that ensures the availability and not availability of assets between the date range
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select 'Add Course Materials' in 'My Course'
And I click on the "myitlab Study Plan" activity type
Then I should be on the "Add myitlab Study Plan" page
When I create "StudyPlan" of behavioral mode "SkillBased" type
Then I should see the successfull message "Myitlab Study Plan added successfully."
When I associate the "StudyPlan" activity of behavioral mode "SkillBased" to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I search the "StudyPlan" in My Course frame
Then I should see the "StudyPlan" in 'My Course'
When I click the activity cmenu option in MyCourse Frame
And I click on "Properties" cmenu option
Then I should be on the "Properties" page
When I select 'Assigned' radiobutton
And I select 'Set availability date range' radiobutton
And I enable 'Do not provide an End Date' option
Then I should see the successfull message "Properties updated successfully."

#Purpose: UseCase To Create SIM5Activity
#Test Case Id : HED_MIL_PWF_053
#MyItLabInstructorCourse
Scenario: Create SIM5Activity By SMS Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select 'Add Course Materials' in 'My Course'
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "SIM5Activity" activity of behavioral mode "SkillBased" type
Then I should see the successfull message "Activity added successfully."

#Purpose : To test functionality of Show/Hide, in My Course View for Multiple Assets by CS Instructor
Scenario: Show Hide functionality in My Course View for Multiple Assets by CS Instructor
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I select checkbox of 3 assets in My Course View 
Then I should see "ShowHide" button on My Course View header "Enabled"
When I select "ShowHide" button on My Course View header
Then I should see the assets which are shown should be hidden and assets which are hidden should be shown
And I should see None or All should be displayed for the assets under Shown-To column when they are Hidden or shown respectively 