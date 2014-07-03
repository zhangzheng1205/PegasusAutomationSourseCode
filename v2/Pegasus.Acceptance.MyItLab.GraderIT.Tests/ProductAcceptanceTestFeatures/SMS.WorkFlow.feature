Feature: SMS User Subscription Through SMS
					As a SMS Admin 
					I want to register new SMS users
					so that I can access the course thorugh SMS users.

#Purpose: Open SMS Url
Background: 
Given I browsed the login url for "SMSAdmin"

# Creation of SMS Instructor
Scenario: Create Instructor by SMS Admin
When I accept the License Agreement and Privacy Policy of SMS
And I register new SMS user as "CsSmsInstructor"
Then I should see the Confirmation and Summary for "CsSmsInstructor" registeration

# Creation of SMS Student
Scenario: Create Student by SMS Admin
When I accept the License Agreement and Privacy Policy of SMS
And I register new SMS user as "CsSmsStudent"
Then I should see the Confirmation and Summary for "CsSmsStudent" registeration