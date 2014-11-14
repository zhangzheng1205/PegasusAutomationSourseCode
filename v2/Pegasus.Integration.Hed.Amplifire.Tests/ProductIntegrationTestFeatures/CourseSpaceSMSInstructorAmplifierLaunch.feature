Feature: Course Space SMS Instructor Amplifier Launch
	      As a CS SMS Instructor
		  I want to manage all the CS SMS Instructor amplifier related usecases 
		  so that I would validate all the CS SMS Instructor amplifier scenarios are working fine

#Purpose: Launching the Amplifire Link by CS instructor
#PEGASUS-31803
#peg-5957
Scenario:Launch amplifier and SSO to amplifier page as SMS Instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on "Capítulo preliminar: Bienvenidos a Unidos" folder as "CsSmsInstructor"
And I click on "¡Comprueba lo que sabes!" folder as "CsSmsInstructor"
And I open the "Amplifire Study Module 0P: Vocabulario en contexto" Activity
Then I should see the "amplifier" activity successfully launched
And I should see the BookTilte as "Chapter 16: Innate Immunity: Nonspecific Defenses of the Host"

#Purpose: Amplifire content link launch by Demo student
#PEGASUS-31807
#peg-22708
Scenario: demo student launches the amplifier content link
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I select the "Go to Student View" link in Global Home page
And I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to "Course Materials" tab and selected "View All Course Materials" subtab	
Then I should be on the "Course Materials" page
When I click on "Capítulo preliminar: Bienvenidos a Unidos" folder as "CsSmsInstructor"
Then I should be inside the folder "Capítulo preliminar: Bienvenidos a Unidos"
When I click on "¡Comprueba lo que sabes!" folder as "CsSmsInstructor"
Then I should be inside the folder "¡Comprueba lo que sabes!"
When I open the "Amplifire Study Module 0P: Vocabulario en contexto" Activity
Then I should see the "amplifier" activity successfully launched
And I should see the BookTilte as "Chapter 16: Innate Immunity: Nonspecific Defenses of the Host"


