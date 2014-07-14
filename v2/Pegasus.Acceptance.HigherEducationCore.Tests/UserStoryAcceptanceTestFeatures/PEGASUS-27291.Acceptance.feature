Feature: CourseSpaceAdmin
					As a CS Admin 
					I want to search user and promote him as admin
					so that CS Admin will MakeReadOnly for Promoted Admin.

#Purpose: Open CS Url and navigate to Administrators tab
Background:
Given I browsed the login url for "HedCsAdmin"
When I logged into the Pegasus as "HedCsAdmin" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Course Enrollment" page
When I navigate to the "Administrators" tab
Then I should be on the "Administration Tool" page

#Purpose: Enroll users as promoted admin in administrator tab
Scenario: Enroll users as promoted admin
When I select the "CsSmsInstructor"
And I click on enroll button
Then I should see the successfull message "Administrators enrolled successfully."

#Purpose: MakeReadOnly c-menu for Promoted Admin
Scenario: MakeReadOnly c-menu for Promoted Admin
When I click on the cmenu option of "CsSmsInstructor"
Then I should see the "Make Read Only" cmenu

