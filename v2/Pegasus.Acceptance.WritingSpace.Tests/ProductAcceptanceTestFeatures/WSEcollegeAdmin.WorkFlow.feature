#Purpose: Feature Description
Feature: Change Integration Point Id
					As a Ecollege Admin 
					I want to manage all the change integration point id related usecases 
					so that I would validate all the create courses scenarios are working fine.

#Purpose: Open URL for Admin tool page
Background:
Given I browsed the URL of "MMNDAdmin" 
When I login to MMND Cert as "MMNDAdmin"
Then I should be logged in successfully as "MMNDAdmin"

#Purpose: Change the integration point id for Non CoOrdinate course
Scenario: Change the integration point id for Non CoOrdinate course
Given I am on the "Administrative Pages" page
When I select CCNG from the drop down list
And I select course settings
And I Update the integration point id for "MMNDNonCoOrdinate" course
Then I should see the successfull message "Course Tool Setting has been updated successfully." in MMND
And I log out from the application as "MMNDAdmin"
Then I should see the message "Course Compass Next Generation"
