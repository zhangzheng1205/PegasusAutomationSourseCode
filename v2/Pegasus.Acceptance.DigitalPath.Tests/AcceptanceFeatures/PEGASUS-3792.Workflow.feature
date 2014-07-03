Feature: PEGASUS-3792- Create PS INS inside Pegasus who is owner of the PS Class
						As a CS Admin 
						I want to Search the Enrolled Users 
						so that I would be able to validate the Enrolled User Related Scenarios.

#Purpose: Open CS Url
Background: 
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully

#Purpose: Search Enrolled Rumba Teacher in Users Tab
Scenario: Search Enrolled Rumba Teacher in Users Tab
Given I am on the 'Manage Organization' page of "PowerSchool" level organization in "DigitalPath"
When I navigate to the "Users" tab in 'Manage Organization' page
And I search the created "RumbaTeacher" in "Users" subtab
Then I should see the "RumbaTeacher" in "Users" subtab
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Search Enrolled Rumba Non PSN Teacher in Users Tab
Scenario: Search Enrolled Rumba Non PSN Teacher in Users Tab
Given I am on the 'Manage Organization' page of "PowerSchool" level organization in "DigitalPath"
When I navigate to the "Users" tab in 'Manage Organization' page
And I search the created "RumbaNonPSNTeacher" in "Users" subtab
Then I should see the "RumbaNonPSNTeacher" in "Users" subtab
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."


#Purpose: Search Enrolled Rumba Student in Users Tab
Scenario: Search Enrolled Rumba Student in Users Tab
Given I am on the 'Manage Organization' page of "PowerSchool" level
When I navigate to the "Users" tab in 'Manage Organization' page
And I search the created "RumbaStudent" in "Users" subtab
Then I should see the "RumbaStudent" in "Users" subtab
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

