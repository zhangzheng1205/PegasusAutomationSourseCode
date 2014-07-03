Feature: PEGASUS-10483: Launch MGM activity In To Do Tab by CS Student
					As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: Open DPCsStudent Url
Background:
Given I browsed the login url for "DPCsStudent"
When I login to Pegasus as "DPCsStudent" in "CourseSpace"
Then I should be logged in successfully

#Purpose: Launch MGM activity In ToDO tab By DP Student
Scenario: Launch MGM activity In To Do Tab by CS Student
Given I am on the "Overview" page
When I navigate to the "View All Content" tab
And I open the activity named as "Test"
Then I should see the Test activity successfully launched by Student 
When I "Sign Out" from the "DPCsStudent"
Then I should see the "Signed Out" message
