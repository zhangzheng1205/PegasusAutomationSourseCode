Feature: PEGASUS-31802
	Teacher should be able to launch the Amplifire and Should be able to SSO to Amplifire page.




#PEGASUS-31802 Automation : HED BVT : peg-16872:Teacher should be able to launch the Amplifire and Should be able to SSO to Amplifire page.
Scenario:Launch amplifier and SSO to amplifier page as SMS Instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on "Capítulo preliminar: Bienvenidos a Unidos" folder as "CsSmsInstructor"
And I click on "¡Comprueba lo que sabes!" folder as "CsSmsInstructor"
And I open the "Amplifire Study Module 0P: Vocabulario en contexto" Activity
Then I should see the activity successfully launched
And I should see the BookTilte as "Chapter 16: Innate Immunity: Nonspecific Defenses of the Host"
