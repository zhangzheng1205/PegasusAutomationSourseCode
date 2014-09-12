#Purpose: Feature Description
Feature: US73789 - Change Integration Point Id
					As a MMND Admin 
					I want to change integration point id
					so that I would create MMND courses.

#Purpose: Change the integration point id for CoOrdinate course
Scenario: Change the integration point id for CoOrdinate course
When I select CCNG from the drop down list
And I select course settings
And I Update the integration point id for "MMNDCoOrdinate" course
Then I should see the successfull message "Course Tool Setting has been updated successfully."
#Then I should see the message "Course Compass Next Generation"

#Purpose: Change the integration point id for Non CoOrdinate course
Scenario: Change the integration point id for Non CoOrdinate course
#Given I am on the "Administrative Pages" page
#When I select CCNG from the drop down list
When I select course settings
And I Update the integration point id for "MMNDNonCoOrdinate" course
Then I should see the successfull message "Course Tool Setting has been updated successfully."
#Then I should see the message "Course Compass Next Generation"

