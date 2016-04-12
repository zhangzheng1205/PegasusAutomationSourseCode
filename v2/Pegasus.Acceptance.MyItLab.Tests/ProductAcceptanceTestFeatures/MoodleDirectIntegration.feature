Feature: MoodleDirectIntegration
	                As a Moodle Instructor 
					I want to manage all the usecase in Moodle 
					so that I would validate all the Moodle integration scenarios are working fine.

#Purpose : Moodle instructor cross over to Pegasus
Scenario: Moodle instructor crossover to Pegasus via direct integrated course
Given I browsed the login url for "MoodleDirectTeacher"
When I login to Moodle as "MoodleDirectTeacher"
And I enter into the moodle kiosk course "MoodleDirectCourse"
And I click on "MyITLab Instructor Access"
Then I should be on the "Course Materials" page
When I click on "Close" link in pegasus
Then I should be redirected to "MoodleDirectCourse" page
When I click on "Logout"
Then I should be on the moodle login page

#Purpose : Moodle student cross over to Pegasus
Scenario: Moodle student crossover to Pegasus via direct integrated course
Given I browsed the login url for "MoodleDirectStudent"
When I login to Moodle as "MoodleDirectStudent"
And I enter into the moodle kiosk course "MoodleDirectCourse"
And I click on "Assignment Calendar"
Then I should be on the "Course Materials" page
When I click on "Close" link in pegasus
Then I should be redirected to "MoodleDirectCourse" page
When I click on "Logout"
Then I should be on the moodle login page