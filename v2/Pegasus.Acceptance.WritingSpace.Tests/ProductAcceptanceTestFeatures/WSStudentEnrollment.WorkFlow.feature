#Purpose: Feature Description
Feature: WS SMS Student User Creation
					As a SMS Admin 
					I want to register new SMS Student users
					so that I can access the course thorugh SMS Student users.

#Purpose: Open SMS Url
Background: 
Given I browsed the URL of "SMSAdminStudent" 
Then I Should see the SMS Student registration URL browsed successfully

#Creation of MMND Student
Scenario: Create New Student in SMS
Given I am on the "Product Selection" page
When I enter the course id of "MMNDNonCoOrdinate" course
And I register new SMS user as "MMNDStudent"
Then I should see the Confirmation and Summary for "MMNDStudent" registeration
When I login as MMNDStudent
Then I should the enrolled "MMNDNonCoOrdinate" course
When I log out from the application as "MMNDStudent"
Then I should see the application logout successfully
