Feature: WorkSpaceInstructorCalendar
	                As a WorkSpace Autohor
					I want to manage all the workspace Instructor Calendar related usecases 
					so that I would validate all the workspace Instructor Calendar scenarios are working fine.

#Purpose: Open Ws Url and login as WsTeacher
Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To check the View By dropdown under Table of Contents
# TestCase Id: HED_MIL_PWF_119
Scenario: To check the View By dropdown under Table of Contents By Ws Instructor
When I enter in the "MyItLabSIMMasterCourse" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select " Table of Contents" option in 'View By' dropdown
Then I should see contents in the content frame which are created in course
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To check the Display of Assignment Calendar tab
# TestCase Id: HED_MIL_PWF_117
Scenario: To check the Display of Assignment Calendar tab By Ws Instructor
When I enter in the "MyItLabSIMMasterCourse" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I click on the "Course Tools" tab
And I click on 'Display as tab on main navigation row' link under course materials
Then I should see the "Assignment Calendar" tab as main tab
When I click on 'Display under Content tab' link under course materials
And I navigate to the "Course Materials" tab
And I select the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

# Purpose: To check the All Items functionality under Table of Contents View by option
# TestCase Id: HED_MIL_PWF_122
Scenario: To check the All Items functionality under Table of Contents View by option By Ws Instructor
When I enter in the "MyItLabSIMMasterCourse" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select " Table of Contents" option in 'View By' dropdown
And I select the "AllItems" from show dropdown
Then I should see the asset contents in caledar frame
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

# Purpose: To check the Items Assigned functionality under Table of Contents View by option
# TestCase Id: HED_MIL_PWF_123 
Scenario: To check the Items Assigned functionality under Table of Contents View by option
When I enter in the "MyItLabSIMMasterCourse" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select " Table of Contents" option in 'View By' dropdown
And I select the "ItemsAssigned" from show dropdown
Then I should see the  assigned asset contents in caledar frame
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

# Purpose: To check the Shown Items functionality under Table of Contents View by option
# TestCase Id: HED_MIL_PWF_126
Scenario: To check the Shown Items functionality under Table of Contents View by option By Ws Instructor
When I enter in the "MyItLabSIMMasterCourse" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select " Table of Contents" option in 'View By' dropdown
And I select the "ShownItems" from show dropdown
Then I should see the asset contents in caledar frame
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

# Purpose: To check the Instructor Graded functionality under Table of Contents View by option
# TestCase Id:HED_MIL_PWF_125
Scenario: To check the Instructor Graded functionality under Table of Contents View by option By Ws Instructor
When I enter in the "MyItLabSIMMasterCourse" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select the "Assignment Calendar" tab
Then I should be on the "Calendar" page
When I select " Table of Contents" option in 'View By' dropdown
And I select the "InstructorGraded" from show dropdown
Then I should see the Instructor Graded contents in caledar frame
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

# Purpose: To verify the dependency of the calendar preferences with other preference
# TestCase Id: HED_MIL_PWF_118
Scenario: To verify the dependency of the calendar preferences with other preference By Ws Instructor
When I enter in the "MyItLabSIMMasterCourse" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Preferences" tab
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
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."
