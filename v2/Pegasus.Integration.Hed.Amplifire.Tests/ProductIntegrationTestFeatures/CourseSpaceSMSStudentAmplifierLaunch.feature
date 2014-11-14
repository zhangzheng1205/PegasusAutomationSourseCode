Feature: Course Space SMS Student Amplifier Launch
	 As a CS SMS Student
	I want to manage all the CS SMS Student amplifier related usecases 
	so that I would validate all the CS SMS Student amplifier scenarios are working fine

#Purpose: Amplifire launch by student user
#PEGASUS-31804
#peg-22707
Scenario:Launch amplifier and SSO to Amplifier as SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to "Course Materials" tab and selected "View All Course Materials" subtab	
Then I should be on the "Course Materials" page
When I click on "Capítulo preliminar: Bienvenidos a Unidos" folder as "CsSmsStudent"
Then I should be inside the folder "Capítulo preliminar: Bienvenidos a Unidos"
When I click on "¡Comprueba lo que sabes!" folder as "CsSmsStudent"
Then I should be inside the folder "¡Comprueba lo que sabes!"
And  I should see the "Amplifire Study Module 0P: Vocabulario en contexto" amplifier link as "CsSmsStudent"
When I open the "Amplifire Study Module 0P: Vocabulario en contexto" Activity
Then I should see the "amplifier" activity successfully launched
And I should see the BookTilte as "Chapter 16: Innate Immunity: Nonspecific Defenses of the Host"