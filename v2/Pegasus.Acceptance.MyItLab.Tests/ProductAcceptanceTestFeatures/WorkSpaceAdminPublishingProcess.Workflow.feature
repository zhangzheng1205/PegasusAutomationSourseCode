Feature: WorkSpaceAdmin Publishing Process
					As a WS Admin 
					I want to publish the sim course 
					so that I would validate all the sim course scenarios are working fine.


Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedMiLWsAdmin"
When I logged into the Pegasus as "HedMiLWsAdmin" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Course Enrollment" page


#Purpose: Workspace Admin Publishing Process of SIM Master Course
#HED_MIL_PWF_148
Scenario: Workspace Admin Publishing Process of SIM Master Course
When I search "MyItLabSIM5MasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabSIM5MasterCourse" course
When I publish the Authored "MyItLabSIM5MasterCourse" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."
When I "Sign out" from the "HedMiLWsAdmin"
Then I should see the successfull message "You have been signed out of the application."
