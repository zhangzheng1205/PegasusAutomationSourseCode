Feature: WorkSpaceAdmin Publishing Process
					As a WS Admin 
					I want to publish the sim course 
					so that I would validate all the sim course scenarios are working fine.

#Purpose: Workspace Admin Publishing Process of SIM Master Course
#HED_MIL_PWF_148
Scenario: Workspace Admin Publishing Process of SIM Master Course
When I search "MyItLabSIM5MasterCourse" course in workspace by "CourseName" and "Equals" dropdown option
Then I should be able to see the searched "MyItLabSIM5MasterCourse" course
When I publish the Authored "MyItLabSIM5MasterCourse" in workspace as "Master Course"
Then I should see the successfull message "Course published successfully."

#Purpose: Workspace Admin Publishing Process of SIM Master Course
Scenario:Workspace Publish Fresh SIM Master Course Or Existing SIM Master Course
When I Publish "MyItLabSIM5MasterCourse" or "ExistingCourseForPublish"
Then I should see the successfull message "Course published successfully."