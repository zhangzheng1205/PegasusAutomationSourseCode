Feature: eCollegeCourseAction
	

#Feature: Instructor navigating to Pegasus course link in eCollege home Page
Scenario: eCollege Instructor selecting a Academics PSH link in home Page
Given I am on the home PSH of eCollege
When I select "Academics PSH" link
Then I should see "Academics PSH" Page contents
