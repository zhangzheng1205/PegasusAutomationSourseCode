Feature: PEGASUS-27619:Automation: (Admin Modules) Stop and Start Copy functionality for Self Study courses
					As a CS student
					I want to view and enter into self study courses 
					even when stop copy, stop enrollment are enabled to PMC course.
					

#Purpose: Open CS Url and navigate to my course and test banks.
Background:
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should be on the "Global Home" page

#Purpose: To Enter self study course
Scenario: To Enter self study course
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
