Feature: PEGASUS-5184- Unenroll Users from class upon update membership event
						As a PSN+
						I want to Make REST POST call of Unenroll Event
						so that I can see the domain user is not available in domain organization

Background: 
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully

#Purpose: Unenroll Users from class upon update membership event
Scenario: PSN+ process the CMS update membership call to uneroll and unsubscribe users conatined in the CMS request
Then I should be able to receive the status "OK" on posting the "Unenroll" event

#Purpose: Validate the Unenrolled user in Users tab
Scenario: Verify the users are unsubscribe from the same Class at PSN+ which was sent by Powerschool via CMS in Users tab
Given I am on the Manage Organization page of "PowerSchool" organization level in "DigitalPath"
When I navigate to the "Users" tab in 'Manage Organization' page
And I search the created "RumbaTeacher" in "Users" subtab
Then I should see the message "There are no users."
When I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application." 

#Purpose: Validate the Unenrolled user Manage Roster tab
Scenario: Verify the users are unenrolled from the same Class at PSN+ which was sent by Powerschool via CMS in Manage Roster tab
Given I am on the Manage Organization page of "PowerSchool" organization level in "DigitalPath"
When I navigate to the "Classes" tab in 'Manage Organization' page
And I select the "Manage Roster" from "DigitalPathContineoMasterLibrary" cmenu options
Then I should be on the 'Manage Students' page
And I should see the "RumbaTeacher" unenroll in the 'Manage Students' page
When I close the "Manage Students" window
And I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application." 