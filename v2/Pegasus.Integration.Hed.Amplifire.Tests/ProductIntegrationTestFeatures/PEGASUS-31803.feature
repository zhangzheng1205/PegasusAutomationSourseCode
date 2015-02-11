Feature: PEGASUS-31803
	      As a CS SMS Instructor
		  I want to manage all the CS SMS Instructor amplifier related usecases 
		  so that I would validate all the CS SMS Instructor amplifier scenarios are working fine

#Purpose: Launching the Amplifire Link by CS instructor
#PEGASUS-31803
#peg-5957
Scenario:Launch amplifier and SSO to amplifier page as SMS Instructor
When I enter in the "AmpInstructorCourse" from the Global Home page as "AmpCsSmsInstructor"
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on "Capítulo preliminar: Bienvenidos a Unidos" folder as "AmpCsSmsInstructor"
And I click on "¡Comprueba lo que sabes!" folder as "CsSmsInstructor"
Then  I should see the "Amplifire Study Module 0P: Vocabulario en contexto" amplifier link as "AmpCsSmsInstructor"
When I open the "Amplifire Study Module 0P: Vocabulario en contexto" Activity
Then I should see the "amplifire" activity successfully launched
And I should see the BookTilte as "Chapter 16: Innate Immunity: Nonspecific Defenses of the Host"




