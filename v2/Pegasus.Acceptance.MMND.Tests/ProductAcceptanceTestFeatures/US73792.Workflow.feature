#Purpose: Feature Description
Feature: US73792  - SMS User Creation
					As a SMS Admin 
					I want to register new SMS users
					so that I can access the course thorugh SMS users.

#Purpose: Open SMS Url
Background: 
Given I browsed the URL of "SMSAdmin" 
Then I should see the SMS registration URL browsed successfully

#Creation of MMND Instructor
@CreateMMNDInstructor
Scenario: Create New MMND Instructor in SMS 
Given I am on the "License Agreement and Privacy Policy" page
When I register new SMS user as "MMNDInstructor"
Then I should see the Confirmation and Summary for "MMNDInstructor" registeration