Feature: eCollegeCourseAction
	

#Feature: Instructor navigating to Pegasus course link in eCollege home Page
Scenario: eCollege Instructor selecting a Academics PSH link in home Page
Given I am on the home PSH of eCollege
When I select "Academics PSH" link
Then I should see "Academics PSH" Page contents

Scenario: eCollege Instructor selecting a Pegasus link in Academics PSH
#Given I am on the home PSH of eCollege
When I select "MIL_Course" Pegasus course
Then I should see "MIL_Course" contents

Scenario: eCollege Instructor selecting a Pegasus Grades
When I select "Grades" of Pegasus course
Then I should see Pegasus "Gradebook"

