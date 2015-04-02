Feature: PEGASUS-31807
	      As a CS SMS Instructor
		  I want to manage all the CS SMS Instructor amplifier related usecases 
		  so that I would validate all the CS SMS Instructor amplifier scenarios are working fine

#Purpose: Amplifire content link launch by Demo student
#PEGASUS-31807
#peg-22708
Scenario: demo student launches the amplifier content link
When I select the "Go to Student View" link in Global Home page
And I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to "Course Materials" tab and selected "View All Course Materials" subtab	
Then I should be on the "Course Materials" page
When I click on "Capítulo preliminar: Bienvenidos a Unidos" folder as "AmpCsSmsInstructor"
Then I should be inside the folder "Capítulo preliminar: Bienvenidos a Unidos"
When I click on "¡Comprueba lo que sabes!" folder as "AmpCsSmsInstructor"
Then I should be inside the folder "¡Comprueba lo que sabes!"
When I open the "Amplifire Study Module 0P: Vocabulario en contexto" Activity
Then I should see the "amplifire" activity successfully launched
And I should see the expected book content