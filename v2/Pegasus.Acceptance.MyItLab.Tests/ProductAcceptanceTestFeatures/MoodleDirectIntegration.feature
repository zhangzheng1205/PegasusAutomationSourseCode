Feature: MoodleDirectIntegration
	                As a Moodle Instructor 
					I want to manage all the usecase in Moodle 
					so that I would validate all the Moodle integration scenarios are working fine.

#Purpose : Moodle instructor cross over to Pegasus
Scenario: Moodle instructor crossover to Pegasus via direct integrated course
When I click on "MoodleDirectInstructorLink"
Then I should be on the "Course Materials" page

#Purpose : Moodle student cross over to Pegasus
Scenario: Moodle student crossover to Pegasus via direct integrated course
When I click on "MoodleDirectStudentLink"
Then I should be on the "Course Materials" page

#Purpose: Close Pegasus Crossover
Scenario:Close Pegasus Crossover
When I click on "Close" link in pegasus
Then I should be redirected to "MoodleDirectCourse" page