#Purpose: Feature Description
Feature: User Subscription Through SMS
					As a SMS Admin 
					I want to register new SMS users
					so that I can access the course thorugh SMS users.

#Purpose: Open SMS Url
Background: 
Given I browsed the login url for "SMSAdmin"

# Creation of SMS Instructor As Program Admin
@SMSPrgAdmin
Scenario: Create Program Admin by SMS Admin
When I accept the License Agreement and Privacy Policy of SMS
And I register new SMS user as "HedProgramAdmin"
Then I should see the Confirmation and Summary for "HedProgramAdmin" registeration

# Creation of SMS Instructor
@SMSIns
Scenario: Create Instructor by SMS Admin
When I accept the License Agreement and Privacy Policy of SMS
And I register new SMS user as "CsSmsInstructor"
Then I should see the Confirmation and Summary for "CsSmsInstructor" registeration

# Creation of SMS Student
@SMSStudent
Scenario: Create Student by SMS Admin
When I accept the License Agreement and Privacy Policy of SMS
And I register new SMS user as "CsSmsStudent"
Then I should see the Confirmation and Summary for "CsSmsStudent" registeration

# Creation of SMS Student To Score Zero
Scenario: Create Student by SMS Admin To Score Zero
When I accept the License Agreement and Privacy Policy of SMS
And I register new SMS user for "scoring 0" as "CsSmsStudent"
Then I should see the Confirmation and Summary for "CsSmsStudent" registeration

# Creation of SMS Student To Set Idle
Scenario: Create Student by SMS Admin To Set Idle
When I accept the License Agreement and Privacy Policy of SMS
And I register new SMS user for "set idle" as "CsSmsStudent"
Then I should see the Confirmation and Summary for "CsSmsStudent" registeration
