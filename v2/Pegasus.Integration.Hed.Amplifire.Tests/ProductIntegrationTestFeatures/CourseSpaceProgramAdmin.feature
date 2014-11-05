Feature: CourseSpaceProgramAdmin
	                As a CS Program Admin
					I want to manage all the coursespace instructor related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.


					
#PEGASUS-31805 Automation : HED BVT : peg-22716:Launching Amplifire content link copied using Add to multiple sections feature
#Purpose: Launch the Amplifire Asset using section course
Scenario: Launch the Amplifire Asset using section course 
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to "Amplifier" asset in "Course Materials" tab as "HedProgramAdmin"
And I open the "Amplifier link 1 (Content)" Activity
Then I should be on the "Pegasus" page
