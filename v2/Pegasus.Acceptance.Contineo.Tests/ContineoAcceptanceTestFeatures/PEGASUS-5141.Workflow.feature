	Feature: PEGASUS-5141- PSN+ should enroll/subscribe users into PS class upon create membership event
						As a CS Admin 
						I want to Search the Enrolled Users in Roaster
						so that I would be able to validate the Enrolled User Related Scenarios.

#Purpose: Open CS Url
Background: 
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully

#Purpose: Search Enrolled Rumba Teacher in Manage Roster
Scenario: Search Enrolled Rumba Teacher in Manage Roster
Given I am on the Manage Organization page of "PowerSchool" organization level in "DigitalPath"
When I navigate to the "Classes" tab in 'Manage Organization' page
And I select the "Manage Roster" from "DigitalPathContineoMasterLibrary" cmenu options
Then I should be on the 'Manage Students' page
And I should see the "RumbaTeacher" user in the 'Manage Students' page
When I close the "Manage Students" window
And I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Search Enrolled Rumba Student in Manage Roster
Scenario: Search Enrolled Rumba Student in Manage Roster
Given I am on the Manage Organization page of "PowerSchool" organization level in "DigitalPath"
When I navigate to the "Classes" tab in 'Manage Organization' page
And I select the "Manage Roster" from "DigitalPathContineoMasterLibrary" cmenu options
Then I should be on the 'Manage Students' page
And I should see the "RumbaStudent" user in the 'Manage Students' page
When I close the "Manage Students" window
And I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."
