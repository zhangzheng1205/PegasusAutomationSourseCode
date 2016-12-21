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
And I register new SMS user as "HedProgramAdmin" with "Single" mode
Then I should see the Confirmation and Summary for "HedProgramAdmin" registeration

# Creation of SMS Instructor
@SMSIns
Scenario: Create Instructor by SMS Admin
When I accept the License Agreement and Privacy Policy of SMS
And I register new SMS user as "CsSmsInstructor" with "Single" mode
Then I should see the Confirmation and Summary for "CsSmsInstructor" registeration

# Creation of SMS Student
@SMSStudent
Scenario: Create Student by SMS Admin
When I accept the License Agreement and Privacy Policy of SMS
And I register new SMS user as "CsSmsStudent" with "Single" mode
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

#Purpose:To Create Bulk SMS Student Users using Runtime Generated values(UN/FN/LN)
#        The runtime values are stored in Excel File generated on runtime.
Scenario:Bulk Student creation with GUID details
Given I create '3' users of type "CsSmsStudent" with mode "BulkRuntime" as "SMSAdmin"

#Purpose:To Create Bulk SMS Student Users using values provided in excel sheet.
# Creation of Bulk User with user details from excel
Scenario: Bulk Student creation with excel details
Given I create '3' users of type "CsSmsStudent" with mode "BulkExcel" as "SMSAdmin"

#Purpose:To Create Bulk SMS Instructor Users using Runtime Generated values(UN/FN/LN)
#        The runtime values are stored in Excel File generated on runtime.
Scenario:Bulk Intructor creation with GUID details
Given I create '3' users of type "CsSmsInstructor" with mode "BulkRuntime" as "SMSAdmin"

#Purpose:To Create Bulk SMS Instructor Users using values provided in excel sheet.
# Creation of Bulk User with user details from excel
Scenario: Bulk Instructor creation with excel details
Given I create '3' users of type "CsSmsInstructor" with mode "BulkExcel" as "SMSAdmin"