Feature: WorkSpaceInstructorCalendar
	                As a WorkSpace Autohor
					I want to manage all the workspace Instructor Calendar related usecases 
					so that I would validate all the workspace Instructor Calendar scenarios are working fine.

#Purpose: To check the View By dropdown under Table of Contents
# TestCase Id: HED_MIL_PWF_119
# MyItLabSIMMasterCourse
Scenario: To check the View By dropdown under Table of Contents By Ws Instructor
When I navigate to "Course Materials" tab and selected "Assignment Calendar" subtab
Then I should be on the "Calendar" page
When I select " Table of Contents" option in 'View By' dropdown
Then I should see contents in the content frame which are created in course

#Purpose: To check the Display of Assignment Calendar tab
# TestCase Id: HED_MIL_PWF_117
# MyItLabSIMMasterCourse
Scenario: To check the Display of Assignment Calendar tab By Ws Instructor
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I click on the "Course Tools" tab
And I click on 'Display as tab on main navigation row' link under course materials
Then I should see the "Assignment Calendar" tab as main tab
When I click on 'Display under Content tab' link under course materials
And I navigate to "Course Materials" tab and selected "Assignment Calendar" subtab
Then I should be on the "Calendar" page

# Purpose: To check the All Items functionality under Table of Contents View by option
# TestCase Id: HED_MIL_PWF_122
# MyItLabSIMMasterCourse
Scenario: To check the All Items functionality under Table of Contents View by option By Ws Instructor
When I navigate to "Course Materials" tab and selected "Assignment Calendar" subtab
Then I should be on the "Calendar" page
When I select " Table of Contents" option in 'View By' dropdown
And I select the "AllItems" from show dropdown
Then I should see the asset contents in caledar frame

# Purpose: To check the Items Assigned functionality under Table of Contents View by option
# TestCase Id: HED_MIL_PWF_123 
#MyItLabSIMMasterCourse
Scenario: To check the Items Assigned functionality under Table of Contents View by option
When I navigate to "Course Materials" tab and selected "Assignment Calendar" subtab
Then I should be on the "Calendar" page
When I select " Table of Contents" option in 'View By' dropdown
And I select the "ItemsAssigned" from show dropdown
Then I should see the  assigned asset contents in caledar frame

# Purpose: To check the Shown Items functionality under Table of Contents View by option
# TestCase Id: HED_MIL_PWF_126
#MyItLabSIMMasterCourse
Scenario: To check the Shown Items functionality under Table of Contents View by option By Ws Instructor
When I navigate to "Course Materials" tab and selected "Assignment Calendar" subtab
Then I should be on the "Calendar" page
When I select " Table of Contents" option in 'View By' dropdown
And I select the "ShownItems" from show dropdown
Then I should see the asset contents in caledar frame

# Purpose: To check the Instructor Graded functionality under Table of Contents View by option
# TestCase Id:HED_MIL_PWF_125
#MyItLabSIMMasterCourse
Scenario: To check the Instructor Graded functionality under Table of Contents View by option By Ws Instructor
When I navigate to "Course Materials" tab and selected "Assignment Calendar" subtab
Then I should be on the "Calendar" page
When I select " Table of Contents" option in 'View By' dropdown
And I select the "InstructorGraded" from show dropdown
Then I should see the Instructor Graded contents in caledar frame

# Purpose: To verify the dependency of the calendar preferences with other preference
# TestCase Id: HED_MIL_PWF_118
#MyItLabSIMMasterCourse
Scenario: To verify the dependency of the calendar preferences with other preference By Ws Instructor
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I disable the 'Enable Calendar' preference
And I click on the "Instructor Resources" tab
And I select 'Enable Instructor Only assets' preference
And I click on the "General" tab
Then I should see 'HED Calendar layout' and 'Skip Calendar Setup' prefernces unchecked locked and disabled
When I click on the "Instructor Resources" tab
And I select 'Enable Instructor Only assets' preference
And I click on the "General" tab
And I enable 'Enable Calendar' in general preference settings
And I click on the "Instructor Resources" tab
Then I should see 'Enable Instructor Only assets' preference in disabled state