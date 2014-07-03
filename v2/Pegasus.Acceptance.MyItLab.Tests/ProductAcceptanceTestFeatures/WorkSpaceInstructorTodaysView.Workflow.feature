Feature: WorkSpaceInstructorTodaysView
         As a Ws Instructor 
	     I want to manage all the workspace Instructor related usecases 
		 so that I would validate all the workspace Instructor scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully

#Purpose:To check the Default view of Today's View Channel displayed for Workspace Instructor
## TestCase Id: HED_MIL_PWF_043
Scenario: To check the Default view of Todays View Channel displayed for Workspace Instructor
Given I am on the "Global Home" page
When I enter in the "MyItLabSIM5MasterCourse" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
And I should see the "CalendarNotificationsAnnouncements" channels in 'Todays view' page
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To verify the tab navigation inside the Course for Workspace Instructor
#Test Case Id : HED_MIL_PWF_044
Scenario: To verify the tab navigation inside the course for Workspace Instructor
When I enter in the "MyItLabSIM5MasterCourse" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "MyTest" tab
Then I should be on the "MyTest" page
When I navigate to the "Course Materials" tab
Then I should see the following subtabs under Course Materials page
| SubtabName                           | WindowTitle		|
| Add from Library                     | Course Materials	|
| Manage Course Materials              | Course Materials	|
| Map Learning Objectives              | Course Materials	|
| Media Library                        | Media Library Page |
| Map Learning Objectives to Questions | Question Bank		|
| Manage Question Bank                 | Question Bank		|
When I navigate to the "Gradebook" tab
Then I should see the following subtabs under Gradebook page
| SubtabName		| WindowTitle      |
| Grades			| Gradebook        |
| Custom View		| Custom View      |
| Learner Settings	| Learner Settings |
| Reports			| Reports		   |
When I navigate to the "Enrollments" tab
Then I should see the following subtabs in Enrollments page   
| SubtabName       | WindowTitle |
| Manage Roster    | Roster      |
| Manage Groups    | Enrollments |
When I navigate to the "Communicate" tab
Then I should see the following subtabs under Communicate page
| SubtabName      | WindowTitle |
| Mail      | Course Mail   |
| Chat      | Communicate   |
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."