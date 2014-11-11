Feature: PEGASUS-31807
	Teacher should be able to launch the Amplifire and Should be able to SSO to Amplifire page.




Scenario: demo student Launches the Amplifire using section course as 
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
Then I should see the activity successfully launched
And I should see the BookTilte as "Chapter 16: Innate Immunity: Nonspecific Defenses of the Host"
