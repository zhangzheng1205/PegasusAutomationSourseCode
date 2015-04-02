Feature: PEGASUS-31805
	                As a CS Program Admin
					I want to manage all the coursespace instructor amplifier related usecases 
					so that I would validate all the coursespace instructor amplifier scenarios are working fine
					

#Purpose: Launching Amplifire content link copied using Add to multiple sections feature
#PEGASUS-31805 
#peg-22716
Scenario: Launch the Amplifire Asset using section course as Program Admin
Then I should be on the "Today's View" page
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to "Capítulo preliminar: Bienvenidos a Unidos" asset in "Course Materials" tab as "AmpProgramAdmin" 
Then I should be inside the selected folder "Capítulo preliminar: Bienvenidos a Unidos"
When I navigate to "¡Comprueba lo que sabes!" asset in "Course Materials" tab as "AmpProgramAdmin" 
Then I should be inside the selected folder "¡Comprueba lo que sabes!"
When I open the "Amplifire Study Module 0P: Vocabulario en contexto" Activity
Then I should see the "amplifire" activity successfully launched
And I should see the expected book content




